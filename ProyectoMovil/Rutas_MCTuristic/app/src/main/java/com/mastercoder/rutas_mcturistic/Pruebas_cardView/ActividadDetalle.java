package com.mastercoder.rutas_mcturistic.Pruebas_cardView;

import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import com.bumptech.glide.Glide;
import com.mastercoder.rutas_mcturistic.R;

public class ActividadDetalle extends AppCompatActivity {

      @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_actividad_detalle);
        getWindow().getDecorView().setSystemUiVisibility(
                View.SYSTEM_UI_FLAG_LAYOUT_STABLE | View.SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN);

        anadirToolbar();

        int posicion = getIntent().getIntExtra(ActividadPrincipal.EXTRA_POSICION, -1);

        Foto itemSeleccionado = Foto.FOTOS.get(posicion);

        TextView titulo = (TextView) findViewById(R.id.titulo_imagen);
        ImageView avatar = (ImageView) findViewById(R.id.avatar);
        ImageView foto = (ImageView) findViewById(R.id.foto);
        TextView usuario = (TextView) findViewById(R.id.texto_marca_usuario);
        TextView tiempoExistencia = (TextView) findViewById(R.id.tiempoExistencia);
        TextView noComentario = (TextView) findViewById(R.id.noComentarios);
        TextView noLikes = (TextView) findViewById(R.id.noLikes);

        Glide.with(this).load(itemSeleccionado.getIdImagen()).into(foto);
        Glide.with(this).load(itemSeleccionado.getIdAvatarUsuario()).into(avatar);
        titulo.setText(itemSeleccionado.getTitulo());
        usuario.setText(getString(R.string.marca_usuario, itemSeleccionado.getUsuario()));
        tiempoExistencia.setText(itemSeleccionado.getTiempoDeExistencia());
        noComentario.setText(getString(R.string.comentarios_formato, itemSeleccionado.getNoComentarios()));
        noLikes.setText(getString(R.string.likes_formato, itemSeleccionado.getNoLikes()));
    }

    private void anadirToolbar() {
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        ActionBar actionBar = getSupportActionBar();
        if (actionBar != null) {
            actionBar.setDisplayHomeAsUpEnabled(true);
            actionBar.setDisplayShowTitleEnabled(false);
        }

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.actividad_detalle, menu);
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
}
