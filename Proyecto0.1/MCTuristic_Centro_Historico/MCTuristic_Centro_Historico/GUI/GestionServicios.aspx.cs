using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MCTuristic_Centro_Historico.GUI
{
    public partial class GestionServicios : System.Web.UI.Page
    {
        localhost.WsMCTuristic owebService = new localhost.WsMCTuristic();
        localhost.ServicioBO oServico = new localhost.ServicioBO();
        public int establecimiento;
        public int tipoServicio;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtIdEstablecimiento.Text = Session["idEstablecimiento"].ToString();
            if (!IsPostBack)
            {
                ValidarLogin();
                ListarDropdow();

            }

            CargarGriw();
       
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
        

        private void ListarDropdow()
        {
            ddlTipoServicio.DataSource = owebService.tipoServicioWS();
            ddlTipoServicio.DataValueField = "Código";
            ddlTipoServicio.DataTextField = "Nombre";
            ddlTipoServicio.DataBind();
    
        }

        protected void ddlTipoServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdTipoServicio.Text = ddlTipoServicio.SelectedItem.Value.ToString();
        }
        private localhost.ServicioBO RecuperarDatos()
        {
            oServico = new localhost.ServicioBO();
            oServico.NombreServicio = txtNombreServicio.Text;
            oServico.OfertaServicio = txtOferta.Text;
            oServico.PrecioServicio =Convert.ToDecimal(txtPrecio.Text);
            oServico.DescripcionServicio = txtDescripcion.Text;
            oServico.IdTipoServicio =Convert.ToInt32(txtIdTipoServicio.Text);
            oServico.IdEstablecimiento =Convert.ToInt32( txtIdEstablecimiento.Text);
            oServico.Popularidad = 0;
            oServico.Foto = (Byte[])Session["arreglo"];
            return oServico;
        }
        protected void btnSubir_Click(object sender, EventArgs e)
        {
            if (VerificarArchivoImg() == true)
            {
                imgServicios.ImageUrl = (string)Session["Url"];
            }
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

        protected void lbtnGuardar_Click(object sender, EventArgs e)
        {
           
            if ( txtIdEstablecimiento.Text != string.Empty && txtIdTipoServicio.Text  != string.Empty)
            {
                try
                {
                    int i = owebService.InsertarServicio(RecuperarDatos());
                    if (i > 0)
                    {
                        LimpiarControles();
                    }

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                CargarGriw();
            }
        }
        private void LimpiarControles()
        {
            txtNombreServicio.Text = string.Empty;
            txtOferta.Text = string.Empty;
            txtPrecio.Text = string.Empty;
           txtDescripcion.Text = string.Empty;
           txtIdTipoServicio.Text = string.Empty;
            imgServicios.ImageUrl = "~/images1/cubiertos.png";
            ListarDropdow();
        }
        private void CargarGriw()
        {
            oServico = new localhost.ServicioBO();
            oServico.IdEstablecimiento = Convert.ToInt32(Session["idEstablecimiento"]);
            ASPxGridView1.DataSource = owebService.topServicios_admin(oServico);
            ASPxGridView1.DataBind(); 
        }

        protected void ASPxGridView1_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            if (e.CommandArgs.CommandArgument.ToString() == "Editar")
            {
               
                pnlGestionServicios.Visible = false;
                Editar.Visible = true;
                //lblNuevo.Visible = true;
                txtCodServicioEdit.Text =ASPxGridView1.GetRowValues(e.VisibleIndex, "idServicio").ToString();
                txtNombreServEdit.Text  = ASPxGridView1.GetRowValues(e.VisibleIndex, "NombreServ").ToString();
                 txtOfertaEdit.Text  = ASPxGridView1.GetRowValues(e.VisibleIndex, "OfertaServicio").ToString();
                txtPrecioEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "PreciosServicio").ToString();
                txtDescripcionEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "DescripServicio").ToString();
                txtPopularidadEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Popularidad").ToString();
                drpTipoServicio.DataSource = owebService.tipoServicioWS();
                drpTipoServicio.DataValueField = "Código";
                drpTipoServicio.DataTextField = "Nombre";
                drpTipoServicio.DataBind();
                txtIdTipoServicioEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "idTipoServ").ToString();
                drpTipoServicio.SelectedValue = ASPxGridView1.GetRowValues(e.VisibleIndex, "idTipoServ").ToString();
                Session["arreglo1"] = (byte[])ASPxGridView1.GetRowValues(e.VisibleIndex, "Foto");
                FotoPre.ImageUrl = ConvertirImagenStringWebUrl((Byte[])Session["arreglo1"], "jpg");
               
            }
        }

        protected void lbtnNuevo_Click(object sender, EventArgs e)
        {
            pnlGestionServicios.Visible = Visible;
            Editar.Visible = false;
        }

        protected void lbtnModificar_Click(object sender, EventArgs e)
        {
            int i = owebService.ModificarServicio(RecuperarInformacioEdit());
            if (i > 0)
            {
                lblModificar.Text = "Datos modificados con éxito";
            }
            else
            {
                lblModificar.Text = "Ocurrio un error";
            }
            Editar.Visible = true;
           pnlGestionServicios.Visible = false;

        }
        private localhost.ServicioBO RecuperarInformacioEdit()
        {
            txtIdEstablecimiento.Text = Session["idEstablecimiento"].ToString();
            oServico = new localhost.ServicioBO();
            oServico.IdServicio =Convert.ToInt32(txtCodServicioEdit.Text);
            oServico.NombreServicio = txtNombreServEdit.Text;
            oServico.OfertaServicio = txtOfertaEdit.Text;
            oServico.PrecioServicio = Convert.ToDecimal( txtPrecioEdit.Text );
            oServico.DescripcionServicio = txtDescripcionEdit.Text;
            oServico.IdTipoServicio = Convert.ToInt32(txtIdTipoServicioEdit.Text);
            oServico.IdEstablecimiento = Convert.ToInt32(txtIdEstablecimiento.Text);
            oServico.Popularidad = Convert.ToInt32(txtPopularidadEdit.Text) ;
            oServico.Foto = (Byte[])Session["arreglo1"];
            return oServico;
        }

        protected void drpTipoServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
           txtIdTipoServicioEdit.Text  = ddlTipoServicio.SelectedItem.Value.ToString();
        }

        protected void lbtnEliminar_Click(object sender, EventArgs e)
        {
            oServico.IdServicio =Convert.ToInt32(txtCodServicioEdit.Text);
            int i = owebService.EliminarServicio(oServico);
            if(i>0)
            {
                pnlGestionServicios.Visible = true;
                Editar.Visible = false;
                CargarGriw();
            }
        }
    }
}