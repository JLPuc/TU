using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MCTuristic_Centro_Historico.GUI
{
    public partial class GestionSuscripciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ValidarLogin();
            }
        }

        public void ValidarLogin()
        {
            if ((string)Session["idAdmin"] != "")
            {
                localhost.AdministradorBO datos = new localhost.AdministradorBO();
                localhost.WsMCTuristic service = new localhost.WsMCTuristic();
                datos.IdAdministrador = Convert.ToInt32((string)Session["idAdmin"]);
                DataSet tabla = service.Ver_admin_log(datos);
                if ((tabla.Tables[0].Rows[0]["Nombre"].ToString() + " " + tabla.Tables[0].Rows[0]["Apellidos"].ToString()).Length > 9)
                {
                    lblUsuario.Text = (tabla.Tables[0].Rows[0]["Nombre"].ToString() + " " + tabla.Tables[0].Rows[0]["Apellidos"].ToString()).Substring(0, 10) + "...";
                }
                else
                {
                    lblUsuario.Text = (tabla.Tables[0].Rows[0]["Nombre"].ToString() + " " + tabla.Tables[0].Rows[0]["Apellidos"].ToString());
                }
                lblNombreUsuario.Text = tabla.Tables[0].Rows[0]["Nombre"].ToString() + " " + tabla.Tables[0].Rows[0]["Apellidos"].ToString();
            }
            else
            {
                if ((string)Session["idUser"] != "")
                {
                    localhost.UsuarioBO datos = new localhost.UsuarioBO();
                    localhost.WsMCTuristic service = new localhost.WsMCTuristic();
                    datos.IdUsuario = Convert.ToInt32((string)Session["idUser"]);
                    DataSet tabla = service.usuario_userWS(datos);
                    lblUsuario.Text = (tabla.Tables[0].Rows[0]["Nombre"].ToString() + " " + tabla.Tables[0].Rows[0]["Apellidos"].ToString()).Substring(0, 10) + "...";
                    lblNombreUsuario.Text = tabla.Tables[0].Rows[0]["Nombre"].ToString() + " " + tabla.Tables[0].Rows[0]["Apellidos"].ToString();
                    imgMiniaturaUsuario.ImageUrl = ConvertirImagenStringWebUrl((Byte[])tabla.Tables[0].Rows[0]["Foto"], "jpg");
                    imgUsuario.ImageUrl = ConvertirImagenStringWebUrl((Byte[])tabla.Tables[0].Rows[0]["Foto"], "jpg");
                    phUsuario.Visible = true;
                    phAdmin.Visible = false;
                }
            }
        }

        public string ConvertirImagenStringWebUrl(Byte[] arreglo,
    string extension)
        {
            string url = Convert.ToBase64String(arreglo, 0, arreglo.Length);
            url = "data:image/" + extension + "jpeg;base64," + url;
            return url;
        }

        public static string GuardarTipoSuscripcion(string nombre, decimal monto, int tiempo)
        {
            //localhost.WsMCTuristic owebService = new localhost.WsMCTuristic();
            //localhost.TipoSuscripcionBO oTipoSuscripcionBO = new localhost.TipoSuscripcionBO();
            //oTipoSuscripcionBO.NombreTipoSuscri = nombre;
            //oTipoSuscripcionBO.MontoSuscripcion = monto;
            //oTipoSuscripcionBO.TiempoSuscripcion = tiempo;
            //int i = owebService.InsertarTipoSuscripcion(oTipoSuscripcionBO);
            //if (i > 0)
            //{
            //    return "Operación exitosa";
            //}
            return "Fallo la operación";

        }

        public static string GuardarSuscripcion(int idTipo, string fecha, string usuario)
        {
            //localhost.WsMCTuristic owebService = new localhost.WsMCTuristic();
            //localhost.SuscripcionBO oSuscripcionBO = new localhost.SuscripcionBO();
            //oSuscripcionBO.IdSuscripcion = idTipo;
            //oSuscripcionBO.FechaPago = Convert.ToDateTime(fecha);
            //oSuscripcionBO.IdUsuario = usuario;
            //int i = owebService.InsertarSuscripcion(oSuscripcionBO);
            //if (i > 0)
            //{
            //    return "Operación exitosa";
            //}
            return "Fallo la operación";

        }

        protected void ddlSuscripcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdTipo.Text = ddlSuscripcion.SelectedIndex.ToString();
        }

    }
}