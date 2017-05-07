using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace MCTuristic_Centro_Historico.GUI
{
    public partial class GestionAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ValidarLogin();
                CargarAdmin();
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

        public string ConvertirImagenStringWebUrl(Byte[] arreglo,
    string extension)
        {
            string url = Convert.ToBase64String(arreglo, 0, arreglo.Length);
            url = "data:image/" + extension + "jpeg;base64," + url;
            return url;
        }


        //Gestión Admin
        #region Controles AJAX
        [WebMethod]
        public static string GuardarAdmin(string nombre, string apellido, string correo, string contra, string telefono, string fecha)
        {
            localhost.WsMCTuristic owebService = new localhost.WsMCTuristic();
            localhost.AdministradorBO oAdministradorBO = new localhost.AdministradorBO();
            oAdministradorBO.Nombreadmin = nombre;
            oAdministradorBO.Apellidosadmin = apellido;
            oAdministradorBO.Email = correo;
            oAdministradorBO.Contraseñaadmin = contra;
            oAdministradorBO.Telefonoadmin = telefono;
            oAdministradorBO.Fechanacimiento = fecha;
            int i = owebService.InsertarAdministrador(oAdministradorBO);

            if (i > 0)
            {
                return "Operación exitosa";
            }
            return "Fallo la operación";

        }
        public static string GuardarDireccion(string calle, string numero, string estado, string cruz, string cp, string col, string descripcion)
        {
            localhost.WsMCTuristic owebService = new localhost.WsMCTuristic();
            localhost.DireccionBO oDireccionBO = new localhost.DireccionBO();

            oDireccionBO.Calle = calle;
            oDireccionBO.Numero = numero;
            oDireccionBO.Estado = estado;
            oDireccionBO.Cruzamiento = cruz;
            oDireccionBO.CodPostal = cp;
            oDireccionBO.Colonia = col;
            oDireccionBO.DescripcionDireccion = descripcion;
            oDireccionBO.IdAdministrador = Convert.ToInt32(owebService.obtener_adminid());
            int i = owebService.InsertarDireccion_admin(oDireccionBO);
            if (i > 0)
            {
                return "Operación exitosa";
            }
            return "Fallo la operación";

        }
        protected void lbtnGuardar_Click1(object sender, EventArgs e)
        {
            try
            {
                if (txtNumero.Text != string.Empty)
                {
                    GuardarAdmin(txtNombre.Text.Trim(), txtApellidos.Text.Trim(), txtCorreo.Text.Trim(), txtContrasena.Text.Trim(), txtTelefono.Text.Trim(), txtFecha.Text.Trim());
                    GuardarDireccion(txtCalle.Text.Trim(), txtNumero.Text.Trim(), txtEstado.Text.Trim(), txtCruzamiento.Text.Trim(), txtCP.Text.Trim(), txtColonia.Text.Trim(), txtDescripcion.Text.Trim());
                    CargarAdmin();
                }

            }
            catch
            { }
        }
        #endregion

        //----------------Eventos-------------------------------



        protected void lbtnModificar_Click(object sender, EventArgs e)
        {
            CargarAdmin();
        }

        protected void ASPxGridView1_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
             if (e.CommandArgs.CommandArgument.ToString() == "Editar")
             {
                GestionNuevo.Visible = false;
                Editar.Visible = true;
                lblNuevo.Visible = true;
                txtIDAdmin.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "IdAdministrador").ToString();
                txtIdDireccion.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "idDireccion").ToString();
                txtNombreEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Nombre").ToString();
                txtApellidosEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Apellidos").ToString();
                txtCorreoEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Email").ToString();
                txtTelefonoEdit.Text  = ASPxGridView1.GetRowValues(e.VisibleIndex, "TelefonoCelular").ToString();
                txtFechaNEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "FechaNacimiento").ToString();
                txtCalleEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Calle").ToString();
                txtCruzamientoEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Cruzamiento").ToString();
                txtNumeroCalleEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Numero").ToString();
                txtColoniaEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Colonia").ToString();
                txtDescripcionEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Descripcion").ToString();
                txtEstadoEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Estado").ToString();
                txtCodigoPostalEdit.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "CodPostal").ToString();
               
            }

        }

        protected void lblNuevo_Click(object sender, EventArgs e)
        {
            Editar.Visible = false;
            GestionNuevo.Visible = true;
            lblNuevo.Visible = false;
            lblEstado.Text = "";
        }

        protected void lbtnModificar_Click1(object sender, EventArgs e)
        {
            ModificarAdmin();
            CargarAdmin();
        }

        protected void lBntEliminar_Click(object sender, EventArgs e)
        {
            localhost.WsMCTuristic owebService = new localhost.WsMCTuristic();
            localhost.DireccionBO oDireccionBO = new localhost.DireccionBO();
            localhost.AdministradorBO oAdministradorBO = new localhost.AdministradorBO();
            oDireccionBO.IdDireccion = Convert.ToInt32(txtIdDireccion.Text);
            oAdministradorBO.IdAdministrador = Convert.ToInt32(txtIDAdmin.Text);
            int i = owebService.EliminarDireccion(oDireccionBO);
            if (i > 0)
            {
                int y = owebService.EliminarAdministrador(oAdministradorBO);
                if (y > 0)
                {
                    CargarAdmin();
                    Editar.Visible = false;
                    GestionNuevo.Visible = true;
                }
            }

        }

        //--------------Métodos----------------------------------------
        private void CargarAdmin()
        {
            localhost.WsMCTuristic owebService = new localhost.WsMCTuristic();
            ASPxGridView1.DataSource = owebService.ver_Admin_admin();
            ASPxGridView1.DataBind();

        }
        private void ModificarAdmin()
        {
            lblEstado.Text = "Procesando...";
            localhost.WsMCTuristic owebService = new localhost.WsMCTuristic();
            localhost.AdministradorBO oAdministradorBO = new localhost.AdministradorBO();
            oAdministradorBO.IdAdministrador =Convert.ToInt32( txtIDAdmin.Text);
            oAdministradorBO.Nombreadmin = txtNombreEdit.Text ;
            oAdministradorBO.Apellidosadmin = txtApellidosEdit.Text;
            oAdministradorBO.Email = txtCorreoEdit.Text;
            oAdministradorBO.Telefonoadmin = txtTelefonoEdit.Text;
            oAdministradorBO.Fechanacimiento = txtFechaNEdit.Text;
            int i = owebService.ModificarAdministrador(oAdministradorBO);
            if (i > 0)
            {
                ModificarDireccion();   
            }
        }
        private void ModificarDireccion()
        {
            localhost.WsMCTuristic owebService = new localhost.WsMCTuristic();
            localhost.DireccionBO oDireccionBO = new localhost.DireccionBO();
            oDireccionBO.IdDireccion = Convert.ToInt32(txtIdDireccion.Text);
            oDireccionBO.Calle = txtCalleEdit.Text;
            oDireccionBO.Numero = txtNumeroCalleEdit.Text ;
            oDireccionBO.Estado = txtEstadoEdit.Text;
            oDireccionBO.Cruzamiento = txtCruzamientoEdit.Text;
            oDireccionBO.CodPostal = txtCodigoPostalEdit.Text;
            oDireccionBO.Colonia = txtColoniaEdit.Text;
            oDireccionBO.DescripcionDireccion = txtDescripcionEdit.Text;
            oDireccionBO.IdAdministrador = Convert.ToInt32(txtIDAdmin.Text);
            int i = owebService.ModificarDireccion_admin(oDireccionBO);
            if (i > 0)
            {
                lblEstado.Text = "Cambios Guardados con éxito";
            }
            else
            {
                lblEstado.Text = "Error, Verificar si los campos estan llenos";
            }
        }


        //protected void ASPxGridView1_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        //{
        //    if (e.CommandArgs.CommandArgument.ToString() == "Editar")
        //    {
        //        //txtNombre.Text = ASPxGridView1.GetRowValues(e.VisibleIndex, "Nombre").ToString();
        //    }
        //}
        //protected void ASPxGridView1_FocusedRowChanged(object sender, EventArgs e)
        //{

        //}
    }
}