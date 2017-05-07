package com.mastercoder.rutas_mcturistic.model;

/**
 * Created by Luis Puc on 13/03/2017.
 */

public class Picture {
    private  String picture;
    private  String userName;
    private  String time;
    private  String like_number= "0";

    public Picture(String picture, String userName, String like_number, String time) {
        this.picture = picture;
        this.userName = userName;
        this.like_number = like_number;
        this.time = time;
    }

    public String getPicture() {
        return picture;
    }

    public void setPicture(String picture) {
        this.picture = picture;
    }

    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public String getLike_number() {
        return like_number;
    }

    public void setLike_number(String like_number) {
        this.like_number = like_number;
    }

    public String getTime() {
        return time;
    }

    public void setTime(String time) {
        this.time = time;
    }
}
