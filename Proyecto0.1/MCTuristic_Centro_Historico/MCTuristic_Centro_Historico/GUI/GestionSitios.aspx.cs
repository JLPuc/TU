using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MCTuristic_Centro_Historico.GUI
{
    public partial class GestionSitios : System.Web.UI.Page
    {
        //-----------------------Variables de Inicio-----------------------
        localhost.WsMCTuristic owebService = new localhost.WsMCTuristic();
        double Latitud;
        double Longitud;
        localhost.SitioBO oSitioBO = new localhost.SitioBO();
        //----------------------Cargar variables y Métodos
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Editar.Visible = false;
            if (!IsPostBack)
            {
                //Encarga de Validar que tipo de usuario está estrando al sistema.
                ValidarLogin();
                //Carga los Tipos de Sitios.
                CargarDropTipoSitios();
                bool Edit = Convert.ToBoolean(Session["Editar"]);
                if (Edit == true)
                {
                    //Si la validación que se esta editando un sitio se activa llena los controles.
                    LlenarControlesEdit();
                    Latitud = Convert.ToDouble(Session["Latitud"]);
                    Longitud = Convert.ToDouble(Session["Longitud"]);
                  
                }
                Latitud = Convert.ToDouble(Session["Latitud"]);
                Longitud = Convert.ToDouble(Session["Longitud"]);

                //Si existen datos que el mapa los mando este los recipciona y Asigna un mensaje para decir que se selecciono las coodenada
                if (Latitud == 0 && Longitud == 0)
                {
                    lblMapsEstatus.Text = "Por favor seleccione su ubicación.";
                }
                else
                {
                    
                    lblMapsEstatus.Text = "Ubicación seleccionada.";
                }
            }

            CargarSitios();
        }
        //-----------------------Eventos--------------------------------  
        #region Eventos
        protected void btnMaps_Click(object sender, EventArgs e)
        {
            //Le manda una sesión al mapa para identifiar donde va aregresar los valores que recepcione los mapas.
            Session["Sitio"] = true;
            Response.Redirect("Maps.aspx");
        }
        protected void ASPxGridView1_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            if (e.CommandArgs.CommandArgument.ToString() == "Editar")
            {
                lblNuevo.Visible = true;
                oSitioBO = new localhost.SitioBO();
                oSitioBO.IdSitio = Convert.ToInt32(ASPxGridView1.GetRowValues(e.VisibleIndex, "Código").ToString());
                oSitioBO.NombreSitio = ASPxGridView1.GetRowValues(e.VisibleIndex, "Nombre").ToString();
                oSitioBO.IdTipoSitio = Convert.ToInt32(ASPxGridView1.GetRowValues(e.VisibleIndex, "idTipoSitio").ToString());
                oSitioBO.Direccion = ASPxGridView1.GetRowValues(e.VisibleIndex, "Dirección").ToString();
                oSitioBO.LatitudSitio = Convert.ToDecimal(ASPxGridView1.GetRowValues(e.VisibleIndex, "Latitud").ToString());
                oSitioBO.LongitudSitio = Convert.ToDecimal(ASPxGridView1.GetRowValues(e.VisibleIndex, "Longitud").ToString());
                oSitioBO.Historia = ASPxGridView1.GetRowValues(e.VisibleIndex, "Historia").ToString();
                oSitioBO.SucesoImportante = ASPxGridView1.GetRowValues(e.VisibleIndex, "Sucesosimportantes").ToString();
                oSitioBO.DescripcionSitio = ASPxGridView1.GetRowValues(e.VisibleIndex, "Descripción").ToString();
                oSitioBO.FotoSitio = (byte[])ASPxGridView1.GetRowValues(e.VisibleIndex, "Foto");
                Session["SitioEdit"] = oSitioBO;
                Session["Editar"] = true;
                ltdlngNull();
                LlenarControlesEdit();


            }
            if (e.CommandArgs.CommandArgument.ToString() == "Eventos")
            {
                Session["idSitio"] = Convert.ToInt32(ASPxGridView1.GetRowValues(e.VisibleIndex, "Código"));
                Response.Redirect("GestionEventos.aspx");
            }
        }

        protected void ddlTipoSitio_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTipoSitio.Text = ddlTipoSitio.SelectedItem.Value.ToString();
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            if (VerificarArchivoImg() == true)
            {
                imgEstablecimiento.ImageUrl = (string)Session["Url"];
            }
        }

        //Gestionar Sitios
        protected void lbtnGuardar_Click(object sender, EventArgs e)
        {

            Latitud = Convert.ToDouble(Session["Latitud"]);
            if (txtNombre.Text != string.Empty && Latitud != 0)
            {
                try
                {
                    int i = owebService.InsertarSitio(RecuperarSitio());
                    if (i > 0)
                    {
                        string script = "MensajeGuardar()";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "MensajeGuardar", script, true);
                        LimpiarControles();
                    }

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                CargarSitios();
            }
        }
        #endregion
        //-----------------------Métodos--------------------------------  
        #region Métodos

        
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
        private void CargarDropTipoSitios()
        {
            ddlTipoSitio.DataSource = owebService.tipoSitios();
            ddlTipoSitio.DataValueField = "idTipoSitio";
            ddlTipoSitio.DataTextField = "NombreSitio";
            ddlTipoSitio.DataBind();
        }      
        private void CargarSitios()
        {
            ASPxGridView1.DataSource = owebService.sitio_WS();
            ASPxGridView1.DataBind();
        }
        public static string GuardarTipoSitio(string nombre, string descripcion)
        {
            //localhost.WsMCTuristic owebService = new localhost.WsMCTuristic();
            //localhost.TipoSitioBO oTipoSitioBO = new localhost.TipoSitioBO();
            //oTipoSitioBO.NombreSitio = nombre;
            //oTipoSitioBO.DescripcicionSitio = descripcion;
            //int i = owebService.InsertarTipoSitio(oTipoSitioBO);
            //if (i > 0)
            //{
            //    return "Operación exitosa";
            //}
            return "Fallo la operación";

        }

        public static string GuardarSitio(string nombre, int idTipo, string direccion, decimal latitud, decimal longitud, string historia, string suceso, string descripcion)
        {
            //localhost.WsMCTuristic owebService = new localhost.WsMCTuristic();
            //localhost.SitioBO oSitioBO = new localhost.SitioBO();
            //oSitioBO.NombreSitio = nombre;
            //oSitioBO.IdTipoSitio = idTipo;
            //oSitioBO.Direccion = direccion;
            //oSitioBO.LatitudSitio = latitud;
            //oSitioBO.LongitudSitio = longitud;
            //oSitioBO.Historia = historia;
            //oSitioBO.SucesoImportante = suceso;
            //oSitioBO.DescripcionSitio = descripcion;
            //int i = owebService.InsertarSitio(oSitioBO);
            //if (i > 0)
            //{
            //    return "Operación exitosa";
            //}
            return "Fallo la operación";

        }

        protected void lblNuevo_Click(object sender, EventArgs e)
        {
            pnlGestionSitios.Visible = true;
            Editar.Visible = false;
            Session["Editar"] = false;
            lblMapsEstatus.Text = "Por favor seleccione su ubicación.";
            ltdlngNull();
            Session.Remove("SitioEdit");
            Session["ModificarMap"] = false;
        }
        //Gestionar Fotografias Método para convertirlas
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

        public string ConvertirImagenStringWebUrl(Byte[] arreglo,
    string extension)
        {
            string url = Convert.ToBase64String(arreglo, 0, arreglo.Length);
            url = "data:image/" + extension + "jpeg;base64," + url;
            return url;
        }
        //Limpiar Controles
        private void LimpiarControles()
        {
            imgEstablecimiento.ImageUrl = "~/images1/Sitio.png";
            txtNombre.Text = string.Empty;
            CargarDropTipoSitios();
            txtDescripcion.Text = string.Empty;
            txtHistoria.Text = string.Empty;
            txtSucesos.Text = string.Empty;
            lblMapsEstatus.Text = "Por favor seleccione su ubicación.";
            ltdlngNull();
        }

        //Limpiar Cordenadas De Google Maps
        private void ltdlngNull()
        {
            Session["Latitud"] = 0;
            Session["Longitud"] = 0;
        }
       
        //ABC Sitios
        private localhost.SitioBO RecuperarSitio()
        {  
            localhost.WsMCTuristic owebService = new localhost.WsMCTuristic();
            localhost.SitioBO oSitioBO = new localhost.SitioBO();
            oSitioBO.NombreSitio = txtNombre.Text;
            oSitioBO.IdTipoSitio = Convert.ToInt32( txtTipoSitio.Text );
            oSitioBO.Direccion = txtDireccion.Text;
            oSitioBO.LatitudSitio = Convert.ToDecimal(Session["Latitud"]);
            oSitioBO.LongitudSitio = Convert.ToDecimal(Session["Longitud"]);
            oSitioBO.Historia = txtHistoria.Text;
            oSitioBO.SucesoImportante = txtSucesos.Text;
            oSitioBO.DescripcionSitio = txtDescripcion.Text;
            oSitioBO.FotoSitio = (Byte[])Session["arreglo"]; 
            return oSitioBO;

        }
        //Llenar Controles si se esta editando
        private void LlenarControlesEdit()
        {
            try
            { //Define Si se cambio las cordenadas al momento de vizualizar el marcador
                bool CodenadasMoficadas = Convert.ToBoolean(Session["ModificarMap"]);
                pnlGestionSitios.Visible = false;
                Editar.Visible = true;
                oSitioBO = (localhost.SitioBO)Session["SitioEdit"];
                imgEstablecimiento.ImageUrl = "~/images1/Sitio.png";
                txtidSitioEdit.Text = oSitioBO.IdSitio.ToString();
                txtTipoSitoEdit.Text = oSitioBO.IdTipoSitio.ToString();
                txtNombreEdit.Text = oSitioBO.NombreSitio;
                txtDescripcionEdit.Text = oSitioBO.DescripcionSitio;
                txtHistoriaEdit.Text = oSitioBO.Historia;
                txtSucesoImportantesEdit.Text = oSitioBO.SucesoImportante;
                //Verifica Si existe algún cambio en el mapa
                if (CodenadasMoficadas == false)
                {
                    Session["Latitud"] = oSitioBO.LatitudSitio;
                    Session["Longitud"] = oSitioBO.LongitudSitio;
                }
                //CargarDropEdit
                DrpTipoSitioEdit.DataSource = owebService.tipoSitios();
                DrpTipoSitioEdit.DataValueField = "idTipoSitio";
                DrpTipoSitioEdit.DataTextField = "NombreSitio";
                DrpTipoSitioEdit.DataBind();
                DrpTipoSitioEdit.SelectedValue = oSitioBO.IdTipoSitio.ToString();
                //--------------------
                Session["arreglo1"] = oSitioBO.FotoSitio;
                FotoPre.ImageUrl = ConvertirImagenStringWebUrl((Byte[])Session["arreglo1"], "jpg");
                txtDireccionEdit.Text = oSitioBO.Direccion;
                txtNombreEdit.Focus();

            }
            catch(Exception ex)
            {

            }
           
        }
        #endregion

        #region EditarSitios
        private localhost.SitioBO RecuperarSitioEdit()
        {
            oSitioBO = new localhost.SitioBO();
            oSitioBO.IdSitio = Convert.ToInt32(txtidSitioEdit.Text);
            oSitioBO.NombreSitio = txtNombreEdit.Text ;
            oSitioBO.IdTipoSitio = Convert.ToInt32(txtTipoSitoEdit.Text);
            oSitioBO.Direccion = txtDireccionEdit.Text;
            oSitioBO.LatitudSitio = Convert.ToDecimal(Session["Latitud"]);
            oSitioBO.LongitudSitio = Convert.ToDecimal(Session["Longitud"]);
            oSitioBO.Historia = txtHistoriaEdit.Text ;
            oSitioBO.SucesoImportante =  txtSucesoImportantesEdit.Text ;
            oSitioBO.DescripcionSitio = txtDescripcionEdit.Text;
            oSitioBO.FotoSitio = (Byte[])Session["arreglo1"];
            return oSitioBO;
        }
        protected void btnVerNuevaFotoEdit_Click(object sender, EventArgs e)
        {
            LlenarControlesEdit();
            if (VerificarArchivoImgEdit() == true)
            {
                FotoPre.ImageUrl = (string)Session["Url"];
            }

        }
        private bool VerificarArchivoImgEdit()
        {
            if (FuFotoEdit.HasFile)
            {
                string ext = System.IO.Path.GetExtension(FuFotoEdit.FileName);
                if (ext == ".jpeg" || ext == ".jpg" || ext == ".png")
                {
                    //string path = Server.MapPath(@"\Recursos\");
                    //fu.SaveAs(path + fu.FileName);
                    HttpPostedFile imagen = FuFotoEdit.PostedFile;
                    int tamaño = imagen.ContentLength;
                    Byte[] arreglo = new Byte[tamaño];
                    imagen.InputStream.Read(arreglo, 0, tamaño);
                    Session["arreglo1"] = arreglo;
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

        protected void lbtnModificar_Click(object sender, EventArgs e)
        {
            int i = owebService.ModificarSitio(RecuperarSitioEdit());
            if (i > 0)
            {
                string script = "MensajeModificar()";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MensajeModificar", script, true);
                lblModificar.Text = "Datos modificados con éxito";
            }
            else
            {
                string script = "ErroModificar()";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "ErroModificar", script, true);
                lblModificar.Text = "Ocurrio un error";
            }
            Editar.Visible = true;
            pnlGestionSitios.Visible = false;
        }

        protected void btnMapEdit_Click(object sender, EventArgs e)
        {
            Session["Sitio"] = true;
            Session["ModificarMapaEdit"] = true;
            Response.Redirect("Maps.aspx");
        }

        protected void lbtnEliminar_Click(object sender, EventArgs e)
        {
            oSitioBO = new localhost.SitioBO();
            oSitioBO.IdSitio = Convert.ToInt32(txtidSitioEdit.Text.Trim());


            int i = owebService.EliminarSitio(oSitioBO);
            if (i > 0)
            {
                
                CargarSitios();
                //Panel
                Editar.Visible = false;
                pnlGestionSitios.Visible = true;
                
            }


        }
    }
    #endregion
}