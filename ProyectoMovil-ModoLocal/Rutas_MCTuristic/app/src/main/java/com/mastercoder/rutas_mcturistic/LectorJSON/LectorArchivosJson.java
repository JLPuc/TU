package com.mastercoder.rutas_mcturistic.LectorJSON;

import android.content.Context;

import java.io.IOException;
import java.io.InputStream;

/**
 * Created by André on 09/04/2017.
 */

public class LectorArchivosJson {

    Context contexto;

    public LectorArchivosJson(Context cont){
        contexto = cont;
    }

    public String leerArchivoJSON(String flName) {
        String json = null;
        try {
            InputStream is = contexto.getAssets().open(flName);
            int size = is.available();
            byte[] buffer = new byte[size];
            is.read(buffer);
            is.close();
            json = new String(buffer, "UTF-8");
        } catch (IOException ex) {
            ex.printStackTrace();
            return null;
        }
        return json;
    }

}
