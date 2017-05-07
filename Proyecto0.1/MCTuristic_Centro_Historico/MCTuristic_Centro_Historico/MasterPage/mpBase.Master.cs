using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MCTuristic_Centro_Historico.MasterPage
{
    public partial class mpBase : System.Web.UI.MasterPage
    {
        int idAdmin;
        int idUser;

        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                try
                {
                    idAdmin = Convert.ToInt32(Session["idAdmin"]);
                    idUser = Convert.ToInt32(Session["idUser"]);
                    if (idAdmin > 0 || idUser > 0)
                    {
                        
                    }
                    else
                    {
                        Response.Redirect("PagPrincipal.aspx");
                    }
                }
                catch { }
                if ((string)Session["idAdmin"] == "" && (string)Session["idUser"] ==  "")
                {
                    Response.Redirect("404.aspx");
                }
               
            }

            

        }
    }
}