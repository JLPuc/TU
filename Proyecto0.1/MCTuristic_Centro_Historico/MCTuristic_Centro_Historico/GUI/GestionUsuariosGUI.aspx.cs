using MCTuristic_Centro_Historico.localhost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MCTuristic_Centro_Historico.GUI
{
    public partial class GestionUsuariosGUI : System.Web.UI.Page
    {
        localhost.WsMCTuristic owebService = new localhost.WsMCTuristic();
        localhost.UsuarioBO oUsuariosBO = new localhost.UsuarioBO();
        localhost.DireccionBO oDireccionBO = new DireccionBO();
        byte[] foto;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblNuevo.Visible = false;
            Editar.Visible = false;
            if (!IsPostBack)
            {
                ValidarLogin();
            }
        }

        //Se encarga validar si existe algún usuario activo.
        public void ValidarLogin()
        {
            //Entra en dado caso que el Exista un administrador.
            if ((string)Session["idAdmin"] != "")
            {
                localhost.AdministradorBO datos = new localhost.AdministradorBO();
                localhost.WsMCTuristic service = new localhost.WsMCTuristic();
                //Obtiene el id de la sesión que esta activa del administrador
                datos.IdAdministrador = Convert.ToInt32((string)Session["idAdmin"]);
                //Realiza una consulta para poder traer los datos del Administrador.
                DataSet tabla = service.Ver_admin_log(datos);
                //Al tener datos en el Dataset Se asignan a los controles que esta prestablecidos.
                if ((tabla.Tables[0].Rows[0]["Nombre"].ToString() + " " + tabla.Tables[0].Rows[0]["Apellidos"].ToString()).Length > 9)
                {
                    lblUsuario.Text = (tabla.Tables[0].Rows[0]["Nombre"].ToString() + " " + tabla.Tables[0].Rows[0]["Apellidos"].ToString()).Substring(0, 10) + "...";
                }
                else
                {
                    lblUsuario.Text = (tabla.Tables[0].Rows[0]["Nombre"].ToString() + " " + tabla.Tables[0].Rows[0]["Apellidos"].ToString());
                }
                lblNombreUsuario.Text = tabla.Tables[0].Rows[0]["Nombre"].ToString() + " " + tabla.Tables[0].Rows[0]["Apellidos"].ToString();
                
                //Por tener permisos de usuario este se encarga de llenar el gridView con todos los usuarios dados de alta.
                CargarUsuario();
            }
            else
            {
                //Entra en dado caso que el usaurio este activo.
                if ((string)Session["idUser"] != "")
                {
                    localhost.UsuarioBO datos = new localhost.UsuarioBO();
                    localhost.WsMCTuristic service = new localhost.WsMCTuristic();
                    //Obtiene el id de la sesión que esta activa del usuario
                    datos.IdUsuario = Convert.ToInt32((string)Session["idUser"]);
                    //Se realiza una consulta al WebServices para poder traer todos los datos necesarios.
                    DataSet tabla = service.usuario_userWS(datos);

                    //Al obtener los datos completos comienza a llenar los controles por si el usuario quiere 
                    lblUsuario.Text = (tabla.Tables[0].Rows[0]["Nombre"].ToString() + " " + tabla.Tables[0].Rows[0]["Apellidos"].ToString()).Substring(0, 10) + "...";
                    lblNombreUsuario.Text = tabla.Tables[0].Rows[0]["Nombre"].ToString() + " " + tabla.Tables[0].Rows[0]["Apellidos"].ToString();
                    imgMiniaturaUsuario.ImageUrl = ConvertirImagenStringWebUrl((Byte[])tabla.Tables[0].Rows[0]["Foto"], "jpg");
                    imgUsuario.ImageUrl = ConvertirImagenStringWebUrl((Byte[])tabla.Tables[0].Rows[0]["Foto"], "jpg");
                    phUsuario.Visible = true;
                    phAdmin.Visible = false;
                    GestioUsuarios.Visible = false;
                    Editar.Visible = true;
                    lblNuevo.Visible = true;
                    txtNombreEdit.Text = tabla.Tables[0].Rows[0]["Nombre"].ToString();
                    txtApellidosEdit.Text = tabla.Tables[0].Rows[0]["Apellidos"].ToString();
                    txtEmailEdit.Text = tabla.Tables[0].Rows[0]["Correo Electrónico"].ToString();
                    txtEmailEdit.ReadOnly = true;
                    txtContraseñaEdit.Text = tabla.Tables[0].Rows[0]["Contraseña"].ToString();
                    txtCelularEdit.Text = tabla.Tables[0].Rows[0]["Teléfono"].ToString();
                    txtFechaNacimientoEdit.Text = tabla.Tables[0].Rows[0]["Fecha de nacimiento"].ToString();
                    FotoPre.ImageUrl = ConvertirImagenStringWebUrl((Byte[])tabla.Tables[0].Rows[0]["Foto"], "jpg");
                    txtCalleEdit.Text = tabla.Tables[0].Rows[0]["Calle"].ToString();
                    txtCruzamientoEdit.Text = tabla.Tables[0].Rows[0]["Cruzamiento"].ToString();
                    txtNumeroCalleEdit.Text = tabla.Tables[0].Rows[0]["Numero"].ToString();
                    txtCodigoPostaEdit.Text = tabla.Tables[0].Rows[0]["CodPostal"].ToString();
                    txtColoniaEdit.Text = tabla.Tables[0].Rows[0]["Colonia"].ToString();
                    txtEstadoEdit.Text = tabla.Tables[0].Rows[0]["Estado"].ToString();
                    txtDescripcionEdit.Text = tabla.Tables[0].Rows[0]["Descripcion"].ToString();
                    Session["arreglo1"] = (Byte[])tabla.Tables[0].Rows[0]["Foto"];
                    txtIDUsuario.Text = datos.IdUsuario.ToString();
                    txtIdDireccion.Text = tabla.Tables[0].Rows[0]["idDireccion"].ToString();
                    lbtnEliminar.Visible = false;
                }
            }
        }
        //-------------------------------Eventos--------------------------------
        protected void lbtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int i = owebService.InsertarUsuario(RecuperarInformacion());
                if (i > 0)
                {
                    Session["idUsuario"] = owebService.obtener_usuarioid();
                    int y = owebService.InsertarDireccion(RecuperarDireccion());
                    if (i > 0)
                    {
                        string script = "MensajeGuardar()";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "MensajeGuardar", script, true);
                        LimpiarControles();
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            CargarUsuario();
        }
        protected void lblNuevo_Click(object sender, EventArgs e)
        {
            Editar.Visible = false;
            GestioUsuarios.Visible = true;
        }
        protected void lbtnModificar_Click(object sender, EventArgs e)
        {
            ModificarUser();
            GestioUsuarios.Visible = false;
            Editar.Visible = true;
        }
        protected void lbtnEliminar_Click(object sender, EventArgs e)
        {
            owebService = new localhost.WsMCTuristic();
            oDireccionBO = new localhost.DireccionBO();
            oUsuariosBO = new UsuarioBO();
            oDireccionBO.IdDireccion = Convert.ToInt32(txtIdDireccion.Text);
            oUsuariosBO.IdUsuario = Convert.ToInt32(txtIDUsuario .Text);
            try
            {
                int i = owebService.EliminarDireccion(oDireccionBO);
                if (i > 0)
                {
                    int y = owebService.EliminarUsuario(oUsuariosBO);
                    if (y > 0)
                    {
                        CargarUsuario();
                        //Panel
                        Editar.Visible = false;
                        GestioUsuarios.Visible = true;
                    }
                }
            }
            catch { }
        }
      
         
        //Método para poder saber si el usuario selecciono el boton de "Editar".
        protected void ASPxGridView1_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            if (e.CommandArgs.CommandArgument.ToString() == "Editar")
            {
                //Pasa las sobrecargas para realizar la selección de la fila.
                SeleccionEditar(sender,e);
            }
        }
        //Si el usuario selecciona un campo de GridView se ejecuta.
        private void SeleccionEditar(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            //Cambia el estado del panel principal para la gestión de nuevos usuarios.
            //Se encarga de poner invisible el primer panel.
            GestioUsuarios.Visible = false;

            //Pone el visible el panel para poder editar los valores del usuario seleccionado
            Editar.Visible = true;
            lblNuevo.Visible = true;
            
            //Recolecta los datos y los pasa al panel de edición.
            txtIDUsuario.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Código").ToString();
            txtIdDireccion.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "idDireccion").ToString();
            txtNombreEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Nombre").ToString();
            txtApellidosEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Apellidos").ToString();
            txtEmailEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Email").ToString();
            txtCelularEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Teléfono").ToString();
            txtFechaNacimientoEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "FechaNacimiento").ToString();
            txtCalleEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Calle").ToString();
            txtCruzamientoEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Cruzamiento").ToString();
            txtNumeroCalleEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Numero").ToString();
            txtColoniaEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Colonia").ToString();
            txtDescripcionEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Descripcion").ToString();
            txtEstadoEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Estado").ToString();
            txtCodigoPostaEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "CodPostal").ToString();
            Session["arreglo1"] = (byte[])ASPxGridView1.GetRowValues(e.VisibleIndex, "Foto");
            FotoPre.ImageUrl = ConvertirImagenStringWebUrl((Byte[])Session["arreglo1"], "jpg");
            txtContraseñaEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Contraseña").ToString();

            //Control de formulario web
            txtNombreEdit.Focus();
            lblNuevo.Visible = true;
        }

        //-----------------Métodos Para la gestion de Usuarios---------------------------------
        #region Métodos Gestión de Usuarios

        //Limpiar los controles de Formulario web
        private void LimpiarControles()
        {
            txtNombre.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtFecha.Text = string.Empty;
            txtContrasena.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCalle.Text = string.Empty;
            txtCruzamiento.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtColonia.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtCP.Text = string.Empty;
            imgFoto.ImageUrl = null;
        }
        //Encarga de hacer un llamado a la webservices y traer los datos del Usuario *Permitido Para el Administrador
        private void CargarUsuario()
        {
            ASPxGridView1.DataSource = owebService.usuario_adminWS();
            ASPxGridView1.DataBind();
        }
        //Recolección de Datos Registrados en el Formulario WEB.
        private localhost.UsuarioBO RecuperarInformacion()
        {
            localhost.UsuarioBO oUsuariosBO = new UsuarioBO();
            oUsuariosBO.NombreUsuario = txtNombre.Text.Trim();
            oUsuariosBO.ApellidosUsuario = txtApellidos.Text.Trim();
            oUsuariosBO.EmailUsuario = txtCorreo.Text.Trim();
            oUsuariosBO.FecharNacUsuario = txtFecha.Text;
            oUsuariosBO.Foto = (Byte[])Session["arreglo"];
            oUsuariosBO.ContraseñaUsuario = txtContrasena.Text;
            oUsuariosBO.TelefonoUsuario = txtTelefono.Text.Trim();
            return oUsuariosBO;
        }
        private localhost.DireccionBO RecuperarDireccion()
        {
            oDireccionBO = new DireccionBO();
            oDireccionBO.Calle = txtCalle.Text.Trim();
            oDireccionBO.Cruzamiento = txtCruzamiento.Text.Trim();
            oDireccionBO.Numero = txtNumero.Text;
            oDireccionBO.DescripcionDireccion = txtDescripcion.Text;
            oDireccionBO.Colonia = txtColonia.Text.Trim();
            oDireccionBO.Estado = txtEstado.Text.Trim();
            oDireccionBO.CodPostal = txtCP.Text;
            oDireccionBO.IdUsuario = Convert.ToInt32(Session["idUsuario"]);
            return oDireccionBO;
        }
        //Modificar *Recupera todo los datos en el formulario*.
        private void ModificarUser()
        {
            try
            {
                oUsuariosBO = new UsuarioBO();
                oUsuariosBO.IdUsuario = Convert.ToInt32(txtIDUsuario.Text);
                oUsuariosBO.NombreUsuario = txtNombreEdit.Text;
                oUsuariosBO.ApellidosUsuario = txtApellidosEdit.Text;
                oUsuariosBO.EmailUsuario = txtEmailEdit.Text;
                oUsuariosBO.FecharNacUsuario = txtFechaNacimientoEdit.Text;
                oUsuariosBO.TelefonoUsuario = txtCelularEdit.Text;
                oUsuariosBO.ContraseñaUsuario = txtContraseñaEdit.Text;
                oUsuariosBO.Foto = (Byte[])Session["arreglo1"];
                int i = owebService.ModificarUsuario(oUsuariosBO);
                if (i > 0)
                {
                    string script = "MensajeModificar()";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "MensajeModificar", script, true);
                    ModificarDireccion();
                }
                
                CargarUsuario();
            }catch
            {
                string script = "ErroModificar()";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "ErroModificar", script, true);
            }
         
        }
        private void ModificarDireccion()
        {

            oDireccionBO = new localhost.DireccionBO();
            oDireccionBO.IdDireccion = Convert.ToInt32(txtIdDireccion.Text);
            oDireccionBO.Calle = txtCalleEdit.Text;
            oDireccionBO.Numero = txtNumeroCalleEdit.Text;
            oDireccionBO.Estado = txtEstadoEdit.Text;
            oDireccionBO.Cruzamiento = txtCruzamientoEdit.Text;
            oDireccionBO.CodPostal = txtCodigoPostaEdit.Text;
            oDireccionBO.Colonia = txtColoniaEdit.Text;
            oDireccionBO.DescripcionDireccion = txtDescripcionEdit.Text;
            oDireccionBO.IdUsuario = Convert.ToInt32(txtIDUsuario.Text);
            int i = owebService.ModificarDireccion(oDireccionBO);
            if (i > 0)
            {

            }
            else
            {

            }
        }
        #endregion

        //----------Recuperación y generación de Imagenes-------------
        #region Control de imagenes
        private bool VerificarArchivoImg()
        {
            if (fuFoto.HasFile)
            {
                string ext = System.IO.Path.GetExtension(fuFoto.FileName);
                if (ext == ".jpeg" || ext == ".jpg" || ext == ".png")
                {
                    //string path = Server.MapPath(@"\Recursos\");
                    //fu.SaveAs(path + fu.FileName);
                    HttpPostedFile imagen = fuFoto.PostedFile;
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
        protected void btnVer_Click(object sender, EventArgs e)
        {
            if (VerificarArchivoImg() == true)
            {
                imgFoto.ImageUrl = (string)Session["Url"];
            }
        }
        //public Image RecuperarImagen(string Imagen)
        //{
        //    // Convert Base64 String to byte[]
        //    byte[] imageBytes = Convert.FromBase64String(Imagen);
        //    MemoryStream ms = new MemoryStream(imageBytes, 0,
        //      imageBytes.Length);

        //    // Convert byte[] to Image
        //    ms.Write(imageBytes, 0, imageBytes.Length);
        //    Image image = Image.FromStream(ms, true);
        //    return image;
        //}
        public string ConvertirImagenStringWeb(Byte[] arreglo)
        {
            string imagen = Convert.ToBase64String(arreglo, 0, arreglo.Length);
            return imagen;
        }
        public string RecuperarImagenWebUrl(string Imagen)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(Imagen);
            string image = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
            image = "data:image/.jpeg" + "jpeg;base64," + image;
            return image;
        }
        public string ConvertirImagenStringWebUrl(Byte[] arreglo, string extension)
        {
            string url = Convert.ToBase64String(arreglo, 0, arreglo.Length);
            url = "data:image/" + extension + "jpeg;base64," + url;
            return url;
        }
        #endregion
    }
}