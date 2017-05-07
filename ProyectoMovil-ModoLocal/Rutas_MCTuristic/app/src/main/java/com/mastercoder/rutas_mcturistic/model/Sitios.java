package com.mastercoder.rutas_mcturistic.model;

/**
 * Created by Luis Puc on 20/03/2017.
 */

public class Sitios {
    private String Codigo;
    private String Nombre;
    private String Descripcion;
    private String Sucesosimportantes;
    private String Historia;
    private  String Direccion;
    private  String Foto;
    private  double Latitud;
    private double Longitud;
    private int idTipoSitio;

    public Sitios(){

    }

    public Sitios(String foto, String nombre, String codigo, String sucesosimportantes) {
        Foto = foto;
        Nombre = nombre;
        Codigo = codigo;
        Sucesosimportantes = sucesosimportantes;
    }


    public Sitios(String codigo, String nombre, String descripcion, String sucesosimportantes, String historia, String direccion, double latitud, double longitud, int idTipoSitio) {
        Codigo = codigo;
        Nombre = nombre;
        Descripcion = descripcion;
        Sucesosimportantes = sucesosimportantes;
        Historia = historia;
        Direccion = direccion;
        Latitud = latitud;
        Longitud = longitud;
        this.idTipoSitio = idTipoSitio;
    }

    public String getCódigo() {
        return Codigo;
    }

    public void setCódigo(String código) {
        Codigo = código;
    }

    public String getNombre() {
        return Nombre;
    }

    public void setNombre(String nombre) {
        Nombre = nombre;
    }

    public String getSucesosimportantes() {
        return Sucesosimportantes;
    }

    public void setSucesosimportantes(String sucesosimportantes) {
        Sucesosimportantes = sucesosimportantes;
    }

    public String getHistoria() {
        return Historia;
    }

    public void setHistoria(String historia) {
        Historia = historia;
    }

    public String getDescripción() {
        return Descripcion;
    }

    public void setDescripción(String descripción) {
        Descripcion = descripción;
    }

    public String getDireccion() {
        return Direccion;
    }

    public void setDireccion(String direccion) {
        Direccion = direccion;
    }

    public String getFoto() {
        return Foto;
    }

    public void setFoto(String foto) {
        Foto = foto;
    }

    public double getLatitud() {
        return Latitud;
    }

    public void setLatitud(double latitud) {
        Latitud = latitud;
    }

    public int getIdTipoSitio() {
        return idTipoSitio;
    }

    public void setIdTipoSitio(int idTipoSitio) {
        this.idTipoSitio = idTipoSitio;
    }

    public double getLongitud() {
        return Longitud;
    }

    public void setLongitud(double longitud) {
        Longitud = longitud;
    }
}
