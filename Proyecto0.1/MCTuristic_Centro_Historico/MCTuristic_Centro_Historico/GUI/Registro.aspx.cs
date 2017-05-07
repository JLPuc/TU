using MCTuristic_Centro_Historico.localhost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MCTuristic_Centro_Historico.GUI
{
    public partial class Registro : System.Web.UI.Page
    {
        localhost.WsMCTuristic oWebService = new WsMCTuristic();
        localhost.DireccionBO oDireccionUser = new DireccionBO();
        string idUser = "";
        bool Verificar;
        
        protected void Page_Load(object sender, EventArgs e)
        {
          
            localhost.DireccionBO oDireccio = new DireccionBO();
            localhost.UsuarioBO oUsuario = new UsuarioBO();

            
            
         }

        public void VerificarBotonEnviar()
        {
            Verificar = Convert.ToBoolean(Session["verificarimg"]);
            if (Verificar == false)
            {
                
                btnAgregar.Enabled = false;
            }
            else
            {
                btnAgregar.Enabled = true;

            }
        }



        [WebMethod]
        public static int Sumar(int n1, int n2)
        {
            return n1 + n2;
        }
        //-----------------Botones-----------Con javaScrip

        [System.Web.Services.WebMethod]
        public static string Guardar(string nombre, string apellido, string email, string contraseña, string numero)
        {
            localhost.WsMCTuristic owebService = new WsMCTuristic();
            localhost.UsuarioBO oUsuariosBO = new UsuarioBO();
            oUsuariosBO.NombreUsuario = nombre;
            oUsuariosBO.ApellidosUsuario = apellido;
            oUsuariosBO.EmailUsuario = email;
            oUsuariosBO.ContraseñaUsuario = contraseña;
            oUsuariosBO.TelefonoUsuario = numero;


            int i = owebService.InsertarUsuario(oUsuariosBO);
            if (i > 0)
            {
                return "Operación exitosa";
            }
            return "Fallo la operación";

        }
        //Agregar Usuario *
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
         
           
            if(chkTerminos.Checked == false)
            {
                Response.Write("<script>alert('Porfavor marque la opción de Aceptar terminos Términos y condiciones de uso');</script>");

                string script = "myFuncion();";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "myFuncion", script, true);
            }
            else
            {
                Verificar = Convert.ToBoolean(Session["verificarimg"]);
                if (Verificar == false)
                {
                    Response.Write("<script>alert('Al parecer no has elegido una imagen para tu usuario, Seleccione un imagen y presione el bóton visualizar imagen');</script>");
                   
                }
                else
                {
                    Session["verificarimg"] = false;
                    try
                    {
                        int i = oWebService.InsertarUsuario(RecuperarInformacion());
                        if (i > 0)
                        {
                            Session["idUsuario"] = oWebService.obtener_usuarioid();
                            int y = oWebService.InsertarDireccion(RecuperarDireccion());
                            if (i > 0)
                            {

                             
                                Response.Redirect("Suscripciones.aspx");
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }

                }
            }
            
        }

        //Métodos Para el registro completo de Usuarios.
        private bool VerificarArchivoImg()
        {
            if (fuFoto1.HasFile)
            {
                string ext = System.IO.Path.GetExtension(fuFoto1.FileName);
                if (ext == ".jpeg" || ext == ".jpg" || ext == ".png")
                {
                    //string path = Server.MapPath(@"\Recursos\");
                    //fu.SaveAs(path + fu.FileName);
                    HttpPostedFile imagen = fuFoto1.PostedFile;
                    int tamaño = imagen.ContentLength;
                    Byte[] arreglo = new Byte[tamaño];
                    imagen.InputStream.Read(arreglo, 0, tamaño);
                    Session["arreglo"] = arreglo;
                    Session["Url"] = ConvertirImagenStringWebUrl(arreglo, ext);
                }
                return true;
            }
            else
            {
                Response.Write("<h3>Solo puedes seleccionar archivos tipo .jpeg , .jpg o .png</h3>");
            }
            return false;
        }
        public string ConvertirImagenStringWeb(Byte[] arreglo)
        {
            string imagen = Convert.ToBase64String(arreglo, 0, arreglo.Length);
            return imagen;
        }
        public string ConvertirImagenStringWebUrl(Byte[] arreglo, string extension)
        {
            string url = Convert.ToBase64String(arreglo, 0, arreglo.Length);
            url = "data:image/" + extension + "jpeg;base64," + url;
            return url;
        }
        protected void btnVer_Click(object sender, EventArgs e)
        {
           
            if (VerificarArchivoImg() == true)
            {
                //Asigna la verificación de la imagen para saber si esta seleccionada una imagen.
                Session["verificarimg"] = true;
                imgFoto1.ImageUrl = (string)Session["Url"];
                //Verifica de nuevo para activar el botón de Registro.
                //Confirmación de Mensaje.
                string script = "FotoSubida()";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "FotoSubida", script, true);

            }
        }

        //--------------------Recolección de Información-----------------------------------
        private localhost.UsuarioBO RecuperarInformacion()
        {
            localhost.UsuarioBO oUsuariosBO = new UsuarioBO();
            oUsuariosBO.NombreUsuario = txtNombre.Text.Trim();
            oUsuariosBO.ApellidosUsuario = txtApellidos.Text.Trim();
            oUsuariosBO.EmailUsuario = txtDireccionCorreo.Text.Trim();
            oUsuariosBO.FecharNacUsuario = Calender.Text;
            oUsuariosBO.Foto = (Byte[])Session["arreglo"];
            if (txtContraseña.Text == txtConfirmarContraseña.Text)
            {
                oUsuariosBO.ContraseñaUsuario = txtConfirmarContraseña.Text.Trim();
            }
            oUsuariosBO.TelefonoUsuario = txtTelefono.Text.Trim();
            return oUsuariosBO;
        }
        private localhost.DireccionBO RecuperarDireccion()
        {
            oDireccionUser = new DireccionBO();
            oDireccionUser.Calle = txtCalle.Text.Trim();
            oDireccionUser.Cruzamiento = txtCruzamiento.Text.Trim();
            oDireccionUser.Numero = txtNumeroCalle.Text.Trim();
            oDireccionUser.DescripcionDireccion = txtDescripción.Text.Trim();
            oDireccionUser.Colonia = txtColonia.Text.Trim();
            oDireccionUser.Estado = txtEstado.Text.Trim();
            oDireccionUser.CodPostal = txtCodigoPostal.Text.Trim();
            oDireccionUser.IdUsuario = Convert.ToInt32(Session["idUsuario"]);
            return oDireccionUser;
        }

    }
}