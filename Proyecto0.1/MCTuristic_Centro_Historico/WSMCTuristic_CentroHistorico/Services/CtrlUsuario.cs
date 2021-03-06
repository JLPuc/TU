﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WSMCTuristic_CentroHistorico.Services
{
    public class CtrlUsuario
    {
        DAO.UsuarioDAO oUsuario;
        public int InsertarUsuario(object obj)
        {
            oUsuario = new DAO.UsuarioDAO();
            return oUsuario.InsertarUsuario(obj);
        }

        public int ModificarUsuario(object obj)
        {
            oUsuario = new DAO.UsuarioDAO();
            return oUsuario.ModificarUsuario(obj);
        }

        public int EliminarUsuario(object obj)
        {
            oUsuario = new DAO.UsuarioDAO();
            return oUsuario.EliminarUsuario(obj);
        }
        public string id_usuario()
        {
            string res = "";
            oUsuario = new DAO.UsuarioDAO();
            res = oUsuario.Obtenerid_user();
            return res;
        }
        public DataTable LoginUsuario(object obj)
        {
            oUsuario = new DAO.UsuarioDAO();
            return oUsuario.Login(obj);
        }
        public DataSet topUsuarios_User(object obj)
        {
            oUsuario = new DAO.UsuarioDAO();
            return oUsuario.Usuario_userDS(obj);
        }
        public DataSet topUsuarios_admin()
        {
            oUsuario = new DAO.UsuarioDAO();
            return oUsuario.Usuario_adminDS();
        }
        public DataSet topUsuarios_adminFiltrados()
        {
            oUsuario = new DAO.UsuarioDAO();
            return oUsuario.Usuario_adminfiltradoDS();
        }

        public int insertar_dispositivo(string token)
        {
            oUsuario = new DAO.UsuarioDAO();
            return oUsuario.insertar_dispositivo(token);
        }

        public DataSet ver_dispositivos()
        {
            oUsuario = new DAO.UsuarioDAO();
            return oUsuario.ver_dispositivos();
        }

    }
}