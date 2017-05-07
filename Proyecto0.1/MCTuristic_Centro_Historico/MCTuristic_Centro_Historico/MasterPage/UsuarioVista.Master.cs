using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MCTuristic_Centro_Historico.MasterPage
{
    public partial class UsuarioVista : System.Web.UI.MasterPage
    {
        string Admin,Usuario;

        protected void lnkCerrarSecion_Click(object sender, EventArgs e)
        {
            Session["idAdmin"] = "";
            Session["idUser"] = "";
            Server.Transfer("PagPrincipal.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Admin = (string)Session["idAdmin"];
            Usuario = (string)Session["idUser"];

            if (Admin == "" || Admin ==null && Usuario == "" || Usuario == null)
            {
                Session["idAdmin"] = "";
                Session["idUser"] = "";
            }
            else
            {

                if (!IsPostBack)
                {
                    try
                    {

                        if (Admin != "" || Usuario != "")
                        {
                            hyInicioSeción.Visible = false;
                            lnkCerrarSecion.Visible = true;
                        }
                        else
                        {
                            hyInicioSeción.Visible = true;
                            lnkCerrarSecion.Visible = false;
                        }
                    }
                    catch { }
                }
            }

        }
    }
}