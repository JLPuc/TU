using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WSMCTuristic_CentroHistorico.Services
{
    public class CtrlServicio
    {
        DAO.ServicioDAO oServicio;

        public int InsertarServicio(object obj)
        {
            oServicio = new DAO.ServicioDAO();
            return oServicio.insertarServicio(obj);
        }


        public int ModificarServicio(object obj)
        {
            oServicio = new DAO.ServicioDAO();
            return oServicio.ModificarServicio(obj);
        }

        public int EliminarServicio(object obj)
        {
            oServicio = new DAO.ServicioDAO();
            return oServicio.EliminarServicio(obj);
        }
        public DataSet topServicios_user(object obj)
        {
            oServicio = new DAO.ServicioDAO();
            return oServicio.Servicio_userDS(obj);
        }
        public DataSet topServicios_admin(object obj)
        {
            oServicio = new DAO.ServicioDAO();
            return oServicio.Servicio_adminDS(obj);
        }
        public DataSet top12Servicios()
        {
            oServicio = new DAO.ServicioDAO();
            return oServicio.top12SERVICIOS();
        }
        public DataSet ver_DetalleProducto(object obj)
        {
            oServicio = new DAO.ServicioDAO();
            return oServicio.ver_DetalleProducto(obj);
        }
        public byte[] verfoto(int id)
        {
            oServicio = new DAO.ServicioDAO();
            return oServicio.verFoto_User(id);
        }



        public DataSet Servicios_TipoSitio(String Sitios)
        {
            String TipoSitios = Sitios;
            oServicio = new DAO.ServicioDAO();
            return oServicio.Servicios_TipoServicio(TipoSitios);
        }
    }
}