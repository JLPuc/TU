package com.mastercoder.rutas_mcturistic.Temporizador;

import android.annotation.SuppressLint;
import android.annotation.TargetApi;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.os.Build;
import android.os.CountDownTimer;
import android.speech.tts.TextToSpeech;

import com.mastercoder.rutas_mcturistic.MainActivity;
import com.mastercoder.rutas_mcturistic.Recomendador.RecomendadorServicio;
import com.mastercoder.rutas_mcturistic.TextToSpeech.ReproducirTextoServicio;

import java.util.Date;

/**
 * Created by Andre on 09/03/2017.
 */

public class TemporizadorSituaciones extends BroadcastReceiver {
    // Declaración de variables necesarias para que funcione correctamente el TemporizadorTTS
    int segundos,minutos,horas, Resultado;
    CounterClass timer;
    Date tiempo;
    Context context;
    String Texto;
    TextToSpeech TTS;
    RecomendadorServicio RS;
    Boolean ajustado = false;
    ReproducirTextoServicio RTS;

    public TemporizadorSituaciones() {
        RS = new RecomendadorServicio();
    }

    // De este método depende la herencia
    @Override
    public void onReceive(Context context, Intent intent)  {
        Intent actividadALanzar = new Intent(context, MainActivity.class);
        context.startActivity(actividadALanzar);
    }


    // Método que asigna valores y operaciones para determinar cuánto tiempo falta para que se reproduzca el audio
    public void temp(Context cont, TextToSpeech tts, ReproducirTextoServicio rts) {

        // TODO Auto-generated method stub
        context = cont; // asignación del formulario principal
        TTS = tts; // Asignación de la variable TextToSpeech creada en la clase que llama a este método
        RTS = rts;
        RS.iniciarServiciosRecomendador(context, RTS);

        // Instancia de objeto CounterClass y los parámetros de tiempo faltante y por cada cuanto tiempo se realiza un Tick
        timer = new CounterClass(2000, 1000);
        timer.start(); // Inicio del contador (TemporizadorTTS)

    }


    // Creación de una cláse pública que servirá para simular el TemporizadorTTS
    @TargetApi(Build.VERSION_CODES.GINGERBREAD)
    @SuppressLint("NewApi")
    public class CounterClass extends CountDownTimer {

        // Constructor que recibe los parámetros de tiempo faltante y el intervalo del tiempo (cada cuando se realiza un Tick)
        public CounterClass(long millisInFuture, long countDownInterval) {
            super(millisInFuture, countDownInterval);
            // TODO Auto-generated constructor stub
        }

        @SuppressLint("NewApi")
        @TargetApi(Build.VERSION_CODES.GINGERBREAD)
        @Override
        public void onTick(long millisUntilFinished) {
            // TODO Auto-generated method stub
            long millis = millisUntilFinished;

        }

        @Override
        public void onFinish() {
            // TODO Auto-generated method stub
            if (ajustado == true){
                ajustado = false;
                RS.iniciarServiciosRecomendador(context, RTS);
            }
            if (ajustado == false){
                Resultado = (3600000 * 24) ;
                timer = new CounterClass(Resultado, 900000);
                timer.start();
                ajustado = true;
            }
        }
    }
}
