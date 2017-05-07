using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MCTuristic_Centro_Historico.GUI
{
    public partial class GestionEstablecimientos : System.Web.UI.Page
    {
        localhost.WsMCTuristic owebService = new localhost.WsMCTuristic();
        double Latitud;
        double Longitud;
        localhost.EstablecimientoBO oEstablecimientoBO = new localhost.EstablecimientoBO();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                Editar.Visible = false;
                if (!IsPostBack)
                {
                    ValidarLogin();
                    bool Edit = Convert.ToBoolean(Session["Editar"]);
                    if (Edit == true)
                    {
                        Latitud = Convert.ToDouble(Session["Latitud"]);
                        Longitud = Convert.ToDouble(Session["Longitud"]);
                        LlenarControlesEdit();
                    }
                    Latitud = Convert.ToDouble(Session["Latitud"]);
                    Longitud = Convert.ToDouble(Session["Longitud"]);
                    if (Latitud == 0 && Longitud == 0)
                    {
                        lblMapsEstatus.Text = "Por favor seleccione su ubicación.";
                    }
                    else
                    {
                        lblMapsEstatus.Text = "Ubicación seleccionada.";
                    }


                }

                
            }
            catch (Exception ex)
            {

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
                CargarEstablecimientosAdmin();
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
                    CargarEstablecimientoUsuario(datos);
                }
            }
        }

        private void CargarEstablecimientoUsuario(localhost.UsuarioBO datos)
        {
            //Carga La tabla del Usuario
            localhost.EstablecimientoBO dato = new localhost.EstablecimientoBO();
            dato.IdUsuario = datos.IdUsuario;
            DataSet tablaEstablecimientos = owebService.establecimiento_UserWS(dato);
            ASPxGridView1.DataSource = tablaEstablecimientos;
            ASPxGridView1.DataBind();
        }

        private void CargarEstablecimientosAdmin()
        {
            ASPxGridView1.DataSource = owebService.establecimiento_AdminWS();
            ASPxGridView1.DataBind();
        }

      
        private localhost.EstablecimientoBO RecuperarDatos()
        {
            oEstablecimientoBO = new localhost.EstablecimientoBO();
            oEstablecimientoBO.NombreEstable = txtNombre.Text;
            oEstablecimientoBO.TelefonoEstable = txtTelefono.Text;
            oEstablecimientoBO.PagFacebook= txtFacebook.Text;
            oEstablecimientoBO.HoraInicioEstable = txtAbrir.Text;
            oEstablecimientoBO.HoraCierreEstable = txtCerrar.Text;
            oEstablecimientoBO.Latitud = Convert.ToDecimal(Session["Latitud"]);
            oEstablecimientoBO.Longitud = Convert.ToDecimal(Session["Longitud"]);
            ////string latitud = ((string)Session["Latitud"]).Replace('.', ',');
            ////string longi = ((string)Session["Longitud"]).Replace('.', ',');
            //oEstablecimientoBO.Latitud = Convert.ToDecimal(latitud);
            //oEstablecimientoBO.Longitud = Convert.ToDecimal(longi);
           
            oEstablecimientoBO.Foto = (Byte[])Session["arreglo"];
            if ((string)Session["idUser"] != "")
            {
                oEstablecimientoBO.IdUsuario = Convert.ToInt32((string)Session["idUser"]);
            }
            else
            {
                oEstablecimientoBO.IdUsuario = 1;
            }
            return oEstablecimientoBO;
        }

        protected void btnMaps_Click(object sender, EventArgs e)
        {
            Response.Redirect("Maps.aspx");
            //Logra que distiga entre sitios o Establecimientos
            Session["Sitio"] = false;
        }

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

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            if (VerificarArchivoImg() == true)
            {
                imgEstablecimiento.ImageUrl = (string)Session["Url"];
            }
        }

        protected void lbtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Latitud = Convert.ToDouble(Session["Latitud"]);
                if (txtNombre.Text != string.Empty && Latitud != 0)
                {
                    try
                    {
                        int i = owebService.InsertarEstablecimiento(RecuperarDatos());
                        try
                        {
                            if (i > 0)
                            {
                                LimpiarControles();
                            }
                        }
                        catch { }

                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                    if ((string)Session["idUser"] != "")
                    {
                        localhost.EstablecimientoBO dato = new localhost.EstablecimientoBO();
                        dato.IdUsuario = Convert.ToInt32((string)Session["idUser"]);
                        DataSet tablaEstablecimientos = owebService.establecimiento_UserWS(dato);
                        ASPxGridView1.DataSource = tablaEstablecimientos;
                        ASPxGridView1.DataBind();
                    }
                    else
                    {
                        CargarEstablecimientosAdmin();
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void LimpiarControles()
        {
            imgEstablecimiento.ImageUrl = "~/Recursos/images/Establecimiento.png";
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtFacebook.Text= string.Empty;
            txtAbrir.Text = string.Empty;
            txtCerrar.Text= string.Empty;
            ltdlngNull();
            lblMapsEstatus.Text = "Por favor seleccione su ubicación.";
        }

        protected void ASPxGridView1_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            if (e.CommandArgs.CommandArgument.ToString() == "Editar")
            {
                //lblNuevo.Visible = true;
                oEstablecimientoBO = new localhost.EstablecimientoBO();
                oEstablecimientoBO.IdEstablecimiento =Convert.ToInt32(ASPxGridView1.GetRowValues(e.VisibleIndex, "Código").ToString());
                oEstablecimientoBO.NombreEstable = ASPxGridView1.GetRowValues(e.VisibleIndex, "Nombre").ToString();
                oEstablecimientoBO.TelefonoEstable = ASPxGridView1.GetRowValues(e.VisibleIndex, "Teléfono").ToString();
                oEstablecimientoBO.HoraInicioEstable = ASPxGridView1.GetRowValues(e.VisibleIndex, "HoraInicio").ToString();
                oEstablecimientoBO.HoraCierreEstable = ASPxGridView1.GetRowValues(e.VisibleIndex, "HoraCierre").ToString();
                oEstablecimientoBO.PagFacebook = ASPxGridView1.GetRowValues(e.VisibleIndex, "PagFacebook").ToString();
                oEstablecimientoBO.Latitud =Convert.ToDecimal(ASPxGridView1.GetRowValues(e.VisibleIndex, "Latitud").ToString());
                oEstablecimientoBO.Longitud = Convert.ToDecimal(ASPxGridView1.GetRowValues(e.VisibleIndex, "Longitud").ToString());
                oEstablecimientoBO.Foto = (byte[])ASPxGridView1.GetRowValues(e.VisibleIndex, "Foto");
                oEstablecimientoBO.IdUsuario = Convert.ToInt32(ASPxGridView1.GetRowValues(e.VisibleIndex, "IdUsuario").ToString());
                Session["EstablecimientoEdit"] = oEstablecimientoBO;
                Session["Editar"] = true;
                ltdlngNull();
                LlenarControlesEdit();
            }
            if(e.CommandArgs.CommandArgument.ToString()== "Servicios")
            {
                Session["idEstablecimiento"] = ASPxGridView1.GetRowValues(e.VisibleIndex, "Código");
                Response.Redirect("GestionServicios.aspx");
            }
        }
        //Método para poner en 0 los parametros del marcador
        private void ltdlngNull()
        {
            Session["Latitud"] = 0;
            Session["Longitud"] = 0;
        }
        private void LlenarControlesEdit()
        {
            try
            {
                bool CodenadasMoficadas = Convert.ToBoolean(Session["ModificarMap"]);

                pnlGestionEstablecimientos.Visible = false;
                Editar.Visible = true;
                oEstablecimientoBO = (localhost.EstablecimientoBO)Session["EstablecimientoEdit"];
                txtIdEstablecimiento.Text = oEstablecimientoBO.IdEstablecimiento.ToString();
                txtNombreEdit.Text = oEstablecimientoBO.NombreEstable;
                txtTelefonoEdit.Text = oEstablecimientoBO.TelefonoEstable;
                txtHoraAbriEdit.Text = oEstablecimientoBO.HoraInicioEstable;
                txtHoraCierreEdit.Text = oEstablecimientoBO.HoraCierreEstable;
                txtFacebookEdit.Text = oEstablecimientoBO.PagFacebook;
                if (CodenadasMoficadas == false)
                {
                    Session["Latitud"] = oEstablecimientoBO.Latitud;
                    Session["Longitud"] = oEstablecimientoBO.Longitud;
                }
                Session["arreglo1"] = oEstablecimientoBO.Foto;
                FotoPre.ImageUrl = ConvertirImagenStringWebUrl((Byte[])Session["arreglo1"], "jpg");
                txtIDuserEdit.Text = oEstablecimientoBO.IdUsuario.ToString();
            }
            catch(Exception ex)
            {

            }
        
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            pnlGestionEstablecimientos.Visible = true;
            Editar.Visible = false;
            Session["Editar"] = false;
            lblMapsEstatus.Text = "Por favor seleccione su ubicación.";
            ltdlngNull();
            Session.Remove("EstablecimientoEdit");
            Session["ModificarMap"] = false;
            if((string)Session["idUser"] == "")
            {
                CargarEstablecimientosAdmin();
            }
        }

        protected void lbtnModificar_Click(object sender, EventArgs e)
        {
            int i = owebService.ModificarEstablecimiento(RecuperarEdit());
            if(i>0)
            {
                lblModificar.Text = "Datos modificados con éxito";
            }
            else
            {
                lblModificar.Text = "Ocurrio un error";
            }
            Editar.Visible = true;
            pnlGestionEstablecimientos.Visible = false;
        }
        private localhost.EstablecimientoBO RecuperarEdit()
        {
            oEstablecimientoBO = new localhost.EstablecimientoBO();
            oEstablecimientoBO.IdEstablecimiento = Convert.ToInt32(txtIdEstablecimiento.Text);
            oEstablecimientoBO.NombreEstable = txtNombreEdit.Text ;
            oEstablecimientoBO.TelefonoEstable = txtTelefonoEdit.Text ;
            oEstablecimientoBO.PagFacebook = txtFacebookEdit.Text ;
            oEstablecimientoBO.HoraInicioEstable = txtHoraAbriEdit.Text ;
            oEstablecimientoBO.HoraCierreEstable = txtHoraCierreEdit.Text ;
            oEstablecimientoBO.Latitud = Convert.ToDecimal(Session["Latitud"]);
            oEstablecimientoBO.Longitud = Convert.ToDecimal(Session["Longitud"]);
            oEstablecimientoBO.Foto = (Byte[])Session["arreglo1"];
            if ((string)Session["idUser"] != "")
            {
                oEstablecimientoBO.IdUsuario = Convert.ToInt32((string)Session["idUser"]);
            }
            else
            {
                oEstablecimientoBO.IdUsuario = 1;
            }
            return oEstablecimientoBO;
        }

        protected void lbtnEliminar_Click(object sender, EventArgs e)
        {
            oEstablecimientoBO.IdEstablecimiento = Convert.ToInt32(txtIdEstablecimiento.Text);
            int i = owebService.EliminarEstablecimiento(oEstablecimientoBO);
            if(i>0)
            {
                pnlGestionEstablecimientos.Visible = true;
                Editar.Visible = false;
                CargarEstablecimientosAdmin();
            }
            else
            {
                lblModificar.Text = "Ocurrio un problema";
            }

        }

        protected void mapaEdit_Click(object sender, EventArgs e)
        {
           
            Session["Sitio"] = false;
            Session["ModificarMapaEdit"] = true;
            Response.Redirect("Maps.aspx");
        }
    }
}