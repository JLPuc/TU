package com.mastercoder.rutas_mcturistic.model;

import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.DialogFragment;
import android.os.Bundle;
import android.widget.DatePicker;
import android.widget.TextView;

import com.mastercoder.rutas_mcturistic.R;

import java.util.Calendar;

/**
 * Created by Luis Puc on 21/03/2017.
 */

public class Calendario extends DialogFragment implements DatePickerDialog.OnDateSetListener {

    @Override
    public Dialog onCreateDialog(Bundle savedInstanceState) {
        final Calendar c = Calendar.getInstance();
        int year = c.get(Calendar.YEAR);
        int month = c.get(Calendar.MONTH);
        int day = c.get(Calendar.DAY_OF_MONTH);

        return new DatePickerDialog(getActivity(), this, year, month, day);
    }

    public void onDateSet(DatePicker view, int year, int month, int day) {
       TextView tv1= (TextView) getActivity().findViewById(R.id.Datetxt);
        String Date = view.getDayOfMonth()+"/"+view.getMonth()+"/"+view.getYear();

    }
}
