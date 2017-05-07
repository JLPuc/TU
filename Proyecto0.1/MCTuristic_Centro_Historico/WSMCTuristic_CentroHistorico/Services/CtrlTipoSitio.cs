﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WSMCTuristic_CentroHistorico.Services
{
    public class CtrlTipoSitio
    {
        DAO.TipoSitioDAO oTipoSitio;

        public int InsertarTipoSitio(object obj)
        {
            oTipoSitio = new DAO.TipoSitioDAO();
            return oTipoSitio.AgregarTipoSitio(obj);
        }

        public int ModificarTipoSitio(object obj)
        {
            oTipoSitio = new DAO.TipoSitioDAO();
            return oTipoSitio.ActualizarTipoSitio(obj);
        }

        public int EliminarTipoSitio(object obj)
        {
            oTipoSitio = new DAO.TipoSitioDAO();
            return oTipoSitio.EliminarTipoSitio(obj);
        }
        public DataSet topTipoSitioDS()
        {
            oTipoSitio = new DAO.TipoSitioDAO();
            return oTipoSitio.TipoSitioDS();
        }


        public DataSet tipoSitio()
        {
            oTipoSitio = new DAO.TipoSitioDAO();
            return oTipoSitio.TipoSitiosws();
        }




    }
}