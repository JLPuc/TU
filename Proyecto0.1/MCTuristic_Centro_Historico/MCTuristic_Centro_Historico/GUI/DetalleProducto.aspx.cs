using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MCTuristic_Centro_Historico.GUI
{
    public partial class DetalleProducto : System.Web.UI.Page
    {
        localhost.WsMCTuristic oServicios = new localhost.WsMCTuristic();
        protected void Page_Load(object sender, EventArgs e)
        {
            BuscarServicios();
        }
        public void BuscarServicios()
        {

            localhost.ServicioBO oservicio = new localhost.ServicioBO();
            oservicio.IdServicio = Convert.ToInt32(Session["idServicio"]);
            DataSet DtServicios = oServicios.ver_DetallProducto(oservicio);
            DLDetallProducto.DataSource = DtServicios;
            DLDetallProducto.DataBind();
        }
    }
}