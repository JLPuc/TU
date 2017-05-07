package com.mastercoder.rutas_mcturistic.view.Maps;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Color;
import android.graphics.Point;
import android.graphics.drawable.BitmapDrawable;
import android.location.Geocoder;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.net.Uri;
import android.os.Build;
import android.os.Handler;
import android.support.annotation.IdRes;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.ActivityCompat;
import android.support.v4.app.FragmentActivity;
import android.os.Bundle;
import android.transition.Fade;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.PopupWindow;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.gms.common.ConnectionResult;
import com.google.android.gms.common.api.GoogleApiClient;
import com.google.android.gms.location.LocationRequest;
import com.google.android.gms.location.LocationServices;
import com.google.android.gms.maps.CameraUpdate;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.BitmapDescriptorFactory;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.Marker;
import com.google.android.gms.maps.model.MarkerOptions;
import com.mastercoder.rutas_mcturistic.Georeferencia.MapeoEstablecimientos;
import com.mastercoder.rutas_mcturistic.Georeferencia.MapeoSitios;
import com.mastercoder.rutas_mcturistic.MainActivity;
import com.mastercoder.rutas_mcturistic.R;
import com.mastercoder.rutas_mcturistic.model.Establecimiento;
import com.mastercoder.rutas_mcturistic.model.Sitios;
import com.mastercoder.rutas_mcturistic.view.EventosMain;
import com.mastercoder.rutas_mcturistic.view.ProductosMain;
import com.roughike.bottombar.BottomBar;
import com.roughike.bottombar.OnTabSelectListener;

import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Random;

