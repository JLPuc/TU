package com.mastercoder.rutas_mcturistic.model;

import android.database.DefaultDatabaseErrorHandler;

import java.util.zip.DeflaterOutputStream;

/**
 * Created by Luis Puc on 22/03/2017.
 */

public class Servicios {

    private int idServicio;
    private String NombreServ;
    private String OfertaServicio;
    private Double PreciosServicio;
    private  String DescripServicio;
    private  String Foto;
    private  String Like;
    private int idEstablecimiento;
    private int idTipoServicio;

    private String nombreUser;


    private  double Latitud;
    private double Longitud;
    private  String Apellidos;
    private  String FotoUser;


    public Servicios(int idServicio, String nombreServ, Double preciosServicio ,String like,String foto,String nombreUser,String apellidos, String fotoUser,double latitud,double longitud ) {
        this.idServicio = idServicio;
        NombreServ = nombreServ;
        Foto = foto;
        Like = like;
        PreciosServicio = preciosServicio;
        Foto= foto;
        this.nombreUser = nombreUser;
        this.Apellidos = apellidos;
        this.FotoUser = fotoUser;
        Latitud = latitud;
        Longitud = longitud;
    }
    public String getNombreUser() {
        return nombreUser;
    }

    public void setNombreUser(String nombreUser) {
        this.nombreUser = nombreUser;
    }

    public String getApellidos() {
        return Apellidos;
    }

    public void setApellidos(String apellidos) {
        Apellidos = apellidos;
    }

    public String getFotoUser() {
        return FotoUser;
    }

    public void setFotoUser(String fotoUser) {
        FotoUser = fotoUser;
    }
    public int getIdServicio() {
        return idServicio;
    }

    public void setIdServicio(int idServicio) {
        this.idServicio = idServicio;
    }

    public String getNombreServ() {
        return NombreServ;
    }

    public void setNombreServ(String nombreServ) {
        NombreServ = nombreServ;
    }

    public String getOfertaServicio() {
        return OfertaServicio;
    }

    public void setOfertaServicio(String ofertaServicio) {
        OfertaServicio = ofertaServicio;
    }

    public Double getPreciosServicio() {
        return PreciosServicio;
    }

    public void setPreciosServicio(Double preciosServicio) {
        PreciosServicio = preciosServicio;
    }

    public String getDescripServicio() {
        return DescripServicio;
    }

    public void setDescripServicio(String descripServicio) {
        DescripServicio = descripServicio;
    }

    public String getLike() {
        return Like;
    }

    public void setLike(String like) {
        Like = like;
    }

    public int getIdEstablecimiento() {
        return idEstablecimiento;
    }

    public void setIdEstablecimiento(int idEstablecimiento) {
        this.idEstablecimiento = idEstablecimiento;
    }

    public String getFoto() {
        return Foto;
    }

    public void setFoto(String foto) {
        Foto = foto;
    }

    public int getIdTipoServicio() {
        return idTipoServicio;
    }

    public void setIdTipoServicio(int idTipoServicio) {
        this.idTipoServicio = idTipoServicio;
    }

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
}
