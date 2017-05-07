package com.mastercoder.rutas_mcturistic.view.fragment.Fragment_Servicios;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Base64;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.mastercoder.rutas_mcturistic.R;

public class DetalleServicio extends AppCompatActivity {

    TextView titulo;
    ImageView avatar,ruta_generar;
    ImageView foto ;
    TextView usuario ;
    TextView tiempoExistencia;
    TextView noComentario ;
    TextView noLikes;
    String NombreServicio;
    String  Precio;
    String FotoUser;
    String FotoServicio;
    String LikeNumero;
    Double Longitud,Latitud;
    String Nombre,FechaInicio;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_detalle_servicio);

        ruta_generar =(ImageView)findViewById(R.id.ruta_generar);
         titulo = (TextView) findViewById(R.id.titulo_imagen);
         avatar = (ImageView) findViewById(R.id.avatar);
         foto = (ImageView) findViewById(R.id.foto);
         usuario = (TextView) findViewById(R.id.texto_marca_usuario);
         tiempoExistencia = (TextView) findViewById(R.id.tiempoExistencia);
        noComentario = (TextView)findViewById(R.id.noComentarios);


        ruta_generar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String Url1 = "google.navigation:q="+Latitud +","+Longitud+"&mode=w";
                Uri gmmIntentUri = Uri.parse(Url1);
                Intent mapIntent = new Intent(Intent.ACTION_VIEW, gmmIntentUri);
                mapIntent.setPackage("com.google.android.apps.maps");
                startActivity(mapIntent);
            }
        });

         noLikes = (TextView) findViewById(R.id.noLikes);

        try
        {
            NombreServicio = getIntent().getExtras().getString("NombreServicio");
            Precio =getIntent().getExtras().getString("Precio");
            LikeNumero = getIntent().getExtras().getString("LikeNumero");
            Nombre = getIntent().getExtras().getString("Nombre") +" " +getIntent().getExtras().getString("Apellidos");
            FotoUser = getIntent().getExtras().getString("FotoUser");
            FotoServicio = getIntent().getExtras().getString("FotoServicio");
            Longitud = getIntent().getExtras().getDouble("Longitud");
            FechaInicio = getIntent().getExtras().getString("FechaInicio");
            Latitud = getIntent().getExtras().getDouble("Latitud");
            titulo.setText(NombreServicio);
            //Creamos un byte[] Del dato Foto que proviene del la clase PictureAdapterRecyclerView
            byte[] decodeString = Base64.decode(FotoUser,Base64.DEFAULT);
            //Decodifica el byte[] y lo convierte a un objeto Bitmap.
            Bitmap decoded = BitmapFactory.decodeByteArray(decodeString,0,decodeString.length);
            avatar.setImageBitmap(decoded);

            byte[] decodeString1 = Base64.decode(FotoServicio,Base64.DEFAULT);
            //Decodifica el byte[] y lo convierte a un objeto Bitmap.
            Bitmap decoded1 = BitmapFactory.decodeByteArray(decodeString1,0,decodeString1.length);
            foto.setImageBitmap(decoded1);
            usuario.setText(Nombre);
            noLikes.setText(LikeNumero);
            noComentario.setText(FechaInicio);

        }
        catch (Exception ex)
        {
            Toast.makeText(getBaseContext(),"No se puede recuperar información intente de nuevo",Toast.LENGTH_SHORT);
        }




    }


}
