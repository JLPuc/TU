package com.mastercoder.rutas_mcturistic.view.fragment;

import android.app.Activity;
import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.DialogFragment;
import android.os.Build;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.Toast;

import java.util.Calendar;
import com.mastercoder.rutas_mcturistic.R;
import com.mastercoder.rutas_mcturistic.adapter.PictureAdapterRecyclerView;
import com.mastercoder.rutas_mcturistic.model.Calendario;
import com.mastercoder.rutas_mcturistic.model.Sitios;

import java.util.ArrayList;

/**
 * A simple {@link Fragment} subclass.
 */
public class ProfileFragment extends Fragment {

    ArrayList<Sitios> objSitios = new ArrayList<>();
    public ProfileFragment() {
        // Required empty public constructor
    }
    public ProfileFragment(ArrayList<Sitios> Arrsy) {
        // Required empty public constructor
        objSitios = Arrsy;
    }



    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        final View view = inflater.inflate(R.layout.fragment_profile, container, false);
        RecyclerView picturesRecycler = (RecyclerView) view.findViewById(R.id.picturesProfileRecycler);

        LinearLayoutManager linearLayoutManager = new LinearLayoutManager(getContext());
        linearLayoutManager.setOrientation(LinearLayoutManager.VERTICAL);

        picturesRecycler.setLayoutManager(linearLayoutManager);

        PictureAdapterRecyclerView pictureAdapterRecyclerView =
                new PictureAdapterRecyclerView(objSitios, R.layout.cardview_picture, getActivity());
        picturesRecycler.setAdapter(pictureAdapterRecyclerView);


        Spinner s =(Spinner) view.findViewById(R.id.tiposito_spinner);

        s.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                //Por si el frawmen entra de nuevo.

            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });
        return view;


    }





}
