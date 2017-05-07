package com.mastercoder.rutas_mcturistic.view;

import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.DialogFragment;
import android.content.Intent;
import android.os.AsyncTask;
import android.support.annotation.IdRes;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.DatePicker;
import android.widget.TextView;

import com.mastercoder.rutas_mcturistic.R;
import com.mastercoder.rutas_mcturistic.model.Eventos;
import com.mastercoder.rutas_mcturistic.MainActivity;
import com.mastercoder.rutas_mcturistic.view.Maps.Maps;
import com.mastercoder.rutas_mcturistic.view.fragment.Fragment_Eventos.EventosFragment;
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
import java.util.Calendar;

public class EventosMain extends AppCompatActivity {
    String Date;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_eventos_vista);

        BottomBar bottomBar = (BottomBar) findViewById(R.id.bottombar);

        bottomBar.setDefaultTab(R.id.search);
        bottomBar.setOnTabSelectListener(new OnTabSelectListener() {
            @Override
            public void onTabSelected(@IdRes int tabId) {
                switch (tabId){

                    case R.id.idMaps:

                       // MapaFragment homeFragment = new MapaFragment();
                        //getSupportFragmentManager().beginTransaction().replace(R.id.container, homeFragment)
                          //      .setTransition(FragmentTransaction.TRANSIT_FRAGMENT_FADE)
                            //    .addToBackStack(null).commit();
                        Intent ListSongs = new Intent(getApplicationContext(), Maps.class);
                        startActivity(ListSongs);
                        break;
                    case R.id.home:
                        /*
                        HomeFragment homeFragment = new HomeFragment();
                        getSupportFragmentManager().beginTransaction().replace(R.id.container, homeFragment)
                                .setTransition(FragmentTransaction.TRANSIT_FRAGMENT_FADE)
                                .addToBackStack(null).commit();
                                */
                        Intent ListSong = new Intent(getApplicationContext(), MainActivity.class);
                        startActivity(ListSong);
                        break;
                    case R.id.profile:

                        Intent ListSong1 = new Intent(getApplicationContext(), ProductosMain.class);
                        startActivity(ListSong1);
                        /*ProfileFragment profileFragment = new ProfileFragment();
                        getSupportFragmentManager().beginTransaction().replace(R.id.container, profileFragment)
                                .setTransition(FragmentTransaction.TRANSIT_FRAGMENT_FADE)
                                .addToBackStack(null).commit();*/
                        // CargarSitioProfiles();
                        break;
                    case R.id.search:
                        //Eventos
                        CargarSitioProfiles("03/23/2017");
                        break;
                }
            }
        });
        FloatingActionButton btnFecha = (FloatingActionButton) findViewById(R.id.btnDate);
        btnFecha.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                DialogFragment calendario = new EventosMain.Calendario();
                calendario.show(getFragmentManager(), "DatePicker");

            }
        });



    }
    public class Calendario extends DialogFragment implements DatePickerDialog.OnDateSetListener {

        @Override
        public Dialog onCreateDialog(Bundle savedInstanceState) {
            final Calendar c = Calendar.getInstance();
            int year = c.get(Calendar.YEAR);
            int month = c.get(Calendar.MONTH);
            int day = c.get(Calendar.DAY_OF_MONTH);

            return new DatePickerDialog(getActivity(), this, year, month, day);
        }

        public void onDateSet(DatePicker view, int year, int month, int day) {
            TextView tv1= (TextView) getActivity().findViewById(R.id.Datetxt);
            String Date = view.getMonth()+1+"/"+view.getDayOfMonth()+"/"+view.getYear();
            CargarSitioProfiles(Date);
        }
    }

    public  void  CargarSitioProfiles(String Date)
    {
        this.Date = Date;
        String strAccion = "WsVerEventos_Date";
        // String strAccion = "Guardar";
        String strUrl = "http://wsmcturistic.azurewebsites.net/UI/WsMCTuristic.asmx/";
        //String strUrl = "http://utmandroid.somee.com/WebService1.asmx/";
        String UrlWebService = strUrl + strAccion + "?Dia="+Date;
        //String UrlWebService = strUrl + strAccion + "?Nombre="+strNombre+"&Apellido="+strApelli;
        new EventosMain.JSONTaskProfiles().execute(UrlWebService);

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
                ArrayList<Eventos> objEventos = new ArrayList<>();
                String Datos = Resultado;
                JSONArray ResultadosArray = null;
                try {
                    ResultadosArray = new JSONArray(Datos);
                    for(int i = 0; i < ResultadosArray.length();i++){
                        JSONObject object = ResultadosArray.getJSONObject(i);
                        //int idEvento, String nombreEvent, String fotoEvento,
                          //      Date fechaIncio, String horaInicio, String nombreUser, String fotoUser, int idSitio

                     //   Select ,,Eventos.,,,Usuario.Nombre,Usuario.Foto as '', from Eventos  INNER JOIN  Usuario on (Eventos.idUsuario = Usuario.IdUsuario)
                       // where Eventos.FechaIncio = @Fecha

                        objEventos.add(new Eventos(object.getInt("idEvento"),
                                object.getString("NombreEvent"),object.getString("Foto"),
                                object.getString("FechaIncio"),object.getString("HoroInicio"),
                                object.getString("Nombre"),object.getString("FotoUser"),object.getInt("idSitio"),
                                object.getDouble("Latitud"),object.getDouble("Longitud")
                                ));
                    }
                }
                catch (JSONException e){
                    e.printStackTrace();
                }


                EventosFragment homeFragment = new EventosFragment(objEventos);
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
