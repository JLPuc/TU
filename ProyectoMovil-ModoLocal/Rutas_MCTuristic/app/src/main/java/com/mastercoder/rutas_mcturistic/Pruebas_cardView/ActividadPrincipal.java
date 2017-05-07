package com.mastercoder.rutas_mcturistic.Pruebas_cardView;

import android.content.Intent;
import android.content.res.Configuration;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;

import com.mastercoder.rutas_mcturistic.R;
import com.mastercoder.rutas_mcturistic.adapter.AdaptadorFotos;

public class ActividadPrincipal extends AppCompatActivity
        implements AdaptadorFotos.EscuchaEventosClick {

    public static final String EXTRA_POSICION = "com.mastercoder.rutas_mcturistic.extra.POSICION";

    RecyclerView reciclador;
    LinearLayoutManager layoutManager;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_actividad_principal);

        anadirToolbar();

        reciclador = (RecyclerView) findViewById(R.id.reciclador);

        if (getResources().getConfiguration().orientation == Configuration.ORIENTATION_LANDSCAPE)
            layoutManager = new GridLayoutManager(this, 2);
        else
            layoutManager = new LinearLayoutManager(this);

        reciclador.setLayoutManager(layoutManager);

        AdaptadorFotos adaptador = new AdaptadorFotos(this);
        reciclador.setAdapter(adaptador);

    }

    private void anadirToolbar() {
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.actividad_principal, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id = item.getItemId();

        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    @Override
    public void onItemClick(AdaptadorFotos.ViewHolder holder, int posicion) {
        Intent intent = new Intent(this, ActividadDetalle.class);
        intent.putExtra(EXTRA_POSICION, posicion);
        startActivity(intent);
    }
}
