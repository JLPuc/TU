package com.mastercoder.rutas_mcturistic;

import android.content.Intent;
import android.os.AsyncTask;
import android.support.annotation.IdRes;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;

import com.mastercoder.rutas_mcturistic.LectorJSON.LectorArchivosJson;
import com.mastercoder.rutas_mcturistic.view.InicioSesion.Login;

import com.facebook.login.LoginManager;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.mastercoder.rutas_mcturistic.TextToSpeech.ReproducirTextoServicio;
import com.mastercoder.rutas_mcturistic.model.Sitios;
import com.mastercoder.rutas_mcturistic.view.Maps.Maps;
import com.mastercoder.rutas_mcturistic.view.ProductosMain;
import com.mastercoder.rutas_mcturistic.view.EventosMain;
import com.mastercoder.rutas_mcturistic.view.fragment.Fragment_Sitios.HomeFragment;
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
//Actividad Principal Para llamar cada uno de los Fragments.
public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_container);

        //Instanciamos la barra de Navegación de la parte inferior.
        BottomBar bottomBar = (BottomBar) findViewById(R.id.bottombar);
        //Inicializamos una vista por default Al iniciar la app
        bottomBar.setDefaultTab(R.id.home);
        bottomBar.setOnTabSelectListener(new OnTabSelectListener() {
            @Override
            public void onTabSelected(@IdRes int tabId) {
                switch (tabId){
                    case R.id.idMaps:

                        Intent ListSongs = new Intent(getApplicationContext(), Maps.class);
                       startActivity(ListSongs);
                        //MapaFragment homeFragment = new MapaFragment();
                        //getSupportFragmentManager().beginTransaction().replace(R.id.container, homeFragment)
                         //       .setTransition(FragmentTransaction.TRANSIT_FRAGMENT_FADE)
                           //     .addToBackStack(null).commit();

                        break;
                    case R.id.home:
                        /*
                        HomeFragment homeFragment = new HomeFragment();
                        getSupportFragmentManager().beginTransaction().replace(R.id.container, homeFragment)
                                .setTransition(FragmentTransaction.TRANSIT_FRAGMENT_FADE)
                                .addToBackStack(null).commit();
                                */
                        CargarSitios();
                        break;
                    case R.id.profile:
                        Intent ListSong = new Intent(getApplicationContext(), ProductosMain.class);
                        startActivity(ListSong);
                        /*ProfileFragment profileFragment = new ProfileFragment();
                        getSupportFragmentManager().beginTransaction().replace(R.id.container, profileFragment)
                                .setTransition(FragmentTransaction.TRANSIT_FRAGMENT_FADE)
                                .addToBackStack(null).commit();*/
                       // CargarSitioProfiles();
                        break;
                    case R.id.search:
                        Intent ListSong1 = new Intent(getApplicationContext(), EventosMain.class);
                        startActivity(ListSong1);
                        break;
                }
            }
        });

    FirebaseUser user = FirebaseAuth.getInstance().getCurrentUser();

        try {
            if (user != null) {
                Object us = user;
            } else {
                goLogin();
            }
        } catch (Exception e) { }

        FloatingActionButton btnLogOut = (FloatingActionButton) findViewById(R.id.btnLogOut);
        btnLogOut.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                logOut(view);
            }
        });


        ReproducirTextoServicio RTS = new ReproducirTextoServicio();
        RTS.reproducirSituaciones(MainActivity.this);


    }

    private void goLogin(){
        Intent intent = new Intent(this, Login.class);
        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_CLEAR_TASK | Intent.FLAG_ACTIVITY_NEW_TASK);
        startActivity(intent);
    }

    private void logOut(View view) {
        FirebaseAuth.getInstance().signOut();
        LoginManager.getInstance().logOut();
        goLogin();
    }

    public String leerArchivoJSON() {
        String json = null;
        try {
            InputStream is = getResources().openRawResource(R.raw.wver_sitiosmovil_all);
            int size = is.available();
            byte[] buffer = new byte[size];
            is.read(buffer);
            is.close();
            json = new String(buffer, "UTF-8");
        } catch (IOException ex) {
            ex.printStackTrace();
            return null;
        }
        return json;
    }

    //Cargar CardView de Sitios.
    public  void  CargarSitios()
    {
        LectorArchivosJson laj = new LectorArchivosJson(this);
        try{
            //Se crea una Lista de los Sitios...
            ArrayList<Sitios> objtSitios = new ArrayList<>();
            //Lo que se recupero por medió de la extración de datos se pasa a un String
            String Datos = leerArchivoJSON();
            //Se crea un ArrayTipo Json para leer la cadena.
            JSONArray ResultadosArray = null;
            try {
                ResultadosArray = new JSONArray(Datos);
                //Comienza el recorrido de cada una de las lineas generadas
                for(int i = 0; i < ResultadosArray.length();i++){

                    JSONObject object = ResultadosArray.getJSONObject(i);
                    //Se agrega a la lista cada uno de los items regresados de la base de datos.
                    objtSitios.add(
                            new Sitios(
                                    object.getString("Foto"),
                                    object.getString("Nombre"),
                                    object.getString("Código"),
                                    "3445 Megusta")
                    );
                }
            }
            catch (JSONException e){
                e.printStackTrace();
            }
            //Una vez recuperado los Datos prosigue a mostrar el Frangmento pasando el objeto Sitios
            //Por medio del Constructor
            HomeFragment homeFragment = new HomeFragment(objtSitios);
            getSupportFragmentManager().beginTransaction().replace(R.id.container, homeFragment)
                    .setTransition(FragmentTransaction.TRANSIT_FRAGMENT_FADE)
                    .addToBackStack(null).commit();
        }
        catch (Exception t){ //
            // Throwable t
            //  t.printStackTrace();
            ///Toast.makeText(HomeFragment.this,t.getMessage(), Toast.LENGTH_SHORT).show();

        }
        //Instancia el nombre del Método que esta en la WebServices.
       // String strAccion = "wver_sitiosmovil_all";
        //URL directa donde esta alojado la webservices
       // String strUrl = "http://wsmcturistic.azurewebsites.net/UI/WsMCTuristic.asmx/";
        //Genera una cadena al momento de la petición.
       // String UrlWebService = strUrl + strAccion ;
        //Llama a la clase que esta en la misma Actividad.
       // new JSONTask().execute(UrlWebService);
    }
    public class JSONTask extends AsyncTask<String,String,String> {

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
                //Se crea una Lista de los Sitios...
                ArrayList<Sitios> objtSitios = new ArrayList<>();
                //Lo que se recupero por medió de la extración de datos se pasa a un String
                String Datos = Resultado;
                //Se crea un ArrayTipo Json para leer la cadena.
                JSONArray ResultadosArray = null;
                try {
                    ResultadosArray = new JSONArray(Datos);
                    //Comienza el recorrido de cada una de las lineas generadas
                    for(int i = 0; i < ResultadosArray.length();i++){

                        JSONObject object = ResultadosArray.getJSONObject(i);
                        //Se agrega a la lista cada uno de los items regresados de la base de datos.
                        objtSitios.add(
                                new Sitios(
                                        object.getString("Foto"),
                                        object.getString("Nombre"),
                                        object.getString("Código"),
                                        "3445 Megusta")
                        );
                    }
                }
                catch (JSONException e){
                    e.printStackTrace();
                }
                //Una vez recuperado los Datos prosigue a mostrar el Frangmento pasando el objeto Sitios
                //Por medio del Constructor
                HomeFragment homeFragment = new HomeFragment(objtSitios);
                getSupportFragmentManager().beginTransaction().replace(R.id.container, homeFragment)
                        .setTransition(FragmentTransaction.TRANSIT_FRAGMENT_FADE)
                        .addToBackStack(null).commit();
            }
            catch (Exception t){ //
                // Throwable t
                //  t.printStackTrace();
                ///Toast.makeText(HomeFragment.this,t.getMessage(), Toast.LENGTH_SHORT).show();

            }
        }
    }


}
