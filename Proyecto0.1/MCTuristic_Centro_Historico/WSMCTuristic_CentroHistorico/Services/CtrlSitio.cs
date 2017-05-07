using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WSMCTuristic_CentroHistorico.Services
{
    public class CtrlSitio
    {
        DAO.SitioDAO oSitio;
        public int InsertarSitio(object obj)
        {
            oSitio = new DAO.SitioDAO();
            return oSitio.AgregarSitio(obj);
        }

        public int ModificarSitio(object obj)
        {
            oSitio = new DAO.SitioDAO();
            return oSitio.ActualizarSitio(obj);
        }

        public int EliminarSitio(object obj)
        {
            oSitio = new DAO.SitioDAO();
            return oSitio.EliminarSitio(obj);
        }
        public DataSet topSitioDS()
        {
            oSitio = new DAO.SitioDAO();
            return oSitio.SitioDS();
        }
        public DataSet topSitio_id(int id)
        {
            BO.SitioBO oSitioBO = new BO.SitioBO();
            oSitioBO.IdSitio = id;
            oSitio = new DAO.SitioDAO();
            return oSitio.Sitio_id(oSitioBO);
        }


    }
}