public class Maps extends FragmentActivity implements GoogleApiClient.ConnectionCallbacks,
        GoogleApiClient.OnConnectionFailedListener,OnMapReadyCallback,
        com.google.android.gms.location.LocationListener, GoogleMap.OnMapClickListener {

    private static final int MY_LOCATION_REQUEST_CODE = 2;
    PopupWindow popup = null;
    private GoogleMap mMap;
    private LocationManager locationManager;
    private Marker marcador;
    private Button btnBuscar, btnSi, btnNo;
    private EditText txtDireccion;
    private TextView txtPopUp;
    private String direccion;
    private List<android.location.Address> address;
    private AlertDialog alert = null;
    GoogleApiClient googleApiClient;
    MapeoEstablecimientos MPE;
    MapeoSitios MPS;
    private HashMap<Marker,Object> listaCompleta;
    private ArrayList<Sitios> arregloSitios;
    private ArrayList<Establecimiento> arregloEstablecimiento;
    private Location lastLocation;
    private LocationRequest locationRequest;
    private static final int REQ_PERMISSION = 2;
    LocationListener milocListener;
    private final int UPDATE_INTERVAL = 3000; // 3 minutes
    private final int FASTEST_INTERVAL = 3 * 1000;  // 30 secs
    Boolean ask = false;
    Point p;
    ImageView ir_home;
    public int clic = 0;
    private Sitios temporalSitio;
    private Establecimiento temporalEstable;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP){
            getWindow().setStatusBarColor(Color.TRANSPARENT);
            getWindow().setEnterTransition(new Fade());
        }
        setContentView(R.layout.layout_maps);
        //Instanciamos la barra de Navegación de la parte inferior.
        BottomBar bottomBar = (BottomBar) findViewById(R.id.bottombar);
        //Inicializamos una vista por default Al iniciar la app
        bottomBar.setDefaultTab(R.id.idMaps);
        bottomBar.setOnTabSelectListener(new OnTabSelectListener() {
            @Override
            public void onTabSelected(@IdRes int tabId) {
                switch (tabId){
                    case R.id.idMaps:

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
                        Intent ListSong2 = new Intent(getApplicationContext(), MainActivity.class);
                        startActivity(ListSong2);

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





        // Obtain the SupportMapFragment and get notified when the map is ready to be used.
        /*
        ir_home = (ImageView) findViewById(R.id.home_inicio);
        ir_home.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent ListSong = new Intent(getApplicationContext(), MainActivity.class);
                startActivity(ListSong);
            }
        });
        FloatingActionButton btn_Mostrar = (FloatingActionButton) findViewById(R.id.Recomendador);
        btn_Mostrar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

            }
        });
        txtDireccion = (EditText)findViewById(R.id.editText1);
        btnBuscar = (Button)findViewById(R.id.button1);
        btnBuscar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                direccion = txtDireccion.getText().toString();

                if(direccion.equals("")){
                    Toast.makeText(Maps.this,"No hay dirección para buscar : (",Toast.LENGTH_LONG).show();
                }else{
                    Toast.makeText(Maps.this,"Buscando \""+direccion+"\"",Toast.LENGTH_LONG).show();
                    Geocoder coder = new Geocoder(getApplicationContext());

                    try {
                        address = coder.getFromLocationName(direccion, 1);
                        android.location.Address location = address.get(0);
                        LatLng loc = new LatLng(location.getLatitude(),location.getLongitude());
                        CameraUpdate cu = CameraUpdateFactory.newLatLngZoom(loc,17);
                        mMap.animateCamera(cu);
                    } catch (IOException e) {
                        Toast.makeText(Maps.this,"No se ha encontrado la dirección : (",Toast.LENGTH_LONG).show();
                    }
                }

                // Ocultar el teclado
                InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
                imm.hideSoftInputFromWindow(txtDireccion.getWindowToken(), 0);
            }
        });
        */
        googleApiClient = new GoogleApiClient.Builder(this)
                .addConnectionCallbacks( this )
                .addOnConnectionFailedListener( this )
                .addApi(LocationServices.API)
                .build();
        locationManager = (LocationManager)getSystemService(Context.LOCATION_SERVICE);
        if ( !locationManager.isProviderEnabled( LocationManager.GPS_PROVIDER ) ) {
            AlertNoGps();
        }
        SupportMapFragment mapFragment = (SupportMapFragment) getSupportFragmentManager()
                .findFragmentById(R.id.map);
        mapFragment.getMapAsync(this);
        createGoogleApi();

    }

    @Override
    public void onWindowFocusChanged(boolean hasFocus) {
        super.onWindowFocusChanged(hasFocus);
        if (hasFocus){

            int[] posicion = new int[2];
            FloatingActionButton btn = (FloatingActionButton) findViewById(R.id.Recomendador);

            // obtiene las coordenadas del boton
            btn.getLocationOnScreen(posicion);

            //inicializa un nuevo punto con las coordenadas obtendidas del boton
            p = new Point();
            p.x = posicion[0];
            p.y = posicion[1];
        }
    }

    private void asignarPoint(){
        int[] posicion = new int[2];
        FloatingActionButton btn = (FloatingActionButton) findViewById(R.id.Recomendador);

        // obtiene las coordenadas del boton
        btn.getLocationOnScreen(posicion);

        //inicializa un nuevo punto con las coordenadas obtendidas del boton
        p = new Point();
        p.x = posicion[0];
        p.y = posicion[1];
    }

    private void createGoogleApi() {
        if ( googleApiClient == null ) {
            googleApiClient = new GoogleApiClient.Builder( this )
                    .addConnectionCallbacks( this )
                    .addOnConnectionFailedListener( this )
                    .addApi( LocationServices.API )
                    .build();
        }
    }

    @Override
    public void onMapReady(GoogleMap map) {
        mMap = map;
        mMap.getUiSettings().setZoomControlsEnabled(true);
        mMap.setMapType(GoogleMap.MAP_TYPE_NORMAL);
        arregloSitios = new ArrayList<Sitios>();
        arregloEstablecimiento = new ArrayList<Establecimiento>();
        listaCompleta = new HashMap<Marker, Object>();
        MPE = new MapeoEstablecimientos(mMap, listaCompleta, googleApiClient, Maps.this, arregloEstablecimiento);
        MPS = new MapeoSitios(mMap, listaCompleta, googleApiClient, Maps.this, arregloSitios);
        mMap.setOnInfoWindowClickListener(new GoogleMap.OnInfoWindowClickListener() {
            @Override
            public void onInfoWindowClick(Marker marker) {
                try { try{
                    Establecimiento est = (Establecimiento) listaCompleta.get(marker);
                } catch (Exception e){
                    Sitios est = (Sitios) listaCompleta.get(marker);

                } } catch (Exception e){

                }

            }
        });
        LatLng centro = new LatLng(20.967091, -89.623677);
        CameraUpdate inicial = CameraUpdateFactory.newLatLngZoom(centro,17);
        mMap.animateCamera(inicial);
        //milocListener = new MiLocationListener();
        if (checkPermission()){
            mMap.setMyLocationEnabled(true);
            //  locationManager.requestLocationUpdates( LocationManager.GPS_PROVIDER, 2000, 0, milocListener);
        }
        contador();
        if (p != null){
            mostrarPopup(Maps.this, p, generarRandom());
        }
        asignarPoint();
        mostrarPopup(Maps.this, p, "¿Ya comiste? ¿Te gustaría comer una rica torta de Cochinita?");
    }

    private void contador(){
        Handler handler = new Handler();
        handler.postDelayed(new Runnable() {
            public void run() {
                // acciones que se ejecutan tras los milisegundos
                contrarClic();
            }
        }, 4000);
    }

    private void contrarClic(){
        contador();
        clic++;
        if (clic%5 == 0){
            if (popup != null){
                popup.dismiss();
                popup = null;
            }
            if (p != null){
                mostrarPopup(Maps.this, p, generarRandom()) ;
            }
        }
    }

    public String generarRandom(){
        Random random = new Random();
        String texto = "";
        int val = random.nextInt(2);
        if (val < 2){
            int i = random.nextInt(arregloSitios.size());
            texto = "¿Te gustaría conocer el lugar " + arregloSitios.get(i).getNombre() + "?";
            temporalSitio = arregloSitios.get(i);
        } else{
            int i = random.nextInt(arregloEstablecimiento.size());
            texto = "Un establecimieto espera por ti ¿Quisieras ir a " + arregloEstablecimiento.get(i).getNombre() + "?";
            temporalEstable = arregloEstablecimiento.get(i);
        }
        return texto;
    }


    @Override
    public void onRequestPermissionsResult(int requestCode, String[] permissions, int[] grantResults) {
        /*if (requestCode == MY_LOCATION_REQUEST_CODE) {
            if (permissions.length == 1 &&
                    permissions[0] == Manifest.permission.ACCESS_FINE_LOCATION &&
                    grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                if (ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
                    return;
                }

            } else {
                // Permission was denied. Display an error message.
            }
        }*/
        super.onRequestPermissionsResult(requestCode, permissions, grantResults);
        switch ( requestCode ) {
            case REQ_PERMISSION: {
                if ( grantResults.length > 0
                        && grantResults[0] == PackageManager.PERMISSION_GRANTED ){
                    // Permission granted
                    getLastKnownLocation();

                } else {
                    // Permission denied
                    permissionsDenied();
                }
                break;
            }
        }
    }

    private void permissionsDenied() {
        Toast.makeText(this, "permissionsDenied()",Toast.LENGTH_LONG).show();
    }

    private boolean checkPermission(){
        return (ActivityCompat.checkSelfPermission(this, android.Manifest.permission.ACCESS_FINE_LOCATION) == PackageManager.PERMISSION_GRANTED) ;
    }

    private void AlertNoGps() {
        final AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setMessage("El sistema GPS esta desactivado, ¿Desea activarlo?")
                .setCancelable(false)
                .setPositiveButton("Si", new DialogInterface.OnClickListener() {
                    public void onClick(@SuppressWarnings("unused") final DialogInterface dialog, @SuppressWarnings("unused") final int id) {
                        startActivity(new Intent(android.provider.Settings.ACTION_LOCATION_SOURCE_SETTINGS));
                    }
                })
                .setNegativeButton("No", new DialogInterface.OnClickListener() {
                    public void onClick(final DialogInterface dialog, @SuppressWarnings("unused") final int id) {
                        dialog.cancel();
                        Intent intent = new Intent(Maps.this,MainActivity.class);
                        startActivity(intent);
                    }
                });
        alert = builder.create();
        alert.show();
    }



    private void agregarMarcador(double lat, double lon) {
        LatLng coordenadas = new LatLng(lat,lon);
        //CameraUpdate miUbicacion = CameraUpdateFactory.newLatLngZoom(coordenadas,17);
        if (marcador != null) {
            marcador.remove();
        }
        Marker nuevoMarcador = mMap.addMarker(new MarkerOptions()
                .position(coordenadas)
                .title("Mi Posición Actual ")
                .icon(BitmapDescriptorFactory.fromResource(R.drawable.marker_user)));
        marcador = nuevoMarcador;
        //mMap.animateCamera(miUbicacion);
    }


    @Override
    public void onConnected(@Nullable Bundle bundle) {
        getLastKnownLocation();
    }

    @Override
    public void onConnectionSuspended(int i) {

    }

    @Override
    public void onConnectionFailed(@NonNull ConnectionResult connectionResult) {

    }

    @Override
    public void onLocationChanged(Location location) {
        lastLocation = location;
        writeActualLocation(location);
        if(!ask) {
            // generarRandom();
            ask = true;
        }
    }

    @Override
    public void onMapClick(LatLng latLng) {

    }

    public class MiLocationListener implements LocationListener
    {
        public void onLocationChanged(Location loc)
        {
            lastLocation = loc;
            writeActualLocation(loc);
            //agregarMarcador(loc.getLatitude(),loc.getLongitude());
        }
        public void onProviderDisabled(String provider)
        {
            Toast.makeText( getApplicationContext(),"Gps Desactivado",Toast.LENGTH_SHORT ).show();
        }
        public void onProviderEnabled(String provider)
        {
            Toast.makeText( getApplicationContext(),"Gps Activo",Toast.LENGTH_SHORT ).show();
        }
        public void onStatusChanged(String provider, int status, Bundle extras){}
    }

    @Override
    protected void onStart() {
        super.onStart();

        // Call GoogleApiClient connection when starting the Activity
        googleApiClient.connect();
    }

    @Override
    protected void onStop() {
        super.onStop();

        // Disconnect GoogleApiClient when stopping Activity
        googleApiClient.disconnect();
    }

    private void askPermission() {

        ActivityCompat.requestPermissions(
                this,
                new String[] { android.Manifest.permission.ACCESS_FINE_LOCATION },
                REQ_PERMISSION
        );
    }

    private void getLastKnownLocation() {
        if ( checkPermission() ) {
            lastLocation = LocationServices.FusedLocationApi.getLastLocation(googleApiClient);
            if ( lastLocation != null ) {
                writeLastLocation();
                startLocationUpdates();
            } else {
                startLocationUpdates();
            }
        }
        else askPermission();
    }

    // Start location Updates
    private void startLocationUpdates(){
        locationRequest = LocationRequest.create()
                .setPriority(LocationRequest.PRIORITY_HIGH_ACCURACY)
                .setInterval(UPDATE_INTERVAL)
                .setFastestInterval(FASTEST_INTERVAL);

        if ( checkPermission() )
            //       locationManager.requestLocationUpdates( LocationManager.GPS_PROVIDER, 2000, 0, this);
            LocationServices.FusedLocationApi.requestLocationUpdates(googleApiClient, locationRequest, this);
    }

    private void writeActualLocation(Location location) {
        //textLat.setText( "Lat: " + location.getLatitude() );
        //textLong.setText( "Long: " + location.getLongitude() );
        agregarMarcador(location.getLatitude(), location.getLongitude());
    }

    private void writeLastLocation() {
        writeActualLocation(lastLocation);
    }

    public static Intent makeNotificationIntent(Context geofenceService, String msg)
    {
        //Log.d(TAG,msg);
        return new Intent(geofenceService, Maps.class);
    }

    public void mostrarPopup(final Activity context, Point p, final String Texto) {
        //llena el popup con el layout

        LinearLayout viewGrup = (LinearLayout) context.findViewById(R.id.popup);
        LayoutInflater layoutinflater = (LayoutInflater) context.getSystemService(context.LAYOUT_INFLATER_SERVICE);
        View layout = layoutinflater.inflate(R.layout.popup_layout, viewGrup);

        txtPopUp = (TextView) layout.findViewById(R.id.txtPopUp);
        txtPopUp.setText(Texto);
        btnSi = (Button) layout.findViewById(R.id.btnSi);
        btnNo = (Button) layout.findViewById(R.id.btnNo);

        //se definen las dimensiones de la ventana
        int popupWidth = 400 ;
        int popupHeight = 190;
        if (txtPopUp.getText().length() > 43 && txtPopUp.getText().length() < 47) {
            popupHeight = 250;
        } else if (txtPopUp.getText().length() > 47){ popupHeight = 300;}


        //creando la ventana popup
        popup = new PopupWindow(context);
        popup.setContentView(layout);
        popup.setWidth(popupWidth);
        popup.setHeight(popupHeight);
        popup.setFocusable(true);

        // Algun desplazamiento para alinear el popup un poco a la derecha, y un poco hacia abajo, en relación con la posición del botón
        int OFFSET_X = 120;
        int OFFSET_Y = 0;

        // borra el fondo traslucido por defecto

        popup.setBackgroundDrawable(new BitmapDrawable());

        // Visualización de la ventana emergente en la ubicación especificada, + desplazamientos
        popup.showAtLocation(layout, Gravity.NO_GRAVITY, p.x + OFFSET_X, p.y + OFFSET_Y);


        //Obtener una referencia al botón Cerrar y cerrar la ventana emergente cuando se hace clic.

        btnSi.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (Texto == "¿Ya comiste? ¿Te gustaría comer una rica torta de Cochinita?"){
                    generarRuta(20.962905, -89.625405);
                    popup.dismiss();
                }
                if (temporalSitio != null){
                    generarRuta(temporalSitio.getLatitud(),temporalSitio.getLongitud());
                    popup.dismiss();
                }
                if (temporalEstable != null){
                    generarRuta(temporalEstable.getLatitud(),temporalEstable.getLongitud());
                    popup.dismiss();
                }
            }
        });

        btnNo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (temporalSitio != null){
                    temporalSitio = null;
                    popup.dismiss();
                    popup = null;
                }
                if (temporalEstable != null){
                    temporalEstable = null;
                    popup.dismiss();
                    popup = null;
                }
            }
        });
    }

    private void generarRuta(double lat, double lon){
        try
        {
            String Url1 = "google.navigation:q="+lat +","+lon+"&mode=w";
            Uri gmmIntentUri = Uri.parse(Url1);
            Intent mapIntent = new Intent(Intent.ACTION_VIEW, gmmIntentUri);
            mapIntent.setPackage("com.google.android.apps.maps");
            startActivity(mapIntent);
        }catch (Exception ex)
        {

        }

    }
}
