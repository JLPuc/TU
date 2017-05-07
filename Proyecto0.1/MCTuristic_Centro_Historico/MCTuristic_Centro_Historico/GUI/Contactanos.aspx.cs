using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MCTuristic_Centro_Historico.GUI
{
    public partial class Contactanos : System.Web.UI.Page
    {
        localhost.WsMCTuristic oServicio = new localhost.WsMCTuristic();
        localhost.ContactanosBO oContactanos = new localhost.ContactanosBO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            oContactanos.NombreContacto = txtNombre.Text;
            oContactanos.EmailContacto = txtEmail.Text;
            oContactanos.ApellidoContacto = txtApellidos.Text;
            oContactanos.Asunto = txtAsunto.Text;
            oContactanos.Contenido = txtContenido.Text;
            //Solicitud para saber si el comentario fue realizado.
           int i= oServicio.InsertarContactanos(oContactanos);
            if(i>0)
            {
                txtNombre.Text = String.Empty;
                txtEmail.Text = String.Empty;
                txtApellidos.Text = String.Empty;
                txtAsunto.Text = String.Empty;
                txtContenido.Text = String.Empty;
            }
            
        }
    }
}