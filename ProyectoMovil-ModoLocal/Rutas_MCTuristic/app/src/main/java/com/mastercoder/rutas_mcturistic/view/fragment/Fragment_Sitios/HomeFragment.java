package com.mastercoder.rutas_mcturistic.view.fragment.Fragment_Sitios;


import android.content.Intent;
import android.content.res.Configuration;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import com.mastercoder.rutas_mcturistic.R;
import com.mastercoder.rutas_mcturistic.adapter.PictureAdapterRecyclerView;

import com.mastercoder.rutas_mcturistic.model.Picture;
import com.mastercoder.rutas_mcturistic.model.Sitios;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.ArrayList;

/**
 * A simple {@link Fragment} subclass.
 */
public class HomeFragment extends Fragment  {

    ArrayList<Sitios> objSitios = new ArrayList<>();

    public HomeFragment() {
        // Required empty public constructor
    }
    public HomeFragment(ArrayList<Sitios> sitiosArry) {
        //Recive un array con los datos de los Sitios.
        objSitios = sitiosArry;
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {


        // Inflate the layout for this fragment
        View view = inflater.inflate(R.layout.fragment_home, container, false);
        showToolbar(getResources().getString(R.string.tab_home), false, view);

        //Instancia el Recycler donde se van a mostrar los CardView.
        RecyclerView picturesRecycler = (RecyclerView) view.findViewById(R.id.pictureRecycler);


        LinearLayoutManager linearLayoutManager = new LinearLayoutManager(getContext());
        //Asigna el tipo de vista para poder ver el CardView
        linearLayoutManager.setOrientation(LinearLayoutManager.VERTICAL);

        picturesRecycler.setLayoutManager(linearLayoutManager);

        PictureAdapterRecyclerView pictureAdapterRecyclerView =
                new PictureAdapterRecyclerView(objSitios, R.layout.cardview_picture, getActivity());
        picturesRecycler.setAdapter(pictureAdapterRecyclerView);


        return view;



    }



  //  public ArrayList<Picture> buidPictures(){

       // ArrayList<Picture> pictures = new ArrayList<>();
        // pictures.add(new Picture("http://www.novalandtours.com/images/guide/guilin.jpg", "Uriel Ramírez", "4 días", "3 Me Gusta"))byte[] picture=
       // pictures.add(new Picture("http://www.en-yucatan.com.mx/fotos/merida/palacio-municipal-merida-yucatan.jpg", "Palacio de Gobierno", "34224 Me gusta", "3445 visitas"));
        //pictures.add(new Picture("http://static.panoramio.com/photos/original/46427992.jpg", "Santa Lucia", "675345 Me gusta", "56R43534 Visitas"));


      //  return pictures;
    //}

    public void showToolbar(String tittle, boolean upButton, View view){
        Toolbar toolbar = (Toolbar) view.findViewById(R.id.toolbar);
        ((AppCompatActivity) getActivity()).setSupportActionBar(toolbar);
        ((AppCompatActivity) getActivity()).getSupportActionBar().setTitle(tittle);
        ((AppCompatActivity) getActivity()).getSupportActionBar().setDisplayHomeAsUpEnabled(upButton);

    }



}




