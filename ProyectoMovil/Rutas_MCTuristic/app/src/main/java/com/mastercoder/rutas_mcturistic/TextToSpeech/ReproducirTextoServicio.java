package com.mastercoder.rutas_mcturistic.TextToSpeech;

import android.content.Context;
import android.speech.tts.TextToSpeech;
import android.support.v7.app.AppCompatActivity;

import com.mastercoder.rutas_mcturistic.Temporizador.*;

import java.util.Locale;

/**
 * Created by Andre on 08/03/2017.
 */

public class ReproducirTextoServicio extends AppCompatActivity implements TextToSpeech.OnInitListener {

    // Variables necesarias para que el servicio funcione
    TemporizadorTTS temp;
    private TextToSpeech mTts;
    private int HORA, MINUTO, SEGUNDO;
    private String TEXTO;

    public  ReproducirTextoServicio(){
    }
    // Constructor que recibe la hora, el minuto y el segundo específicos en el que se reproducirá el texto
    // Al igual recibe el Texto a reproducir y el Contexto del formulario que lo llama
    public void reproducirTextoServicio(int hora, int minuto, int segundo, String Texto, Context contexto, String tipo) {
        HORA = hora;
        MINUTO = minuto;
        SEGUNDO = segundo;
        TEXTO = Texto;
        temp = new TemporizadorTTS();

        // Se llama al método temp para dar inicio al TemporizadorTTS
        temp.temp(this, HORA, MINUTO,SEGUNDO, TEXTO, mTts, contexto, tipo);
    }

    public void reproducirSoloTexto(Context contexto, String texto, String tipo){
        // Del Contexto del formulario que llama al método y el Contexto de la clase actual
        mTts = new TextToSpeech(contexto, ReproducirTextoServicio.this);
        // Se asigna el lenguaje del reproductor dependiendo del lenguaje del dispositivo móvil
        mTts.setLanguage(new Locale(Locale.getDefault().getLanguage()));

        temp = new TemporizadorTTS();

        temp.soloTexto(this,texto, mTts, contexto, tipo);
    }

    public void reproducirAhora(Context contexto, String texto, String tipo){
        // Del Contexto del formulario que llama al método y el Contexto de la clase actual
        mTts = new TextToSpeech(contexto, ReproducirTextoServicio.this);
        // Se asigna el lenguaje del reproductor dependiendo del lenguaje del dispositivo móvil
        mTts.setLanguage(new Locale(Locale.getDefault().getLanguage()));

        temp = new TemporizadorTTS();

        temp.temp(this,texto, mTts, contexto, tipo);
    }


    public void reproducirSituaciones(Context contexto){

        // Del Contexto del formulario que llama al método y el Contexto de la clase actual
        mTts = new TextToSpeech(contexto, ReproducirTextoServicio.this);
        // Se asigna el lenguaje del reproductor dependiendo del lenguaje del dispositivo móvil
        mTts.setLanguage(new Locale(Locale.getDefault().getLanguage()));

        TemporizadorSituaciones TS = new TemporizadorSituaciones();
        TS.temp(contexto, mTts, ReproducirTextoServicio.this);
    }

    @Override
    public void onInit(int i) {

    }

}
