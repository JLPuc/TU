package com.mastercoder.rutas_mcturistic.adapter;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.support.v7.widget.RecyclerView;
import android.util.Base64;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import com.mastercoder.rutas_mcturistic.R;
import com.mastercoder.rutas_mcturistic.model.Eventos;
import com.mastercoder.rutas_mcturistic.view.fragment.Fragment_Servicios.DetalleServicio;
import com.mastercoder.rutas_mcturistic.view.fragment.Fragment_Sitios.PictureDetailActivity;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.ArrayList;

/**
 * Created by Luis Puc on 23/03/2017.
 */


public class AdatarFotosEventos extends RecyclerView.Adapter<AdatarFotosEventos.PictureViewHolder> {



    private ArrayList<Eventos> objServicios;
    private int resource;
    private Activity activity;
    private  boolean entrar = false;

    private String NombreServicio;
    private String Precio;
    private String LikeNumero;
    private String Historia;
    public String FotoServicio;

    public String Nombre;
    public String FotoUser;
    public String id;




    public AdatarFotosEventos(ArrayList<Eventos> objEventos, int resource, Activity activity) {
        this.objServicios = objEventos;
        this.resource = resource;
        this.activity = activity;
    }

    @Override
    public PictureViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(resource, parent, false);
        return new PictureViewHolder(view);
    }

    @Override
    //Se encarga de asignar los nombre y variables necesarias
    public void onBindViewHolder(final PictureViewHolder holder, int position) {

        final Eventos objEven = objServicios.get(position);
        holder.usernameCard.setText(objEven.getNombreEvent());
        holder.precios.setText("03/23/2017");
        holder.likeNumberCard.setText(objEven.getHoraInicio());

        byte[] decodeString = Base64.decode(objEven.getFotoEvento(),Base64.DEFAULT);

        Bitmap decoded = BitmapFactory.decodeByteArray(decodeString,0,decodeString.length);
        holder.pictureCard.setImageBitmap(decoded);

        byte[] decodeString1= Base64.decode(objEven.getFotoUser(),Base64.DEFAULT);
        Bitmap decoded1 = BitmapFactory.decodeByteArray(decodeString1,0,decodeString1.length);
        holder.avatar.setImageBitmap(decoded1);
        //Picasso.with(activity).load(picture.getPicture()).into(holder.pictureCard);

        //
        //Para el detalle del Sitio
        holder.pictureCard.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {


                NombreServicio = objEven.getNombreEvent();
                Precio = objEven.getFechaIncio().toString();
                LikeNumero ="Hora Inicio: "+objEven.getHoraInicio();
                FotoServicio = objEven.getFotoEvento();
                Nombre = objEven.getNombreUser();
                FotoUser = objEven.getFotoUser();


                Intent intent = new Intent(activity, DetalleServicio.class);
                intent.putExtra("NombreServicio",NombreServicio);
                intent.putExtra("Precio",Precio);
                intent.putExtra("LikeNumero",LikeNumero);
                intent.putExtra("FotoServicio",FotoServicio);
                intent.putExtra("Nombre",Nombre);
                intent.putExtra("Apellidos","");
                intent.putExtra("FotoUser",FotoUser);
                intent.putExtra("FechaInicio",objEven.getFechaIncio());
                intent.putExtra("Longitud",objEven.getLongitud());
                intent.putExtra("Latitud",objEven.getLatitud());
                activity.startActivity(intent);

                /*
                //Asignamos el nombre del Método de la WebServices
                String strAccion = "Wver_sitiosMovil_id";
                //Pasamos el parámetro de la URL de la WebServices.
                String strUrl = "http://wsmcturistic.azurewebsites.net/UI/WsMCTuristic.asmx/";
                //Unimos las URL y Agregamos el valor que se le va asignar la petición
                String UrlWebService = strUrl + strAccion + "?id="+holder.codigo_sitio.getText();
                //LLamamos la clase JSONTask se encargara de Realizar la apertura y cierre de la WebServices
                new AdaptarFotosServicios.JSONTask().execute(UrlWebService);
                //Asignamos los parametros obtenidos del CardView que se selecciono pasandolo a variables locales.
                id = holder.codigo_sitio.getText().toString();
                Foto = objSitio.getFoto();
                */
                /*
                //Método para versiones anteriores a la 5.1.0
                Intent intent = new Intent(activity, PictureDetailActivity.class);
                intent.putExtra("id",holder.codigo_sitio.getText());
                intent.putExtra("Foto",objSitio.getFoto());


                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP){
                    Explode explode = new Explode();
                    explode.setDuration(1000);
                    activity.getWindow().setExitTransition(explode);
                    activity.startActivity(intent,
                            ActivityOptionsCompat.makeSceneTransitionAnimation(activity, view, activity.getString(R.string.transitionname_picture)).toBundle());

                }else {
                    activity.startActivity(inte;nt)
                }
                */


            }
        });
    }

    @Override
    public int getItemCount() {
        return objServicios.size();
    }

    public class PictureViewHolder extends RecyclerView.ViewHolder{

        private ImageView pictureCard,avatar;
        private TextView usernameCard;
        private TextView codigo_sitio;
        private TextView precios;
        private TextView likeNumberCard;


        public PictureViewHolder(View itemView) {
            super(itemView);

            avatar     = (ImageView) itemView.findViewById(R.id.avatar);
            pictureCard     = (ImageView) itemView.findViewById(R.id.imagen);
            usernameCard    = (TextView) itemView.findViewById(R.id.titulo_imagen);
            precios        = (TextView) itemView.findViewById(R.id.PreciosServicio);
            likeNumberCard  = (TextView) itemView.findViewById(R.id.noLikes);

        }
    }


    //Clase para generar el Detalle
    class JSONTask extends AsyncTask<String,String,String> {
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
                /*
                ArrayList<Sitios> objtSitios = new ArrayList<>();
                String Datos = Resultado;
                JSONArray ResultadosArray = null;
                try {
                    ResultadosArray = new JSONArray(Datos);
                    for(int i = 0; i < ResultadosArray.length();i++){
                        JSONObject object = ResultadosArray.getJSONObject(i);
                        Nombre = object.getString("Nombre");
                        objtSitios.add(new Sitios(object.getString("Código"), object.getString("Nombre"), object.getString("Descripción"), object.getString("Sucesosimportantes"), object.getString("Historia"), object.getString("Dirección"), object.getDouble("Latitud"), object.getDouble("Longitud"), object.getInt("idTipoSitio")
                        ));
                    }

                }
                catch (JSONException e){
                    e.printStackTrace();
                }*/

                //Instanciamos la clase PictureDetailActivity para ingresar a los Detalles Del CardView.
                Intent intent = new Intent(activity, PictureDetailActivity.class);
                //Pasamos los parámetros locales a la actividad Detalle
                intent.putExtra("id",id);
                intent.putExtra("Foto",FotoServicio);
                intent.putExtra("ResuldatosArray",Resultado);
                //Iniciamos la actividad
                activity.startActivity(intent);

            }
            catch (Exception t){
                // Throwable t
                t.printStackTrace();
                // Toast.makeText(PictureDetailActivity.this,t.getMessage(), Toast.LENGTH_LONG).show();
            }
        }
    }
}

