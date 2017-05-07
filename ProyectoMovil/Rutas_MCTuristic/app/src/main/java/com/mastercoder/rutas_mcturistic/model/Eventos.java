package com.mastercoder.rutas_mcturistic.model;

import java.sql.Date;

/**
 * Created by Luis Puc on 23/03/2017.
 */

public class Eventos {

    private  int idEvento;
    private  String  NombreEvent;
    private  String FotoEvento;
    private String FechaIncio;
    private  String HoraInicio;
    private  String NombreUser;
    private String FotoUser;
    private  int idSitio;
    private  double Latitud;
    private double Longitud;
    public double getLatitud() {
        return Latitud;
    }

    public void setLatitud(double latitud) {
        Latitud = latitud;
    }

    public double getLongitud() {
        return Longitud;
    }

    public void setLongitud(double longitud) {
        Longitud = longitud;
    }


    public Eventos(int idEvento, String nombreEvent, String fotoEvento, String fechaIncio, String horaInicio, String nombreUser, String fotoUser, int idSitio,double latitud,double longitud) {
        this.idEvento = idEvento;
        NombreEvent = nombreEvent;
        FotoEvento = fotoEvento;
        FechaIncio = fechaIncio;
        HoraInicio = horaInicio;
        NombreUser = nombreUser;
        FotoUser = fotoUser;
        this.idSitio = idSitio;
        Latitud = latitud;
        Longitud = longitud;

    }


    public int getIdEvento() {
        return idEvento;
    }

    public void setIdEvento(int idEvento) {
        this.idEvento = idEvento;
    }

    public String getNombreEvent() {
        return NombreEvent;
    }

    public void setNombreEvent(String nombreEvent) {
        NombreEvent = nombreEvent;
    }

    public String getFotoEvento() {
        return FotoEvento;
    }

    public void setFotoEvento(String fotoEvento) {
        FotoEvento = fotoEvento;
    }

    public String getHoraInicio() {
        return HoraInicio;
    }

    public void setHoraInicio(String horaInicio) {
        HoraInicio = horaInicio;
    }

    public String getFechaIncio() {
        return FechaIncio;
    }

    public void setFechaIncio(String fechaIncio) {
        FechaIncio = fechaIncio;
    }

    public String getNombreUser() {
        return NombreUser;
    }

    public void setNombreUser(String nombreUser) {
        NombreUser = nombreUser;
    }

    public String getFotoUser() {
        return FotoUser;
    }

    public void setFotoUser(String fotoUser) {
        FotoUser = fotoUser;
    }

    public int getIdSitio() {
        return idSitio;
    }

    public void setIdSitio(int idSitio) {
        this.idSitio = idSitio;
    }
}
