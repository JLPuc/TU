using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WSMCTuristic_CentroHistorico.Services
{
    public class CtrlEstablecimiento
    {
        DAO.EstablecimientoDAO oEstablecimiento;
        public int insertarEstablecimiento(object obj)
        {
            oEstablecimiento = new DAO.EstablecimientoDAO();
            return oEstablecimiento.InsertarEstablecimiento(obj);
        }

        public int EliminarEstablecimiento(object obj)
        {
            oEstablecimiento = new DAO.EstablecimientoDAO();
            return oEstablecimiento.ElimianarEstablecimiento(obj);
        }

        public int ModificarEstablecimiento(object obj)
        {
            oEstablecimiento = new DAO.EstablecimientoDAO();
            return oEstablecimiento.ModificarEstablecimiento(obj);
        }
        public DataSet topEstablecimientos_userDS(object obj)
        {
            oEstablecimiento = new DAO.EstablecimientoDAO();
            return oEstablecimiento.Establecimiento_UserDS(obj);
        }
        public DataSet topEstablecimientos_adminDS()
        {
            oEstablecimiento = new DAO.EstablecimientoDAO();
            return oEstablecimiento.Establecimiento_AdminDS();
        }

    }
}