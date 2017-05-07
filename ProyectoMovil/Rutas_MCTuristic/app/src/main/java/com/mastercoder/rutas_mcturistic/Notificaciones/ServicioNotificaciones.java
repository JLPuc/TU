package com.mastercoder.rutas_mcturistic.Notificaciones;


import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.media.RingtoneManager;
import android.net.Uri;
import android.support.v4.app.NotificationCompat;
import android.util.Log;

import com.google.firebase.messaging.FirebaseMessagingService;
import com.google.firebase.messaging.RemoteMessage;
import com.mastercoder.rutas_mcturistic.view.EventosMain;


/**
 * Created by Andre on 07/03/2017.
 */

public class ServicioNotificaciones extends FirebaseMessagingService {
    public static final String TAG = "NOTICIAS";

    // Método que se ejecuta cuando un mensaje es recibido
    @Override
    public void onMessageReceived(RemoteMessage remoteMessage) {
        super.onMessageReceived(remoteMessage);

        String from = remoteMessage.getFrom(); // Se obtienen los datos de dónde proviene el mensaje
        Log.d(TAG, "Mensaje recibido de: " + from);

        if (remoteMessage.getNotification() != null) {
            Log.d(TAG, "Notificación: " + remoteMessage.getNotification().getBody());

            // Se llama al método para mostrar la notificación
            // Obtiene los parámetros de título y cuerpo que contiene la notificación recibida
            mostrarNotificacion(remoteMessage.getNotification().getTitle(), remoteMessage.getNotification().getBody());
        }

        if (remoteMessage.getData().size() > 0) {
            Log.d(TAG, "Data: " + remoteMessage.getData());
        }

    }


    // Método para mostrar la notificación, recibe el título y cuerpo de la notificación
    private void mostrarNotificacion(String title, String body) {

        // Se declara un Intent con el contexto de la clase actual y de la clase principal (formulario)
        Intent intent = new Intent(this, EventosMain.class);
        // Se declara la acción que realizará la notificación
        // En este caso abrirá la aplicación de nuevo
        intent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
        // Se asigna la actividad que se ejecutará cuando se le dé clic en la notificación
        PendingIntent pendingIntent = PendingIntent.getActivity(this, 0, intent, PendingIntent.FLAG_ONE_SHOT);

        // Se declara el tipo de sonido que realizará cuando la notificación sea recibida
        Uri soundUri = RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION);

        // Se crea la notificación y se le asignan valores a sus atributos
        NotificationCompat.Builder notificationBuilder = new NotificationCompat.Builder(this)
                .setContentTitle(title) // Título
                .setContentText(body) // Cuerpo (Texto de la notificación)
                .setAutoCancel(true) // Para desaparecer la notificación cuando se le dé clic
                .setSound(soundUri) // Sonido que se emitirá
                .setContentIntent(pendingIntent); // Abre la actividad asignada

        // Asigna el contexto del sistema para el funcionamiento de la notificación
        NotificationManager notificationManager = (NotificationManager) getSystemService(Context.NOTIFICATION_SERVICE);
        // Genera la notificación y la muestra
        notificationManager.notify(0, notificationBuilder.build());

    }
}
