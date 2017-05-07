using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MCTuristic_Centro_Historico.GUI
{
    public partial class GestionEventos : System.Web.UI.Page
    {
        localhost.EventoBO oEvento = new localhost.EventoBO();
        localhost.WsMCTuristic servicio = new localhost.WsMCTuristic();
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
                txtIdSitio.Text = Session["idSitio"].ToString();
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
                lbtnGuardar.Visible = false;
                CargarGriw();
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
                    txtIdUsuario.Text = datos.IdUsuario.ToString();
                    CargarGriwUser();
                }
            }
        }




        // Grid del admin con los eventos de sitios específicos
        private void CargarGriw()
        {
            oEvento = new localhost.EventoBO();
            oEvento.IdSitio = Convert.ToInt32(txtIdSitio.Text);
            ASPxGridView1.DataSource = servicio.Ver_evento(oEvento);
            ASPxGridView1.DataBind();
        }




        // Grid del usuario con sus eventos de sitios específicos
        private void CargarGriwUser()
        {
            oEvento = new localhost.EventoBO();
            oEvento.IdSitio = Convert.ToInt32(txtIdSitio.Text);
            oEvento.IdUsuario = Convert.ToInt32(txtIdUsuario.Text);
            ASPxGridView1.DataSource = servicio.Ver_evento_user(oEvento);
            ASPxGridView1.DataBind();
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




        // Validación de la imagen de edición
        private bool VerificarArchivoImgEdit()
        {
            if (fuFoto2.HasFile)
            {
                string ext = System.IO.Path.GetExtension(fuFoto2.FileName);
                if (ext == ".jpeg" || ext == ".jpg" || ext == ".png")
                {
                    //string path = Server.MapPath(@"\Recursos\");
                    //fu.SaveAs(path + fu.FileName);
                    HttpPostedFile imagen = fuFoto2.PostedFile;
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
            // Detección de tipo de botón
            Button btn = (Button)sender;
            // Si es el botón subir para agregar nuevo evento
            if (btn.ID == "btnSubir")
            {
                if (VerificarArchivoImg() == true)
                {
                    imgEvento.ImageUrl = (string)Session["Url"];
                }
            }
            // Si no, es el botón de editar
            else
            {
                if (VerificarArchivoImgEdit() == true)
                {
                    imgEventoEdit.ImageUrl = (string)Session["Url"];
                }
            }
        }




        private localhost.EventoBO RecuperarDatos()
        {
            oEvento = new localhost.EventoBO();
            oEvento.NombreEvento = txtNombre.Text;
            oEvento.HoraFinalizacion = txtCerrar.Text;
            // Reemplazo de guiones por diagonales para el formato Date
            oEvento.HoraInicioEvento = txtAbrir.Text.Replace('-','/');
            oEvento.FechaFinalizacion = txtFechaFin.Text.Replace('-', '/');
            oEvento.FechaInicio = txtFechaIni.Text;
            oEvento.IdSitio = Convert.ToInt32(txtIdSitio.Text);
            oEvento.IdUsuario = Convert.ToInt32(txtIdUsuario.Text);
            oEvento.Foto = (Byte[])Session["arreglo"];
            return oEvento;
        }


        protected void ASPxGridView1_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            if (e.CommandArgs.CommandArgument.ToString() == "Editar")
            {
                pnlPrincipal.Visible = false;
                Editar.Visible = true;
                //lbtnNuevo.Visible = true;
                oEvento = new localhost.EventoBO();
                oEvento.IdEvento = Convert.ToInt32(ASPxGridView1.GetRowValues(e.VisibleIndex, "idEvento").ToString());
                oEvento.NombreEvento = ASPxGridView1.GetRowValues(e.VisibleIndex, "NombreEvent").ToString();
                oEvento.HoraInicioEvento = ASPxGridView1.GetRowValues(e.VisibleIndex, "HoroInicio").ToString();
                oEvento.HoraFinalizacion = ASPxGridView1.GetRowValues(e.VisibleIndex, "HoraFinalizacion").ToString();
                oEvento.FechaInicio = ASPxGridView1.GetRowValues(e.VisibleIndex, "FechaIncio").ToString();
                oEvento.FechaFinalizacion = ASPxGridView1.GetRowValues(e.VisibleIndex, "FechaFinalizacion").ToString();
                oEvento.Foto = (byte[])ASPxGridView1.GetRowValues(e.VisibleIndex, "Foto");
                oEvento.IdSitio = Convert.ToInt32(ASPxGridView1.GetRowValues(e.VisibleIndex, "IdSitio").ToString());
                oEvento.IdUsuario = Convert.ToInt32(ASPxGridView1.GetRowValues(e.VisibleIndex, "IdUsuario").ToString());
                Session["Editar"] = true;
                txtIdEventoEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "idEvento").ToString();
                txtIdSitioEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "IdSitio").ToString();
                txtIdUsuarioEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "IdUsuario").ToString();
                //ltdlngNull();
                LlenarControlesEdit(oEvento);
            }
        }




        private void LimpiarControles()
        {
            txtIdEventoEdit.Text = string.Empty;
            txtNombreEventoEdit.Text = string.Empty;
            txtHoraFinEdit.Text = string.Empty;
            txtHoraInicioEdit.Text = string.Empty;
            txtFechaFinEdit.Text = string.Empty;
            txtFechaInicioEdit.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtCerrar.Text = string.Empty;
            txtAbrir.Text = string.Empty;
            txtFechaFin.Text = string.Empty;
            txtFechaIni.Text = string.Empty;
            imgEvento.ImageUrl = "~/Recursos/images/FotoEventoPre.png";
        }




        private void LlenarControlesEdit(localhost.EventoBO evento)
        {
            txtIdEventoEdit.Text = oEvento.IdEvento.ToString();
            txtNombreEventoEdit.Text = oEvento.NombreEvento ;
            txtHoraFinEdit.Text = oEvento.HoraFinalizacion;
            txtHoraInicioEdit.Text = oEvento.HoraInicioEvento;
            txtFechaFinEdit.Text = oEvento.FechaFinalizacion;
            txtFechaInicioEdit.Text = oEvento.FechaInicio;
            txtIdSitioEdit.Text = oEvento.IdSitio.ToString();
            txtIdUsuarioEdit.Text = oEvento.IdUsuario.ToString();
            Session["arreglo"] = oEvento.Foto;
        }




        protected void lbtnModificar_Click(object sender, EventArgs e)
        {
            int i = servicio.ModificarEvento(RecuperarInformacioEdit());
            if (i > 0)
            {
                lblModificar.Text = "Datos modificados con éxito";
            }
            else
            {
                lblModificar.Text = "Ocurrio un error";
            }
            Editar.Visible = true;
            pnlPrincipal.Visible = false;

        }
        private localhost.EventoBO RecuperarInformacioEdit()
        {
            txtIdSitio.Text = Session["idSitio"].ToString();
            oEvento = new localhost.EventoBO();
            oEvento.IdEvento = Convert.ToInt32(txtIdEventoEdit.Text);
            oEvento.NombreEvento = txtNombreEventoEdit.Text;
            oEvento.HoraFinalizacion = txtHoraFinEdit.Text;
            oEvento.HoraInicioEvento = txtHoraInicioEdit.Text;
            oEvento.FechaFinalizacion = txtFechaFinEdit.Text;
            oEvento.FechaInicio = txtFechaInicioEdit.Text;
            oEvento.IdSitio = Convert.ToInt32(txtIdSitioEdit.Text);
            oEvento.IdUsuario = Convert.ToInt32(txtIdUsuarioEdit.Text);
            oEvento.Foto = (Byte[])Session["arreglo"];
            return oEvento;
        }

        protected void lbtnEliminar_Click(object sender, EventArgs e)
        {
            oEvento.IdEvento = Convert.ToInt32(txtIdEventoEdit.Text);
            int i = servicio.EliminarEvento(oEvento);
            if (i > 0)
            {
                pnlPrincipal.Visible = true;
                Editar.Visible = false;
                ValidarLogin();
            }
        }

        protected void lbtnGuardar_Click(object sender, EventArgs e)
        {

            if (txtIdSitio.Text != string.Empty && txtIdUsuario.Text != string.Empty)
            {
                try
                {
                    int i = servicio.InsertarEvento(RecuperarDatos());
                    if (i > 0)
                    {
                        LimpiarControles();
                    }

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                ValidarLogin();
            }
        }

    }
}