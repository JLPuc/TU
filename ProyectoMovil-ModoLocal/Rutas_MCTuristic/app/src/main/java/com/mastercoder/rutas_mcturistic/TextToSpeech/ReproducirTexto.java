package com.mastercoder.rutas_mcturistic.TextToSpeech;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.speech.tts.TextToSpeech;

import com.mastercoder.rutas_mcturistic.MainActivity;
import com.mastercoder.rutas_mcturistic.view.Maps.Maps;
import com.mastercoder.rutas_mcturistic.view.ProductosMain;

/**
 * Created by Andre on 07/03/2017.
 */

public class ReproducirTexto {

    private TextToSpeech mTts; // Declaración de una variable TextToSpeech

    // Método para reproducir el texto deseado
    public void reproducirTexto(String Texto, TextToSpeech tts) {
        mTts = tts; // Asignación del valor del TextToSpeech
        mTts.speak(Texto, TextToSpeech.QUEUE_FLUSH, null); // Reproducción del texto
    }

    public void mostrarDialogoComida(String texto, final Context context, final String tipo){
        AlertDialog.Builder mensaje = new AlertDialog.Builder(context);
        mensaje.setTitle("Pregunta");
        mensaje.setMessage(texto);
        mensaje.setPositiveButton("Sí", new DialogInterface.OnClickListener(){
            @Override
            public void onClick(DialogInterface dialogInterface, int i) {
                if (tipo == "Sitio"){
                    Intent ListSong = new Intent(context, MainActivity.class);
                    context.startActivity(ListSong);
                }
                if (tipo == "Mapa"){
                   try{ Intent ListSong = new Intent(context, Maps.class);
                    context.startActivity(ListSong);}catch (Exception e) {}
                }
            }
        });
        mensaje.setNegativeButton("No", new DialogInterface.OnClickListener(){
            @Override
            public void onClick(DialogInterface dialogInterface, int i) {
                if (tipo == "Comida"){
                    Intent ListSong = new Intent(context, ProductosMain.class);
                    context.startActivity(ListSong);}
            }

        });
        mensaje.show();
    }

}
