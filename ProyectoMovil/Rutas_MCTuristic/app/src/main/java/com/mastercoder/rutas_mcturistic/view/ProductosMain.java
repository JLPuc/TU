package com.mastercoder.rutas_mcturistic.view;

import android.content.Intent;
import android.os.AsyncTask;
import android.support.annotation.IdRes;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import com.mastercoder.rutas_mcturistic.MainActivity;
import com.mastercoder.rutas_mcturistic.R;
import com.mastercoder.rutas_mcturistic.Temporizador.Temporizador;
import com.mastercoder.rutas_mcturistic.model.Servicios;
import com.mastercoder.rutas_mcturistic.view.fragment.Fragment_Servicios.BaresFragment;
import com.roughike.bottombar.BottomBar;
import com.roughike.bottombar.OnTabSelectListener;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.ArrayList;
//Interfaz completa de Los Servicios.
public class ProductosMain extends AppCompatActivity {
    String tipoServicio;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_productos_main);
        BottomBar bottomBar = (BottomBar) findViewById(R.id.bottombar_productos);
        bottomBar.setDefaultTab(R.id.Restaurantes);
        bottomBar.setOnTabSelectListener(new OnTabSelectListener() {
            @Override
            public void onTabSelected(@IdRes int tabId) {
                switch (tabId){
                    case R.id.inicio_sitios:
                        Intent ListSong = new Intent(getApplicationContext(), MainActivity.class);
                        startActivity(ListSong);
                        finish();
                        break;
                    case R.id.hoteles:
                        /*
                        Framet homeFragment = new HomeFragment();
                        getSupportFragmentManager().beginTransaction().replace(R.id.container, homeFragment)
                                .setTransition(FragmentTransaction.TRANSIT_FRAGMENT_FADE)
                                .addToBackStack(null).commit();
                                */
                        //Intent ListSong = new Intent(getApplicationContext(), MainActivity.class);
                        //startActivity(ListSong);

                       // Intent ListSong = new Intent(getApplicationContext(), ActividadPrincipal.class);
                        //startActivity(ListSong);
                        CargarSitioProfiles("Hoteles");

                        break;
                    case R.id.Restaurantes:
                        CargarSitioProfiles("Restaurantes");
                         break;
                    case R.id.Bares:
                        CargarSitioProfiles("Bares");

                        break;
                }
            }
        });
        Temporizador temporizador = new Temporizador();
        String Texto = "Veo que estás interesado en algo para comer.\n\nDescubre dónde te ubicas" +
                " y qué lugares hay a tu alrededor. \n\n¿Desea abrir el mapa?";
        temporizador.tempMap(ProductosMain.this, Texto, "Mapa");
    }
    public  void  CargarSitioProfiles(String tipoServicio)
    {
        this.tipoServicio = tipoServicio;
        String strAccion = "WverServicios_TipoSitio";
        // String strAccion = "Guardar";
        String strUrl = "http://wsmcturistic.azurewebsites.net/UI/WsMCTuristic.asmx/";
        //String strUrl = "http://utmandroid.somee.com/WebService1.asmx/";
        String UrlWebService = strUrl + strAccion + "?Sitio="+tipoServicio;
        //String UrlWebService = strUrl + strAccion + "?Nombre="+strNombre+"&Apellido="+strApelli;
        new ProductosMain.JSONTaskProfiles().execute(UrlWebService);

    }
    public class JSONTaskProfiles extends AsyncTask<String,String,String> {
        @Override
        protected String doInBackground(String... Parametros){
            HttpURLConnection conexion = null;
            BufferedReader reader = null;
            try{
                URL url = new URL(Parametros[0]);
                conexion = (HttpURLConnection)url.openConnection();
                conexion.connect();
                InputStream stream = conexion.getInputStream();
                reader = new BufferedReader((new InputStreamReader(stream)));
                StringBuffer buffer = new StringBuffer();
                String Line = "";
                while ((Line = reader.readLine()) != null){
                    buffer.append(Line);
                }
                return buffer.toString();
            }
            catch (MalformedURLException e){
                e.printStackTrace();
            }
            catch (IOException e){
                e.printStackTrace();
            }
            finally {
                if(conexion != null){
                    conexion.disconnect();
                }
                try{
                    if(reader!= null){
                        reader.close();
                    }
                }
                catch (IOException e){
                    e.printStackTrace();
                }
            }
            return null;
        }
        @Override
        protected void onPostExecute(String Resultado){
            super.onPostExecute(Resultado);
            try{
                ArrayList<Servicios> objServicios = new ArrayList<>();
                String Datos = Resultado;
                JSONArray ResultadosArray = null;
                try {
                    ResultadosArray = new JSONArray(Datos);
                    for(int i = 0; i < ResultadosArray.length();i++){
                        JSONObject object = ResultadosArray.getJSONObject(i);
                        objServicios.add(new Servicios(object.getInt("idServicio"),
                                object.getString("NombreServ"),object.getDouble("PreciosServicio"),
                                object.getString("Popularidad"),object.getString("Foto"),
                                object.getString("NombreUsuario"),object.getString("Apellidos"),object.getString("FotoUsuario"),
                                object.getDouble("Latitud"),object.getDouble("Longitud")
                        ));
                    }
                }
                catch (JSONException e){
                    e.printStackTrace();
                }
                BaresFragment homeFragment = new BaresFragment(objServicios,tipoServicio);
                getSupportFragmentManager().beginTransaction().replace(R.id.container, homeFragment)
                        .setTransition(FragmentTransaction.TRANSIT_FRAGMENT_FADE)
                        .addToBackStack(null).commit();
            }
            catch (Exception t){ //Throwable t
                //  t.printStackTrace();
                ///Toast.makeText(HomeFragment.this,t.getMessage(), Toast.LENGTH_SHORT).show();

            }
        }
    }
}
