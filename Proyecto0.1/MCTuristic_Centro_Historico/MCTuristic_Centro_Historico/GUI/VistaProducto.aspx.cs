using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MCTuristic_Centro_Historico.GUI
{
    public partial class VistaProducto : System.Web.UI.Page
    {
        localhost.WsMCTuristic oServicios = new localhost.WsMCTuristic();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BuscarServicios();
            }
            catch
            {
                Response.Redirect("404.aspx");
            }
         
        }
        public void BuscarServicios()
        {
            DataSet DtServicios = oServicios.top12Servicios();
            DtlProductos.DataSource = DtServicios;
            DtlProductos.DataBind();
        }
        public string RecuperarImagenWebUrl(string Imagen)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(Imagen);
            string image = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
            image = "data:image/.jpeg" + "jpeg;base64," + image;
            return image;
        }
        public string RecuperarImagen(object img)
        {
            return RecuperarImagenWebUrl(img.ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ImageButton ib = (ImageButton)sender;
            Panel Panel = (Panel)ib.Parent;
            DataListItem Fila = (DataListItem)Panel.Parent;
            Label Id = (Label)Fila.Controls[1];
            Session["idServicio"] = Id.Text;
            Response.Redirect("DetalleProducto.aspx"); 
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Recursos/Restaurantes.pdf");
        }
    }
}