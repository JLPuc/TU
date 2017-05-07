package com.mastercoder.rutas_mcturistic.view.fragment.Fragment_Eventos;


import android.content.res.Configuration;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.Toolbar;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.mastercoder.rutas_mcturistic.R;
import com.mastercoder.rutas_mcturistic.adapter.AdaptarFotosServicios;
import com.mastercoder.rutas_mcturistic.adapter.AdatarFotosEventos;
import com.mastercoder.rutas_mcturistic.model.Eventos;
import com.mastercoder.rutas_mcturistic.model.Servicios;

import java.util.ArrayList;

/**
 * A simple {@link Fragment} subclass.
 */
public class EventosFragment extends Fragment {
    ArrayList<Eventos> objEventos= new ArrayList<>();
    String NombreBar;
    public EventosFragment() {
        // Required empty public constructor
    }

    public EventosFragment( ArrayList<Eventos> Eventos) {
        // Required empty public constructor
        this.objEventos = Eventos;

    }

    LinearLayoutManager layoutManager;


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_eventos, container, false);
        showToolbar("Eventos", false, view);

        RecyclerView picturesRecycler = (RecyclerView) view.findViewById(R.id.reciclador);

        /*
        LinearLayoutManager linearLayoutManager = new LinearLayoutManager(getContext());
        linearLayoutManager.setOrientation(LinearLayoutManager.VERTICAL);

        picturesRecycler.setLayoutManager(linearLayoutManager);
*/

        AdatarFotosEventos pictureAdapterRecyclerView =
                //Asigna el el objeto que llega y se lo asigna
                new AdatarFotosEventos(objEventos, R.layout.item_galeria, getActivity());
        picturesRecycler.setAdapter(pictureAdapterRecyclerView);


        //Se encarga de Verificar Si la orientación cambia con forme al movimiento del teléfono
        if (getResources().getConfiguration().orientation == Configuration.ORIENTATION_LANDSCAPE)
            //Si es asi crea un Gridview con dos espacios y los adapta.
            layoutManager = new GridLayoutManager(getContext(), 2);
        else
            layoutManager = new LinearLayoutManager(getContext());
        picturesRecycler.setLayoutManager(layoutManager);

        return view;
    }

    @Override
    public void onPause() {
        super.onPause();
    }

    public void showToolbar(String tittle, boolean upButton, View view){
        Toolbar toolbar = (Toolbar) view.findViewById(R.id.toolbar);
        ((AppCompatActivity) getActivity()).setSupportActionBar(toolbar);
        ((AppCompatActivity) getActivity()).getSupportActionBar().setTitle(tittle);
        ((AppCompatActivity) getActivity()).getSupportActionBar().setDisplayHomeAsUpEnabled(upButton);


    }










}
