using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MCTuristic_Centro_Historico.GUI
{
    public partial class InicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Agregamos el atributo onkeypress que es propio de html y activamos el evento  button_click 
            //Pasamos el contexto de la aplicación y control junto con el botn id
            this.txtContraseña.Attributes.Add(
             "onkeypress", "button_click(this,'" + this.btnIngresar.ClientID + "')");
           
        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
           cargarUsuario();
        }
        private void cargarUsuario()
        {
            DataTable Datos = new DataTable();
            localhost.WsMCTuristic Services = new localhost.WsMCTuristic();
            localhost.AdministradorBO oAdmin = new localhost.AdministradorBO();
            oAdmin.Email = txtEmail.Text;
            oAdmin.Contraseñaadmin = txtContraseña.Text;
            Datos = Services.Login(oAdmin);
            oAdmin.Nombreadmin = "";
            if (Datos.Rows.Count != 0)
            {
                Session["idAdmin"] = Datos.Rows[0][1].ToString();
                Session["idUser"] = "";
                Server.Transfer("Principal.aspx");
            }
            else
            {
                localhost.UsuarioBO oUser = new localhost.UsuarioBO();
                oUser.EmailUsuario = txtEmail.Text;
                oUser.ContraseñaUsuario = txtContraseña.Text;
                Datos = Services.LoginUsuario(oUser);
                if (Datos.Rows.Count != 0)
                {
                    Session["idAdmin"] = "";
                    Session["idUser"] = Datos.Rows[0][1].ToString();
                    Server.Transfer("Principal.aspx");
                }
                else
                {
                    string script = "ErrorLogin()";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "ErrorLogin", script, true);
                    txtContraseña.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    //Response.Redirect("InicioSesion.aspx");
                }
            }
        }

      
    }
}

