package com.mastercoder.rutas_mcturistic.Pruebas_cardView;

import com.mastercoder.rutas_mcturistic.R;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Luis Puc on 22/03/2017.
 */

public class Foto {

    private String noVisualizaciones;
    private String noLikes;
    private String noComentarios;
    private int idImagen;
    private boolean esFavorita;
    private String titulo;
    private String usuario;
    private String tiempoDeExistencia;
    private int idAvatarUsuario;

    public Foto(String noVisualizaciones, String noLikes, String noComentarios, int idImagen,
                boolean esFavorita, String titulo, String usuario, String tiempoDeExistencia,
                int idAvatarUsuario) {
        this.noVisualizaciones = noVisualizaciones;
        this.noLikes = noLikes;
        this.noComentarios = noComentarios;
        this.idImagen = idImagen;
        this.esFavorita = esFavorita;
        this.titulo = titulo;
        this.usuario = usuario;
        this.tiempoDeExistencia = tiempoDeExistencia;
        this.idAvatarUsuario = idAvatarUsuario;
    }



    public String getNoVisualizaciones() {
        return noVisualizaciones;
    }

    public String getNoLikes() {
        return noLikes;
    }

    public int getIdImagen() {
        return idImagen;
    }

    public boolean esFavorita() {
        return esFavorita;
    }

    public String getNoComentarios() {
        return noComentarios;
    }

    public String getTitulo() {
        return titulo;
    }

    public String getUsuario() {
        return usuario;
    }

    public String getTiempoDeExistencia() {
        return tiempoDeExistencia;
    }

    public int getIdAvatarUsuario() {
        return idAvatarUsuario;
    }


    public static final List<Foto> FOTOS = new ArrayList<>();

    static {
        FOTOS.add(new Foto("4323", "456", "12", R.drawable.foto1, true,
                "Delicioso Sushi", "Carla Veradio", "2 meses atrás", R.drawable.avatar1));
        FOTOS.add(new Foto("2023", "156", "23", R.drawable.foto2, false,
                "Marionetas :3", "Julio Perez", "9 meses atrás", R.drawable.avatar2));
        FOTOS.add(new Foto("3455", "879", "1", R.drawable.foto3, true,
                "Pasadizo acuático", "Milena Merlano", "6 meses atrás", R.drawable.avatar3));
        FOTOS.add(new Foto("1290", "123", "34", R.drawable.foto4, false,
                "Paraguas de papel de aceite", "Julia P.", "2 meses atrás", R.drawable.avatar4));
        FOTOS.add(new Foto("2319", "900", "23", R.drawable.foto5, false,
                "Jardín de ensueño", "Vicentico Renet", "5 minutos atrás", R.drawable.avatar5));
        FOTOS.add(new Foto("1550", "345", "9", R.drawable.foto6, false,
                "Estallido de colores :D", "Carla Veradio", "1 día atrás", R.drawable.avatar1));
        FOTOS.add(new Foto("1323", "401", "20", R.drawable.foto7, true,
                "Fuerza natural", "Julio Perez", "2 meses atrás", R.drawable.avatar2));
        FOTOS.add(new Foto("4590", "222", "54", R.drawable.foto8, true,
                "Dedicatorias...", "Milena Merlano", "3 meses atrás", R.drawable.avatar3));
    }

}
