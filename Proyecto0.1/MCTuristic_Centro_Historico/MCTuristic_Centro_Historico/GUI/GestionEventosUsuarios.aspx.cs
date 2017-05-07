using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;
using net.tipstrade.FCMNet.Requests;
using net.tipstrade.FCMNet.Responses;
using net.tipstrade.FCMNet.Converters;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace MCTuristic_Centro_Historico.GUI
{
    public partial class GestionEventosUsuarios : System.Web.UI.Page
    {
        localhost.EventoBO oEvento = new localhost.EventoBO();
        localhost.WsMCTuristic servicio = new localhost.WsMCTuristic();
        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!IsPostBack)
            {
                CargarDropTipoSitios();
                ValidarLogin();

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
                lbtnGuardar.Visible = false;
                
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
        //private void CargarGriwUser()
        //{
        //    oEvento = new localhost.EventoBO();
        //    oEvento.IdSitio = Convert.ToInt32(txtIdSitio.Text);
        //    oEvento.IdUsuario = Convert.ToInt32(txtIdUsuario.Text);
        //    ASPxGridView1.DataSource = servicio.Ver_evento_user(oEvento);
        //    ASPxGridView1.DataBind();
        //}
        private void CargarGriwUser()
        {
            oEvento = new localhost.EventoBO();
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
            oEvento.HoraInicioEvento = txtAbrir.Text;
            oEvento.FechaFinalizacion = txtFechaFin.Text.Replace('-', '/');
            oEvento.FechaInicio = txtFechaIni.Text.Replace('-', '/');
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

        private void CargarDropTipoSitios()
        {
            ddlTipoSitio.DataSource = servicio.sitio_WS();
            ddlTipoSitio.DataValueField = "Código";
            ddlTipoSitio.DataTextField = "Nombre";
            ddlTipoSitio.DataBind();
        }



        protected void ddlTipoSitio_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdSitio.Text = ddlTipoSitio.SelectedItem.Value.ToString();
        }



        private void LlenarControlesEdit(localhost.EventoBO evento)
        {
            txtIdEventoEdit.Text = oEvento.IdEvento.ToString();
            txtNombreEventoEdit.Text = oEvento.NombreEvento;
            txtHoraFinEdit.Text = oEvento.HoraFinalizacion;
            txtHoraInicioEdit.Text = oEvento.HoraInicioEvento;
            txtFechaFinEdit.Text = oEvento.FechaFinalizacion;
            txtFechaInicioEdit.Text = oEvento.FechaInicio;
            txtIdSitioEdit.Text = oEvento.IdSitio.ToString();
            txtIdUsuarioEdit.Text = oEvento.IdUsuario.ToString();
            Session["arreglo"] = oEvento.Foto;
            Session["idSitio"] = oEvento.IdSitio;
            imgEventoEdit.ImageUrl = ConvertirImagenStringWebUrl((Byte[])Session["arreglo"], "jpg");
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
            try
            {txtIdSitio.Text = Session["idSitio"].ToString();
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
            }
            catch
            {
               
            }
            
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
                        generarNotificacion();
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

        protected void lbtnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionEventosUsuarios.aspx");
        }

        private AndroidFCMPushNotificationStatus generarNotificacion()
        {
            // se declara un objeto para conocer el resultado de la operación de las notificaciones
            AndroidFCMPushNotificationStatus result = new AndroidFCMPushNotificationStatus();
            // Se obtienen los dispositivos registrados en la base de datos
            DataSet dispositivos = servicio.Wver_dispositivos();
            try
            {
                result.Successful = false;
                result.Error = null;
                // se asigna a una variable el API Key del servidor
                var serverApiKey = "AAAAOeEWXC0:APA91bFTH3uQ8mNWoFb065DW2zcIqaTVAXo-yNPTZDfh4xIhqLSrA97S14c17ZGxUK1nTGPOx0SFgAxUyLdM3ZBhxdzaJ4A5-2j5GSNzdEaIhRYJ-sHf4DQxP5Io7TYeFoUR4KT1Zvf9";
                // se asigna a una variable el ID del remitente (servidor)
                var senderId = "248589474861";
                // se asigna a una variable el nombre del evento 
                var value = txtNombre.Text;
                // se obtiene la tabla de los dispositivos
                DataTable tabla = dispositivos.Tables[0];
                // se recorren las filas de la tabla para obtener los valores de los Token
                foreach (DataRow token in tabla.Rows)
                {
                    // se asigna a una variable el Token del dispositivo (según la fila)
                    var deviceId = Convert.ToString(token["token"]);

                    // se crea un WebReques para el envío de las notividaciones
                    WebRequest tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send ");
                    // método "post" para declarar que es una notificación
                    tRequest.Method = "post";
                    // declarar tipo de contenido (android lo maneja por archivos json)
                    tRequest.ContentType = "application/json";
                    // declaración de variable data para contener la información en formato json
                    var data = new
                    {
                        // se asigna a qué dispositivo va dirigida la notificación
                        to = deviceId,
                        notification = new
                        {
                            // se asigna el texto de la notificación
                            body = value,
                            title = "Evento nuevo",
                            icon = "myicon",
                            sound ="Enabled"

                        }
                    };

                    // variable para convertir la información en formato json
                    var serializer = new JavaScriptSerializer();
                    var json = serializer.Serialize(data);

                    // arreglo de bytes para asignar los datos del formato json
                    Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                    // se agrega la autorización por medio del API Key del servidor
                    tRequest.Headers.Add(string.Format("Authorization: key={0}", serverApiKey));
                    // se agrega el remitente
                    tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));

                    tRequest.ContentLength = byteArray.Length;


                    // se realiza el proceso de envío de la notificación al servidor y ser reenviado todos los dispositivos móviles
                    using (Stream dataStream = tRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);

                        using (WebResponse tResponse = tRequest.GetResponse())
                        {
                            using (Stream dataStreamResponse = tResponse.GetResponseStream())
                            {
                                using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                {
                                    String sResponseFromServer = tReader.ReadToEnd();
                                    result.Response = sResponseFromServer;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Successful = false;
                result.Response = null;
                result.Error = ex;
            }

            return result;
        }

        public class AndroidFCMPushNotificationStatus
        {
            public bool Successful
            {
                get;
                set;
            }

            public string Response
            {
                get;
                set;
            }
            public Exception Error
            {
                get;
                set;
            }
        }

    }
}