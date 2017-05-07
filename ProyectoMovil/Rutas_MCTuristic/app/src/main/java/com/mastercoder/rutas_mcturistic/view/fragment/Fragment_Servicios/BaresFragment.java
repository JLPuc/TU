package com.mastercoder.rutas_mcturistic.view.fragment.Fragment_Servicios;


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
import android.widget.ProgressBar;

import com.mastercoder.rutas_mcturistic.R;
import com.mastercoder.rutas_mcturistic.adapter.AdaptadorFotos;
import com.mastercoder.rutas_mcturistic.adapter.AdaptarFotosServicios;
import com.mastercoder.rutas_mcturistic.model.Servicios;
import com.mastercoder.rutas_mcturistic.model.Sitios;

import java.util.ArrayList;

/**
 * A simple {@link Fragment} subclass.
 */
public class BaresFragment extends Fragment {
    LinearLayoutManager layoutManager;
    ArrayList<Servicios> objServicios = new ArrayList<>();
    String NombreBar;

    public BaresFragment() {
        // Required empty public constructor
    }

    public BaresFragment( ArrayList<Servicios> Servicos,String NombreTab) {
        // Required empty public constructor
        this.objServicios = Servicos;
        this.NombreBar = NombreTab;
    }
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment


        View view = inflater.inflate(R.layout.fragment_bares, container, false);
        showToolbar(NombreBar, false, view);
        RecyclerView picturesRecycler = (RecyclerView) view.findViewById(R.id.reciclador);


        LinearLayoutManager linearLayoutManager = new LinearLayoutManager(getContext());
        linearLayoutManager.setOrientation(LinearLayoutManager.VERTICAL);

        picturesRecycler.setLayoutManager(linearLayoutManager);


        AdaptarFotosServicios pictureAdapterRecyclerView =
                //Asigna el el objeto que llega y se lo asigna
                new AdaptarFotosServicios(objServicios, R.layout.item_galeria_fotos, getActivity());
        picturesRecycler.setAdapter(pictureAdapterRecyclerView);


        return view;

    }


    public void showToolbar(String tittle, boolean upButton, View view){
        Toolbar toolbar = (Toolbar) view.findViewById(R.id.toolbar);
        ((AppCompatActivity) getActivity()).setSupportActionBar(toolbar);
        ((AppCompatActivity) getActivity()).getSupportActionBar().setTitle(tittle);
        ((AppCompatActivity) getActivity()).getSupportActionBar().setDisplayHomeAsUpEnabled(upButton);

    }

}
