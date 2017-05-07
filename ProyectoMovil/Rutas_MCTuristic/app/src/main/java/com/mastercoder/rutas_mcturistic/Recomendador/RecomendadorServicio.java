package com.mastercoder.rutas_mcturistic.Recomendador;

import android.content.Context;
import android.content.SharedPreferences;
import android.speech.tts.TextToSpeech;

import com.mastercoder.rutas_mcturistic.TextToSpeech.ReproducirTextoServicio;

import java.util.Date;

/**
 * Created by Andre on 09/03/2017.
 */

public class RecomendadorServicio {

    public static final String MyPreferences = "MiPreferencia";
    private boolean statusManana = false;
    private boolean statusTarde = false;
    private boolean statusNoche = false;
    private Context context;
    ReproducirTextoServicio servicio;
    private String tipo;
    SharedPreferences preferencias;

    public void iniciarServiciosRecomendador(Context c, ReproducirTextoServicio rts){
        preferencias = c.getSharedPreferences(MyPreferences, Context.MODE_PRIVATE);
        context = c;
        servicio = rts;
        situaciones();

    }

    public void setTextToSpeech(TextToSpeech ts){}

    private void situaciones(){
        String Texto;
        Date fecha = new Date();
        verPreferencias();
        if (!statusManana){
            if (fecha.getHours() == 8 || fecha.getHours() == 9 || fecha.getHours() == 10){
                Texto = "¿Ya desayunaste?";
                tipo = "Comida";
                servicio.reproducirTextoServicio(fecha.getHours(),fecha.getMinutes(), fecha.getSeconds(), Texto, context, tipo);
                statusManana = true;
            }
        }
        if (!statusTarde){
            if (fecha.getHours() == 13 || fecha.getHours() == 14 || fecha.getHours() == 15){
                Texto = "¿Ya almorzaste?";
                tipo = "Comida";
                servicio.reproducirTextoServicio(fecha.getHours(),fecha.getMinutes(), fecha.getSeconds(), Texto, context, tipo);
                statusTarde = true;
            }
        }
        if (!statusNoche){
            if (fecha.getHours() == 18 || fecha.getHours() == 19 || fecha.getHours() == 20 || fecha.getHours() == 21){
                Texto = "¿Ya cenaste?";
                tipo = "Comida";
                servicio.reproducirTextoServicio(fecha.getHours(),fecha.getMinutes(), fecha.getSeconds(), Texto, context, tipo);
                statusNoche = true;
            }
        }
        if (fecha.getHours() == 0) {
            statusManana = false;
            statusTarde = false;
            statusNoche = false;
        }
        guardarPreferencias();
    }

    private void guardarPreferencias() {
        try {
            SharedPreferences.Editor editor = preferencias.edit();
            if (statusManana){editor.putInt("manana", 1);
            } else {editor.putInt("manana", 0);}
            if (statusTarde){editor.putInt("tarde", 1);
            } else {editor.putInt("tarde", 0);}
            if (statusNoche){editor.putInt("noche", 1);
            } else {editor.putInt("noche", 0);}
            editor.commit();
            //Toast.makeText(this, "Datos guardados", Toast.LENGTH_LONG).show();
        }catch (Exception c){
            //Toast.makeText(this, "Error al guardar", Toast.LENGTH_LONG).show();
        }
    }

    private void verPreferencias() {
        try {
            if (preferencias.getInt("manana", 1) == 1){
                statusManana = true;
            } else {
                statusManana = false;
            }
            if (preferencias.getInt("tarde", 1) == 1){
                statusTarde = true;
            } else {
                statusTarde = false;
            }
            if (preferencias.getInt("noche", 1) == 1){
                statusNoche = true;
            } else {
                statusNoche = false;
            }
        }catch (Exception c){
            //Toast.makeText(this, "Error al cargar los datos", Toast.LENGTH_LONG).show();
        }
    }


}
