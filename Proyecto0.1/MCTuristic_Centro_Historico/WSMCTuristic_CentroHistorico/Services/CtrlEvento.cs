using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WSMCTuristic_CentroHistorico.Services
{
    public class CtrlEvento
    {
        DAO.EventoDAO oEvento;
        public int InsertarEvento(object obj)
        {
            oEvento = new DAO.EventoDAO();
            return oEvento.InsertarEvento(obj);
        }

        public int ModificarEvento(object obj)
        {
            oEvento = new DAO.EventoDAO();
            return oEvento.ModificarEvento(obj);
        }

        public int EliminarEvento(object obj)
        {
            oEvento = new DAO.EventoDAO();
            return oEvento.EliminarEvento(obj);
        }
        public DataSet ver_Eventos(object obj)
        {
            oEvento = new DAO.EventoDAO();
            return oEvento.ver_Eventos(obj);
        }

        public DataSet Wver_Eventos_date(string Fecha)
        {
            oEvento = new DAO.EventoDAO();
            return oEvento.ver_Eventos_fecha(Fecha);
        }

        public DataSet ver_Eventos_user(object obj)
        {
            oEvento = new DAO.EventoDAO();
            return oEvento.ver_Eventos_user(obj);
        }

        public DataSet ver_Eventos_admin(object obj)
        {
            oEvento = new DAO.EventoDAO();
            return oEvento.ver_Eventos_admin(obj);
        }

        public DataSet ver_Eventos_movil()
        {
            oEvento = new DAO.EventoDAO();
            return oEvento.ver_Eventos_movil();
        }

    }
}