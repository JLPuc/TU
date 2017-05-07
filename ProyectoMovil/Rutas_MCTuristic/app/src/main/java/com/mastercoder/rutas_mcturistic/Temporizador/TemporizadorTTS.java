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

import java.util.Date;

/**
 * Created by Andre on 06/03/2017.
 */

public class TemporizadorTTS extends BroadcastReceiver {

    // Declaración de variables necesarias para que funcione correctamente el TemporizadorTTS
    int segundos,minutos,horas, Resultado;
    CounterClass timer;
    Date tiempo;
    Context context, formulario;
    String Texto, tipo;
    Boolean action = false;
    TextToSpeech TTS;

    // De este método depende la herencia
    @Override
    public void onReceive(Context context, Intent intent)  {
        Intent actividadALanzar = new Intent(context, MainActivity.class);
        context.startActivity(actividadALanzar);
    }

    public void soloTexto(Context cont,String txt, TextToSpeech tts, Context frm, String tp) {
        tipo = tp;
        formulario = frm;
        context = cont; // asignación del formulario principal
        TTS = tts; // Asignación de la variable TextToSpeech creada en la clase que llama a este método
        Texto = txt; // Texto que se reproducirá
        action = true;
        // Instancia de objeto CounterClass y los parámetros de tiempo faltante y por cada cuanto tiempo se realiza un Tick
        timer = new CounterClass(1000, 1000);
        timer.setContexto(context);
        timer.start(); // Inicio del contador (TemporizadorTTS)

    }

    public void temp(Context cont,String txt, TextToSpeech tts, Context frm, String tp) {
        tipo = tp;
        formulario = frm;
        context = cont; // asignación del formulario principal
        TTS = tts; // Asignación de la variable TextToSpeech creada en la clase que llama a este método
        Texto = txt; // Texto que se reproducirá

        // Instancia de objeto CounterClass y los parámetros de tiempo faltante y por cada cuanto tiempo se realiza un Tick
        timer = new CounterClass(1000, 1000);
        timer.setContexto(context);
        timer.start(); // Inicio del contador (TemporizadorTTS)

    }

    // Método que asigna valores y operaciones para determinar cuánto tiempo falta para que se reproduzca el audio
    public void temp(Context cont, int h, int m, int s, String txt, TextToSpeech tts, Context frm, String tp) {
        tipo = tp;
        formulario = frm;
        // TODO Auto-generated method stub
        context = cont; // asignación del formulario principal
        TTS = tts; // Asignación de la variable TextToSpeech creada en la clase que llama a este método
        tiempo = new Date(); // Creación de variable Date para detección de la hora, los minutos y segundos actuales
        Texto = txt; // Texto que se reproducirá
        segundos = s * 1000; // Conversión de los segundos
        minutos = m * 60000; // Conversión de los minutos
        horas = h * 3600000; // Conversión de las horas

        // Operación para determinar el tiempo faltante para la reproducción
        Resultado = (horas + minutos + segundos) - ((tiempo.getHours() * 3600000) + (tiempo.getMinutes() * 60000) + (tiempo.getSeconds() * 1000));

        // Instancia de objeto CounterClass y los parámetros de tiempo faltante y por cada cuanto tiempo se realiza un Tick
        timer = new CounterClass(1000, 1000);
        timer.setContexto(context);
        timer.start(); // Inicio del contador (TemporizadorTTS)

    }


    // Creación de una cláse pública que servirá para simular el TemporizadorTTS
    @TargetApi(Build.VERSION_CODES.GINGERBREAD)
    @SuppressLint("NewApi")
    public class CounterClass extends CountDownTimer {

        Context contexto;

        public void setContexto(Context context){
            contexto = context;
        }

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
            // Al finalizar el tiempo, se declara un objeto de la clase Reproducir texto y se llama al método que reproduce el texto recibido


            /*ReproducirTexto rt = new ReproducirTexto();
            // El método recibe los parámetros del Texto (String) y del TTS (TextToSpeech) para funcionar
            rt.reproducirTexto(Texto, TTS);
            if (action == false) {
                rt.mostrarDialogoComida(Texto, formulario, tipo);
            }*/

        }



    }
}
