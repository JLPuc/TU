using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MCTuristic_Centro_Historico.GUI
{
    public partial class Rutas : System.Web.UI.Page
    {
        public string[,] datos;
        protected void Page_Load(object sender, EventArgs e)
        {
            Posiciones();
        }

        public String[,] Posiciones()
        {
            localhost.WsMCTuristic service = new localhost.WsMCTuristic();
            datos = new string[900, 4]; 
            DataSet data = service.sitio_WS();
            localhost.SitioBO dato;
            int cont = 0;
            foreach (var dr in data.Tables)
            {
                if (dr is DataRow)
                {
                    DataRow dt = (DataRow)dr;
                    dato = new localhost.SitioBO();
                    string longitud = ((string)dt["Longitud"]).Replace('.', ',');
                    string latitud = ((string)dt["Latitud"]).Replace('.', ',');
                    dato.LongitudSitio = Convert.ToDecimal(longitud);
                    dato.LatitudSitio = Convert.ToDecimal(latitud);
                    dato.NombreSitio = dt["Nombre"].ToString();
                    datos[cont, 0] = dato.NombreSitio;
                    datos[cont, 1] = dato.LatitudSitio.ToString();
                    datos[cont, 2] = dato.LongitudSitio.ToString();
                    
                    cont++;
                }
            }

            return datos;
        }

    }
}