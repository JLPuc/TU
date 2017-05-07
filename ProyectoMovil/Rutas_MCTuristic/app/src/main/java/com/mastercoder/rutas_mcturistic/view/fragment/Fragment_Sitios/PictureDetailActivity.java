package com.mastercoder.rutas_mcturistic.view.fragment.Fragment_Sitios;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Color;
import android.net.Uri;
import android.os.Build;
import android.support.design.widget.CollapsingToolbarLayout;
import android.support.design.widget.FloatingActionButton;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.transition.Fade;
import android.util.Base64;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import com.mastercoder.rutas_mcturistic.R;
import com.mastercoder.rutas_mcturistic.TextToSpeech.ReproducirTextoServicio;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.File;
import java.io.FileOutputStream;
import java.util.ArrayList;

public class PictureDetailActivity extends AppCompatActivity {

    TextView NameDetail,textoHistoria;
    TextView Dirrecciondetall,sucesosimportantes;
    TextView textoDescripcion;
    ImageView imageHeader;
    Double Latitud;
    Double Longitud;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_picture_detail);
        //Instanciamos todos los controles del XML
        imageHeader =(ImageView) findViewById(R.id.imageHeader);
        NameDetail =(TextView)findViewById(R.id.NameDetail);
        Dirrecciondetall  =(TextView)findViewById(R.id.Dirrecciondetall);
        textoDescripcion =(TextView)findViewById(R.id.textoDescripcion);
        sucesosimportantes =(TextView)findViewById(R.id.sucesosimportantes);
        textoHistoria =(TextView)findViewById(R.id.textoHistoria);


        //Recepcionamos los Datos enviados desde la clase PictureAdapterRecyclerView y lo asignamos a valores locales
        String id = getIntent().getExtras().getString("id");
        String Foto = getIntent().getExtras().getString("Foto");
        //Creamos un arraylist y le asignmos el que recive desde la clase
        ArrayList Sitios = new ArrayList();
        String Datos =  getIntent().getStringExtra("ResuldatosArray");
        //Comenzamos a recorrer el Json para asignar los valores
        JSONArray ResultadosArray = null;
        try {
            ResultadosArray = new JSONArray(Datos);
            for(int i = 0; i < ResultadosArray.length();i++){
                //el objeto object del JSONObject se posiciona según el contador = i;
                JSONObject object = ResultadosArray.getJSONObject(i);
                //Pasar los valores que se encuentres en el objeto object, se captura por medio de getString y se asgina a su variable
                NameDetail.setText(object.getString("Nombre"));
                textoDescripcion.setText(object.getString("Descripción"));
                sucesosimportantes.setText(object.getString("Sucesosimportantes"));
                textoHistoria.setText(object.getString("Historia"));
                Dirrecciondetall.setText(object.getString("Dirección"));
                Latitud = object.getDouble("Latitud");
                Longitud = object.getDouble("Longitud");
                        //objtSitios.add(new Sitios(object.getString("Código"), object.getString("Nombre"), object.getString("Descripción"), object.getString("Sucesosimportantes"), object.getString("Historia"), object.getString("Dirección"), object.getDouble("Latitud"), object.getDouble("Longitud"), object.getInt("idTipoSitio"));
                String cadena = NameDetail.getText().toString() + textoDescripcion.getText().toString();
                        ReproducirTextoServicio rts = new ReproducirTextoServicio();
                rts.reproducirSoloTexto(this,cadena," ");
            }

        }
        catch (JSONException e){
            e.printStackTrace();
        }

        //Creamos un byte[] Del dato Foto que proviene del la clase PictureAdapterRecyclerView
        byte[] decodeString = Base64.decode(Foto,Base64.DEFAULT);
        //Decodifica el byte[] y lo convierte a un objeto Bitmap.
         Bitmap decoded = BitmapFactory.decodeByteArray(decodeString,0,decodeString.length);
        imageHeader.setImageBitmap(decoded);

        //Se encarga de asignar la transparencia si es una Versión mayor o igual 5.1.0 LOLLIPOP para darle efecto de Material Design
        showToolbar("", true);
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP){
            getWindow().setStatusBarColor(Color.TRANSPARENT);
            getWindow().setEnterTransition(new Fade());
        }
        //Ini
        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.RealidaAumentada);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent launchIntent = getPackageManager().getLaunchIntentForPackage("com.MasterCoder.RAEx");
                startActivity(launchIntent);
            }
        });

        FloatingActionButton fab2 = (FloatingActionButton) findViewById(R.id.Ruta);
        fab2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                String Url1 = "google.navigation:q="+Latitud +","+Longitud+"&mode=w";
                Uri gmmIntentUri = Uri.parse(Url1);
                Intent mapIntent = new Intent(Intent.ACTION_VIEW, gmmIntentUri);
                mapIntent.setPackage("com.google.android.apps.maps");
                startActivity(mapIntent);
            }
        });
        FloatingActionButton fab3 = (FloatingActionButton) findViewById(R.id.Facebook);
        fab3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                imageHeader.buildDrawingCache();
                Bitmap bitmap = imageHeader.getDrawingCache();
                //Este metodo sirve para compartir imagenes dentro de la aplicación
                try {
                    File file = new File(getCacheDir(), bitmap + ".png");
                    FileOutputStream fOut = null;
                    fOut = new FileOutputStream(file);
                    bitmap.compress(Bitmap.CompressFormat.PNG, 100, fOut);
                    fOut.flush();
                    fOut.close();
                    file.setReadable(true, false);
                    Intent intent = new Intent(android.content.Intent.ACTION_SEND);
                    intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                    intent.putExtra(Intent.EXTRA_STREAM, Uri.fromFile(file));
                    intent.setType("image/png");
                    startActivity(Intent.createChooser(intent, "Desea abrir con:"));
                } catch (Exception e) {
                    e.printStackTrace();
                }

            }
        });


    }


        public void showToolbar(String tittle, boolean upButton){
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        getSupportActionBar().setTitle(tittle);
        getSupportActionBar().setDisplayHomeAsUpEnabled(upButton);
        CollapsingToolbarLayout collapsingToolbarLayout = (CollapsingToolbarLayout) findViewById(R.id.collapsingToolbar);

    }
}


