package com.mastercoder.rutas_mcturistic.view.fragment;


import android.content.Intent;
import android.content.res.Configuration;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;

import com.mastercoder.rutas_mcturistic.Pruebas_cardView.ActividadDetalle;
import com.mastercoder.rutas_mcturistic.R;
import com.mastercoder.rutas_mcturistic.adapter.AdaptadorFotos;

/**
 * A simple {@link Fragment} subclass.
 */
public class Restaurantes extends Fragment implements AdaptadorFotos.EscuchaEventosClick  {

    public static final String EXTRA_POSICION = "com.mastercoder.rutas_mcturistic.extra.POSICION";
    public Restaurantes() {
        // Required empty public constructor
    }


    LinearLayoutManager layoutManager;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
       View view = inflater.inflate(R.layout.fragment_restaurantes, container, false);
        RecyclerView   reciclador = (RecyclerView) view.findViewById(R.id.reciclador);


        if (getResources().getConfiguration().orientation == Configuration.ORIENTATION_LANDSCAPE)
            layoutManager = new GridLayoutManager(getContext(), 2);
        else
            layoutManager = new LinearLayoutManager(getContext());

        reciclador.setLayoutManager(layoutManager);

        AdaptadorFotos adaptador = new AdaptadorFotos(this);
        reciclador.setAdapter(adaptador);
        return view;
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
        Intent intent = new Intent(getContext(), ActividadDetalle.class);
        intent.putExtra(EXTRA_POSICION, posicion);
        startActivity(intent);
    }
}
