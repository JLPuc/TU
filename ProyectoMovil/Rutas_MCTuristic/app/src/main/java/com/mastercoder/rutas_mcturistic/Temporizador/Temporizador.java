package com.mastercoder.rutas_mcturistic.Temporizador;

import android.annotation.SuppressLint;
import android.annotation.TargetApi;
import android.content.Context;
import android.os.Build;
import android.os.CountDownTimer;

import com.mastercoder.rutas_mcturistic.TextToSpeech.ReproducirTextoServicio;

/**
 * Created by Andre on 23/03/2017.
 */

public class Temporizador {

    CounterClass timer;
    String Texto, tipo;
    Context context;

    public void temp(Context cont, String txt, String tp) {
        Texto = txt;
        tipo = tp;
        context = cont;
        // Instancia de objeto CounterClass y los parámetros de tiempo faltante y por cada cuanto tiempo se realiza un Tick
        timer = new CounterClass(15000, 1000);
        timer.setContexto(cont);
        timer.start(); // Inicio del contador (TemporizadorTTS)

    }

    public void tempMap(Context cont, String txt, String tp) {
        Texto = txt;
        tipo = tp;
        context = cont;
        // Instancia de objeto CounterClass y los parámetros de tiempo faltante y por cada cuanto tiempo se realiza un Tick
        timer = new CounterClass(20000, 1000);
        timer.setContexto(cont);
        timer.start(); // Inicio del contador (TemporizadorTTS)

    }


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
            ReproducirTextoServicio rts = new ReproducirTextoServicio();
            rts.reproducirAhora(context,Texto, tipo);
        }



    }
}
