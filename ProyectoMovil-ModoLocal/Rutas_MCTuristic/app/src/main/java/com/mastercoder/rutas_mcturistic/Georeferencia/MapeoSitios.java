package com.mastercoder.rutas_mcturistic.Georeferencia;

import android.Manifest;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Color;
import android.os.AsyncTask;
import android.support.annotation.NonNull;
import android.support.v4.app.ActivityCompat;

import com.google.android.gms.common.api.GoogleApiClient;
import com.google.android.gms.common.api.Result;
import com.google.android.gms.common.api.ResultCallback;
import com.google.android.gms.location.Geofence;
import com.google.android.gms.location.GeofencingRequest;
import com.google.android.gms.location.LocationServices;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.model.BitmapDescriptorFactory;
import com.google.android.gms.maps.model.Circle;
import com.google.android.gms.maps.model.CircleOptions;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.Marker;
import com.google.android.gms.maps.model.MarkerOptions;
import com.mastercoder.rutas_mcturistic.R;
import com.mastercoder.rutas_mcturistic.model.Sitios;

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
import java.util.HashMap;

/**
 * Created by Andre on 22/03/2017.
 */

public class MapeoSitios implements ResultCallback {

    private GoogleMap mMap;
    private HashMap<Marker, Object> listaSitio;
    private ArrayList<Sitios> arregloSitio;
    private GoogleApiClient googleApiClient;
    private Context contexto;
    private static final long GEO_DURATION = 60*60*1000;
    private static final String GEOFENCE_REQ_ID = "área georeferenciada";
    private static final float GEOFENCE_RADIUS = 70.0f; // in meters
    private PendingIntent geoFencePendingIntent;
    private final int GEOFENCE_REQ_CODE = 0;

    public MapeoSitios(GoogleMap googleMap, HashMap<Marker, Object> lista, GoogleApiClient gac, Context context, ArrayList<Sitios> arreglo) {
        mMap = googleMap;

        arregloSitio = arreglo;
        googleApiClient = gac;
        contexto = context;
        listaSitio = lista;
        CargarSitios();

    }

    private void agregarMarcadorSitios(double lat, double lon, String nombre, String contenido, Sitios sitios) {
        LatLng coordenadas = new LatLng(lat, lon);
        Marker marker = mMap.addMarker(new MarkerOptions()
                .position(coordenadas)
                .title(nombre)
                .snippet(contenido + "\nClic en esta ventana para más información")
                .icon(BitmapDescriptorFactory.fromResource(R.drawable.sitios)));
        Circle circleOptions =  mMap.addCircle(new CircleOptions()
                .center( marker.getPosition())
                .strokeColor(Color.argb(50, 70,70,70))
                .fillColor( Color.argb(100, 150,150,150) )
                .radius( GEOFENCE_RADIUS ));
        listaSitio.put(marker, sitios);
        arregloSitio.add( sitios);
        startGeofence(marker);
    }

    public  void  CargarSitios()
    {
        String strAccion = "Wver_sitiosMovil_Descripcion";
        // String strAccion = "Guardar";
        String strUrl = "http://wsmcturistic.azurewebsites.net/UI/WsMCTuristic.asmx/";
        //String strUrl = "http://utmandroid.somee.com/WebService1.asmx/";
        String UrlWebService = strUrl + strAccion ;
        //String UrlWebService = strUrl + strAccion + "?Nombre="+strNombre+"&Apellido="+strApelli;
        new JSONTask2().execute(UrlWebService);
    }

    // Create a Geofence
    private Geofence createGeofence(LatLng latLng, float radius ) {
        //Log.d(TAG, "createGeofence");
        return new Geofence.Builder()
                .setRequestId(GEOFENCE_REQ_ID)
                .setCircularRegion( latLng.latitude, latLng.longitude, radius)
                .setExpirationDuration( GEO_DURATION )
                .setTransitionTypes( Geofence.GEOFENCE_TRANSITION_ENTER
                        | Geofence.GEOFENCE_TRANSITION_EXIT )
                .build();
    }

    // Create a Geofence Request
    private GeofencingRequest createGeofenceRequest(Geofence geofence ) {
        //Log.d(TAG, "createGeofenceRequest");
        return new GeofencingRequest.Builder()
                .setInitialTrigger( GeofencingRequest.INITIAL_TRIGGER_ENTER )
                .addGeofence( geofence )
                .build();
    }

    private PendingIntent createGeofencePendingIntent() {
        //Log.d(TAG, "createGeofencePendingIntent");
        if ( geoFencePendingIntent != null )
            return geoFencePendingIntent;

        Intent intent = new Intent( contexto, GeoreferenciasServicio.class);
        return PendingIntent.getService(
                contexto, GEOFENCE_REQ_CODE, intent, PendingIntent.FLAG_UPDATE_CURRENT );
    }

    // Add the created GeofenceRequest to the device's monitoring list
    private void addGeofence(GeofencingRequest request) {
        //Log.d(TAG, "addGeofence");
        if (checkPermission())
            LocationServices.GeofencingApi.addGeofences(
                    googleApiClient,
                    request,
                    createGeofencePendingIntent()
            ).setResultCallback(this);
    }

    private void startGeofence(Marker marcador) {
        //Log.i(TAG, "startGeofence()");
        if( marcador != null ) {
            Geofence geofence = createGeofence( marcador.getPosition(), GEOFENCE_RADIUS );
            GeofencingRequest geofenceRequest = createGeofenceRequest( geofence );
            addGeofence( geofenceRequest );
        } else {
            //Log.e(TAG, "Geofence marker is null");
        }
    }

    @Override
    public void onResult(@NonNull Result result) {
        if (result.getStatus().isSuccess()){

        } else {
            // inform about fail
        }
    }

    private boolean checkPermission(){
        return (ActivityCompat.checkSelfPermission(contexto, Manifest.permission.ACCESS_FINE_LOCATION) == PackageManager.PERMISSION_GRANTED) ;
    }


    public class JSONTask2 extends AsyncTask<String,String,String> {
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
                String Datos = Resultado;
                JSONArray ResultadosArray = null;
                try {
                    ResultadosArray = new JSONArray(Datos);
                    for(int i = 0; i < ResultadosArray.length();i++){
                        JSONObject object = ResultadosArray.getJSONObject(i);
                        Sitios sitios = new Sitios();
                        sitios.setCódigo(object.getString("Código"));
                        sitios.setNombre(object.getString("Nombre"));
                        sitios.setDescripción(object.getString("Descripción"));
                        sitios.setLatitud(object.getDouble("Latitud"));
                        sitios.setLongitud(object.getDouble("Longitud"));
                        agregarMarcadorSitios(object.getDouble("Latitud"),object.getDouble("Longitud")
                                ,object.getString("Nombre"), object.getString("Descripción"),
                                sitios);

                    }
                }
                catch (JSONException e){
                    e.printStackTrace();
                }
            }
            catch (Exception t){ //Throwable t
                //  t.printStackTrace();
                ///Toast.makeText(HomeFragment.this,t.getMessage(), Toast.LENGTH_SHORT).show();

            }
        }
    }

}
