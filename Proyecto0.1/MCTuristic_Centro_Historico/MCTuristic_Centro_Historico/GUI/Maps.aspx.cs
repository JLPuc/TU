using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MCTuristic_Centro_Historico.GUI
{
    public partial class Maps : System.Web.UI.Page
    {
        double Latitud;
        double Longitud;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //Resive los parametros Lat y lng para para verificar Si en algún momento se esta mandado desde el Panel Editar.
                Latitud = Convert.ToDouble(Session["Latitud"]);
                Longitud = Convert.ToDouble(Session["Longitud"]);

                //Si son diferentes  que 0 entran en el primer condicional puesto que detecta que se está editando algún lugar sitio o Establecimiento
                if (Latitud != 0 && Longitud != 0)
                {
                    //Pasa los valores a los texbox para que el Mapa posicione el marcador.
                    txtLong.Text = Convert.ToString(Longitud);
                    TextLat.Text = Convert.ToString(Latitud);
                }
                else
                {
                    //En ese caso No existe ningun valor a si que  Esto asigna la parte central de Mérida para poder tener referencia de posición.
                    PosicionZocaloCidadaMerida();


                }

            }
        }

        protected void TextLat_TextChanged(object sender, EventArgs e)
        {
        
        }

        protected void btnMaps_Click(object sender, EventArgs e)
        {
            //Verifica que los texto se encuentren llenos para proceder.
            if (txtLong.Text != string.Empty && TextLat.Text != string.Empty)
            {
             
                //Se encarga de Verificar Si la variable EditarMapa Esta en true.  
                bool Modificar = Convert.ToBoolean(Session["ModificarMapaEdit"]);
                //Verifica si algún formulario mando esta tratando  de editar un registro.
                if(Modificar== true)
                {
                    Latitud = Convert.ToDouble(Session["Latitud"]);
                    Longitud = Convert.ToDouble(Session["Longitud"]);
                    if (Longitud != Convert.ToDouble(txtLong.Text) && Latitud != Convert.ToDouble(TextLat.Text))
                    {
                        Session["ModificarMap"] = true;
                        Session["ModificarMapaEdit"] = false;
                    }
                    else
                    {
                        Session["ModificarMap"] = false;
                    }
                }
               
                //Manda Lo que tenga la caja de texto de esta menera se puede asegurar que los datos jamas sepierdan.
                Session["Latitud"] = TextLat.Text;
                Session["Longitud"] = txtLong.Text;
                //Identifica que formulario lo ingreso.
                bool Sitios = Convert.ToBoolean(Session["Sitio"]);
                if(Sitios == true)
                {
                    //Se encarga de eliminar la sesión para poder genera otro entrada segura.
                    Session.Remove("Sitio");
                    Response.Redirect("GestionSitios.aspx");
                }
                else
                {
                   Response.Redirect("GestionEstablecimientos.aspx");
                }
            
                txtLong.Text = String.Empty;
                TextLat.Text = String.Empty;
            }
            else
            {
                //Si se borran se posiciona de nuevo.
                PosicionZocaloCidadaMerida();
            }
          
        }



        //Métodos
        public void PosicionZocaloCidadaMerida()
        {
            TextLat.Text = "20.966890931424636";
            txtLong.Text = "-89.62354648315431";
        }
    }
}