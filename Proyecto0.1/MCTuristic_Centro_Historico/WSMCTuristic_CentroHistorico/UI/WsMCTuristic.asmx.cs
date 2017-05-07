using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Script.Serialization;
using WSMCTuristic_CentroHistorico.BO;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;

namespace WSMCTuristic_CentroHistorico.UI
{
    /// <summary>
    /// Descripción breve de WsMCTuristic
    /// </summary>
    [WebService(Namespace = "http://MCTuristic.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WsMCTuristic : System.Web.Services.WebService
    {
        Services.CtrlUsuario oUsuarioCTRL;
        Services.CtrlDireccion oDireccionCTRL;
        Services.CtrlEstablecimiento oEstablecimiento;
        Services.CtrlEvento oEventoCTRL;
        Services.CtrlNotificaciones oNotificacionesCTRL;
        Services.CtrlServicio oServicioCTRL;
        Services.CtrlSitio oSitioCtrl;
        Services.CtrlSoporte oSoporteCTRL;
        Services.CtrlTipoServicio oTipoServicioCTRL;
        Services.CtrlTipoSitio oTipoSitioCtrl;
        Services.CtrlTipoSuscripcion oTipoSuscripcionCTRL;
        Services.CtrlContactanos oContactanosCTRL;
        Services.CtrlAdministrador oAdministradorCTRL;
        Services.CtrlComentario oComentariosCTRL;
        Services.CtrlSuscripcion oSuscripcionCTRL;


        //--------------------------ABC Usuarios-----------------------------
        #region "Gestión de Usuarios"  
        [WebMethod]
        public int InsertarUsuario(UsuarioBO obj)
        {
            UsuarioBO oUsuario = new UsuarioBO();
            oUsuario = obj;
            oUsuarioCTRL = new Services.CtrlUsuario();
            return oUsuarioCTRL.InsertarUsuario(oUsuario);
        }
        [WebMethod]
        public int ModificarUsuario(UsuarioBO obj)
        {
            UsuarioBO oUsuario = new UsuarioBO();
            oUsuario = obj;
            oUsuarioCTRL = new Services.CtrlUsuario();
            return oUsuarioCTRL.ModificarUsuario(oUsuario);
        }
        [WebMethod]
        public int EliminarUsuario(UsuarioBO obj)
        {
            UsuarioBO oUsuario = new UsuarioBO();
            oUsuario = obj;
            oUsuarioCTRL = new Services.CtrlUsuario();
            return oUsuarioCTRL.EliminarUsuario(oUsuario);
        }
        [WebMethod]
        public string obtener_usuarioid()
        {
            oUsuarioCTRL = new Services.CtrlUsuario();
            return oUsuarioCTRL.id_usuario();
        }
        [WebMethod]
        public DataTable LoginUsuario(UsuarioBO obj)
        {
            UsuarioBO oUsuario = obj;
            oUsuarioCTRL = new Services.CtrlUsuario();
            return oUsuarioCTRL.LoginUsuario(oUsuario);
        }
        //Nuevo webmethod Diosemir Nah
        [WebMethod]
        public DataSet usuario_adminWS()
        {
            oUsuarioCTRL = new Services.CtrlUsuario();
            return oUsuarioCTRL.topUsuarios_admin();
        }
        //Nuevo webmethod Diosemir Nah
        [WebMethod]
        public DataSet usuario_adminFiltradosWS()
        {
            oUsuarioCTRL = new Services.CtrlUsuario();
            return oUsuarioCTRL.topUsuarios_adminFiltrados();
        }
        //Nuevo webmethod Diosemir Nah
        [WebMethod]
        public DataSet usuario_userWS(UsuarioBO obj)
        {
            UsuarioBO oUsuario = new UsuarioBO();
            oUsuario = obj;
            oUsuarioCTRL = new Services.CtrlUsuario();
            return oUsuarioCTRL.topUsuarios_User(oUsuario);
        }
        #endregion

        //--------------------------ABC Direcciones-----------------------------
        #region "Gestión de Direccciones"
        [WebMethod]

        public int EliminarDireccion(DireccionBO obj)
        {
            DireccionBO oDireccion = new DireccionBO();
            oDireccion = obj;
            oDireccionCTRL = new Services.CtrlDireccion();
            return oDireccionCTRL.EliminarDireccion(oDireccion);
        }

        [WebMethod]
        public int InsertarDireccion(DireccionBO obj)
        {
            DireccionBO oDireccion = new DireccionBO();
            oDireccion = obj;
            oDireccionCTRL = new Services.CtrlDireccion();
            return oDireccionCTRL.InsertarDireccion(oDireccion);
        }
        [WebMethod]
        public int ModificarDireccion(DireccionBO obj)
        {
            DireccionBO oDireccion = new DireccionBO();
            oDireccion = obj;

            oDireccionCTRL = new Services.CtrlDireccion();
            return oDireccionCTRL.ModificarDireccion(oDireccion);
        }

        //......Admin
        [WebMethod]
        public int InsertarDireccion_admin(DireccionBO obj)
        {
            DireccionBO oDireccion = new DireccionBO();
            oDireccion = obj;
            oDireccionCTRL = new Services.CtrlDireccion();
            return oDireccionCTRL.InsertarDireccion_admin(oDireccion);
        }
        [WebMethod]
        public int ModificarDireccion_admin(DireccionBO obj)
        {
            DireccionBO oDireccion = new DireccionBO();
            oDireccion = obj;

            oDireccionCTRL = new Services.CtrlDireccion();
            return oDireccionCTRL.ModificarDireccion_admin(oDireccion);
        }
        #endregion

        //---------------------ABC Establecimiento-----------------------
        #region "Gestión de Establecimientos"
        [WebMethod]
        public int InsertarEstablecimiento(BO.EstablecimientoBO obj)
        {
            BO.EstablecimientoBO oEstablecimientoBO = new BO.EstablecimientoBO();
            oEstablecimientoBO = obj;
            oEstablecimiento = new Services.CtrlEstablecimiento();
            return oEstablecimiento.insertarEstablecimiento(oEstablecimientoBO);
        }

        [WebMethod]
        public int ModificarEstablecimiento(BO.EstablecimientoBO obj)
        {
            BO.EstablecimientoBO oEstablecimientoBO = new BO.EstablecimientoBO();
            oEstablecimientoBO = obj;
            oEstablecimiento = new Services.CtrlEstablecimiento();
            return oEstablecimiento.ModificarEstablecimiento(oEstablecimientoBO);
        }

        [WebMethod]
        public int EliminarEstablecimiento(BO.EstablecimientoBO obj)
        {
            BO.EstablecimientoBO oEstablecimientoBO = new BO.EstablecimientoBO();
            oEstablecimientoBO = obj;
            oEstablecimiento = new Services.CtrlEstablecimiento();
            return oEstablecimiento.EliminarEstablecimiento(oEstablecimientoBO);
        }

        //Nuevo webmethod Diosemir Nah
        [WebMethod]
        public DataSet establecimiento_UserWS(EstablecimientoBO obj)
        {
            EstablecimientoBO datos = obj;
            oEstablecimiento = new Services.CtrlEstablecimiento();
            return oEstablecimiento.topEstablecimientos_userDS(datos);
        }
        [WebMethod]
        //Nuevo webmethod Diosemir Nah

        public DataSet establecimiento_AdminWS()
        {
            oEstablecimiento = new Services.CtrlEstablecimiento();
            return oEstablecimiento.topEstablecimientos_adminDS();
        }
        #endregion

        //--------------------------ABC Evento-----------------------------
        #region "Gestión de Evento"

        [WebMethod]
        public int InsertarEvento(BO.EventoBO obj)
        {
            BO.EventoBO oEventoBO = new BO.EventoBO();
            oEventoBO = obj;
            oEventoCTRL = new Services.CtrlEvento();
            return oEventoCTRL.InsertarEvento(oEventoBO);
        }

        [WebMethod]
        public int ModificarEvento(BO.EventoBO obj)
        {
            BO.EventoBO oEventoBO = new BO.EventoBO();
            oEventoBO = obj;

            oEventoCTRL = new Services.CtrlEvento();
            return oEventoCTRL.ModificarEvento(oEventoBO);
        }
        [WebMethod]
        public int EliminarEvento(BO.EventoBO obj)
        {
            BO.EventoBO oEventoBO = new BO.EventoBO();
            oEventoBO = obj;

            oEventoCTRL = new Services.CtrlEvento();
            return oEventoCTRL.EliminarEvento(oEventoBO);
        }
        [WebMethod]
        public DataSet Ver_evento(BO.EventoBO obj)
        {
            BO.EventoBO oEventoBO = new BO.EventoBO();
            oEventoBO = obj;
            oEventoCTRL = new Services.CtrlEvento();
            return oEventoCTRL.ver_Eventos(oEventoBO);
        }

        [WebMethod]
        public DataSet Ver_evento_user(BO.EventoBO obj)
        {
            BO.EventoBO oEventoBO = new BO.EventoBO();
            oEventoBO = obj;
            oEventoCTRL = new Services.CtrlEvento();
            return oEventoCTRL.ver_Eventos_user(oEventoBO);
        }




        [WebMethod]
        public DataSet Ver_evento_admin(BO.EventoBO obj)
        {
            BO.EventoBO oEventoBO = new BO.EventoBO();
            oEventoBO = obj;
            oEventoCTRL = new Services.CtrlEvento();
            return oEventoCTRL.ver_Eventos_admin(oEventoBO);
        }
        #endregion
        //--------------------------ABC Notificaciones-----------------------------

        #region "Gestión de Notificaciones" 
        [WebMethod]
        public int InsertarNotificacion(BO.NotificacionesBO obj)
        {
            BO.NotificacionesBO oNotificacionesBO = new BO.NotificacionesBO();
            oNotificacionesBO = obj;

            oNotificacionesCTRL = new Services.CtrlNotificaciones();
            return oNotificacionesCTRL.InsertarNotificacion(oNotificacionesBO);
        }

        [WebMethod]
        public int ModificarNotificaciones(BO.NotificacionesBO obj)
        {
            BO.NotificacionesBO oNotificacionesBO = new BO.NotificacionesBO();
            oNotificacionesBO = obj;

            oNotificacionesCTRL = new Services.CtrlNotificaciones();
            return oNotificacionesCTRL.ModificarNotificacion(oNotificacionesBO);
        }

        [WebMethod]
        public int EliminarNotificaciones(BO.NotificacionesBO obj)
        {
            BO.NotificacionesBO oNotificacionesBO = new BO.NotificacionesBO();
            oNotificacionesBO = obj;

            oNotificacionesCTRL = new Services.CtrlNotificaciones();
            return oNotificacionesCTRL.EliminarNotificacion(oNotificacionesBO);
        }
        #endregion
        //--------------------------ABC Servicio-----------------------------
        #region "Gestión de Servicios Productos"
        [WebMethod]
        public int InsertarServicio(BO.ServicioBO obj)
        {
            BO.ServicioBO oServicioBO = new BO.ServicioBO();
            oServicioBO = obj;

            oServicioCTRL = new Services.CtrlServicio();
            return oServicioCTRL.InsertarServicio(oServicioBO);
        }


        [WebMethod]
        public int ModificarServicio(BO.ServicioBO obj)
        {
            BO.ServicioBO oServicioBO = new BO.ServicioBO();
            oServicioBO = obj;

            oServicioCTRL = new Services.CtrlServicio();
            return oServicioCTRL.ModificarServicio(oServicioBO);
        }

        [WebMethod]
        public int EliminarServicio(BO.ServicioBO obj)
        {
            BO.ServicioBO oServicioBO = new BO.ServicioBO();
            oServicioBO = obj;

            oServicioCTRL = new Services.CtrlServicio();
            return oServicioCTRL.EliminarServicio(oServicioBO);
        }


        [WebMethod]
        //Nuevo webmethod Diosemir Nah
        public DataSet top12Servicios()
        {
            oServicioCTRL = new Services.CtrlServicio();
            return oServicioCTRL.top12Servicios();
        }

        [WebMethod]
        //Nuevo webmethod Diosemir Nah
        public DataSet ver_DetallProducto(BO.ServicioBO obj)
        {
            BO.ServicioBO oServicioBO = new BO.ServicioBO();
            oServicioBO = obj;
            oServicioCTRL = new Services.CtrlServicio();
            return oServicioCTRL.ver_DetalleProducto(obj);
        }


        [WebMethod]
        //Nuevo webmethod Diosemir Nah
        public DataSet topServicios(BO.ServicioBO obj)
        {
            BO.ServicioBO oServicioBO = new BO.ServicioBO();
            oServicioBO = obj;
            oServicioCTRL = new Services.CtrlServicio();
            return oServicioCTRL.topServicios_user(obj);
        }
        [WebMethod]
        //Nuevo webmethod Diosemir Nah
        public DataSet topServicios_admin(BO.ServicioBO obj)
        {
            BO.ServicioBO oServicioBO = new BO.ServicioBO();
            oServicioBO = obj;
            oServicioCTRL = new Services.CtrlServicio();
            return oServicioCTRL.topServicios_admin(oServicioBO);
        }
        [WebMethod]
        public byte[] verFotoSer(int Ser)
        {
            oServicioCTRL = new Services.CtrlServicio();
            return oServicioCTRL.verfoto(Ser);
        }
        #endregion
        //--------------------- ABC Sitio---------------
        #region "Gestión de Sitios"
        [WebMethod]
        public int InsertarSitio(SitioBO obj)
        {
            SitioBO oSitio = new SitioBO();
            oSitio = obj;

            oSitioCtrl = new Services.CtrlSitio();
            return oSitioCtrl.InsertarSitio(oSitio);
        }
        [WebMethod]
        public int ModificarSitio(SitioBO obj)
        {
            SitioBO oSitio = new SitioBO();
            oSitio = obj;

            oSitioCtrl = new Services.CtrlSitio();
            return oSitioCtrl.ModificarSitio(oSitio);
        }
        [WebMethod]
        public int EliminarSitio(SitioBO obj)
        {
            SitioBO oSitio = new SitioBO();
            oSitio = obj;

            oSitioCtrl = new Services.CtrlSitio();
            return oSitioCtrl.EliminarSitio(oSitio);
        }
        [WebMethod]
        //Nuevo webmethod Diosemir Nah
        public DataSet sitio_WS()
        {
            oSitioCtrl = new Services.CtrlSitio();
            return oSitioCtrl.topSitioDS();
        }
        #endregion
        //------------ABC Soporte-------------------
        #region "Gestión de Soporte técnico"
        [WebMethod]
        public int InsertarSoporte(SoporteBO obj)
        {
            SoporteBO oSoporte = obj;
            oSoporteCTRL = new Services.CtrlSoporte();
            return oSoporteCTRL.InsertarSoporte(oSoporte);
        }
        [WebMethod]
        public int ModificarSoporte(SoporteBO obj)
        {
            SoporteBO oSoporte = obj;
            oSoporteCTRL = new Services.CtrlSoporte();
            return oSoporteCTRL.ModificarSoporte(oSoporte);
        }
        [WebMethod]
        public int EliminarSoporte(SoporteBO obj)
        {
            SoporteBO oSoporte = obj;
            oSoporteCTRL = new Services.CtrlSoporte();
            return oSoporteCTRL.EliminarSoporte(oSoporte);
        }
        #endregion
        //----------------ABC TipoServicio -----------
        #region "Gestión de Tipo de Servicio"
        [WebMethod]
        public int InsertarTipoServicio(TipoServicioBO obj)
        {
            TipoServicioBO oTipoServicio = obj;
            oTipoServicioCTRL = new Services.CtrlTipoServicio();
            return oTipoServicioCTRL.InsertarTipoServicio(oTipoServicio);
        }
        [WebMethod]
        public int ModificarTipoServicio(TipoServicioBO obj)
        {
            TipoServicioBO oTipoServicio = obj;
            oTipoServicioCTRL = new Services.CtrlTipoServicio();
            return oTipoServicioCTRL.ModificarTipoServicio(oTipoServicio);
        }
        [WebMethod]
        public int EliminarTipoServicio(TipoServicioBO obj)
        {
            TipoServicioBO oTipoServicio = obj;
            oTipoServicioCTRL = new Services.CtrlTipoServicio();
            return oTipoServicioCTRL.EliminarTipoServicio(oTipoServicio);
        }
        //Nuevo webmethod Diosemir Nah
        [WebMethod]
        public DataSet tipoServicioWS()
        {
            oTipoServicioCTRL = new Services.CtrlTipoServicio();
            return oTipoServicioCTRL.topTipoServicios();






        }
        #endregion
        //------------- ABC TipoSitio ----------------
        #region "Gestión de Tipo de Sitio"
        [WebMethod]
        public int InsertarTipoSitio(TipoSitioBO obj)
        {
            TipoSitioBO oTipoSitio = obj;
            oTipoSitioCtrl = new Services.CtrlTipoSitio();
            return oTipoSitioCtrl.InsertarTipoSitio(oTipoSitio);
        }
        [WebMethod]
        public int ModificarTipoSitio(TipoSitioBO obj)
        {
            TipoSitioBO oTipoSitio = obj;
            oTipoSitioCtrl = new Services.CtrlTipoSitio();
            return oTipoSitioCtrl.ModificarTipoSitio(oTipoSitio);
        }
        [WebMethod]
        public int EliminarTipoSitio(TipoSitioBO obj)
        {
            TipoSitioBO oTipoSitio = obj;
            oTipoSitioCtrl = new Services.CtrlTipoSitio();
            return oTipoSitioCtrl.EliminarTipoSitio(oTipoSitio);
        }
        [WebMethod]
        public DataSet tipoSitios()
        {
            oTipoSitioCtrl = new Services.CtrlTipoSitio();
            return oTipoSitioCtrl.tipoSitio();
        }
        #endregion

        //------------ ABC TipoSuscripcion --------------
        #region "Tipo de Suscripción"
        [WebMethod]
        public int InsertarTipoSuscripcion(TipoSuscripcionBO obj)
        {
            TipoSuscripcionBO oTipoSuscripcion = obj;
            oTipoSuscripcionCTRL = new Services.CtrlTipoSuscripcion();
            return oTipoSuscripcionCTRL.InsertarTipoSuscripcion(oTipoSuscripcion);
        }
        [WebMethod]
        public int ModificarTipoSuscripcion(TipoSuscripcionBO obj)
        {
            TipoSuscripcionBO oTipoSuscripcion = obj;
            oTipoSuscripcionCTRL = new Services.CtrlTipoSuscripcion();
            return oTipoSuscripcionCTRL.ModificarTipoSuscripcion(oTipoSuscripcion);
        }
        [WebMethod]
        public int EliminarTipoSuscripcion(TipoSuscripcionBO obj)
        {
            TipoSuscripcionBO oTipoSuscripcion = obj;
            oTipoSuscripcionCTRL = new Services.CtrlTipoSuscripcion();
            return oTipoSuscripcionCTRL.EliminarTipoSuscripcion(oTipoSuscripcion);
        }
        #endregion
        //---------------------ABC Contactanos --------------
        #region "Gestión de contactanos"
        [WebMethod]
        public int InsertarContactanos(ContactanosBO obj)
        {
            ContactanosBO oContactanos = obj;
            oContactanosCTRL = new Services.CtrlContactanos();
            return oContactanosCTRL.InsertarContactanos(oContactanos);
        }
        [WebMethod]
        public int ModificarContactanos(ContactanosBO obj)
        {
            ContactanosBO oContactanos = obj;
            oContactanosCTRL = new Services.CtrlContactanos();
            return oContactanosCTRL.ModificarContactanos(oContactanos);
        }
        [WebMethod]
        public int EliminarContactanos(ContactanosBO obj)
        {
            ContactanosBO oContactanos = obj;
            oContactanosCTRL = new Services.CtrlContactanos();
            return oContactanosCTRL.EliminarContactanos(oContactanos);
        }
        #endregion
        //---------------------ABC Administrador-----------------
        #region "Gestión de Administrador"
        [WebMethod]
        public string obtener_adminid()
        {
            oAdministradorCTRL = new Services.CtrlAdministrador();
            return oAdministradorCTRL.id_admin();
        }
        [WebMethod]
        public DataTable Login(AdministradorBO obj)
        {
            AdministradorBO oAdministrador = obj;
            oAdministradorCTRL = new Services.CtrlAdministrador();
            return oAdministradorCTRL.LoginUsuario(oAdministrador);
        }

        [WebMethod]
        public DataSet Ver_admin_log(AdministradorBO obj)
        {
            AdministradorBO oAdministrador = obj;
            oAdministradorCTRL = new Services.CtrlAdministrador();
            return oAdministradorCTRL.Ver_admin_log(oAdministrador);
        }

        [WebMethod]
        public DataSet ver_Admin_admin()
        {
            oAdministradorCTRL = new Services.CtrlAdministrador();
            return oAdministradorCTRL.ver_admi_admin();
        }

        [WebMethod]
        public int InsertarAdministrador(AdministradorBO obj)
        {
            AdministradorBO oAdministrador = obj;
            oAdministradorCTRL = new Services.CtrlAdministrador();
            return oAdministradorCTRL.InsertarAdministrador(oAdministrador);
        }
        [WebMethod]
        public int ModificarAdministrador(AdministradorBO obj)
        {
            AdministradorBO oAdministrador = obj;
            oAdministradorCTRL = new Services.CtrlAdministrador();
            return oAdministradorCTRL.ModificarAdministrador(oAdministrador);
        }
        [WebMethod]
        public int EliminarAdministrador(AdministradorBO obj)
        {
            AdministradorBO oAdministrador = obj;
            oAdministradorCTRL = new Services.CtrlAdministrador();
            return oAdministradorCTRL.EliminarAdministrador(oAdministrador);
        }
        #endregion

        //------------- ABC Comentarios -----------------------
        #region "Gestión de Comentarios"
        [WebMethod]
        public int InsertarComentarios(ComentariosBO obj)
        {
            ComentariosBO oComentarios = obj;
            oComentariosCTRL = new Services.CtrlComentario();
            return oComentariosCTRL.InsertarComentarios(oComentarios);
        }
        [WebMethod]
        public int ModificarComentarios(ComentariosBO obj)
        {
            ComentariosBO oComentarios = obj;
            oComentariosCTRL = new Services.CtrlComentario();
            return oComentariosCTRL.ModificarComentarios(oComentarios);
        }
        [WebMethod]
        public int EliminarComentarios(ComentariosBO obj)
        {
            ComentariosBO oComentarios = obj;
            oComentariosCTRL = new Services.CtrlComentario();
            return oComentariosCTRL.EliminarComentarios(oComentarios);
        }
        #endregion
        //------------- ABC Suscripción -----------------------
        #region "Gestión de suscripción"
        [WebMethod]
        public int InsertarSuscripcion(SuscripcionBO obj)
        {
            SuscripcionBO oSuscripcion = obj;
            oSuscripcionCTRL = new Services.CtrlSuscripcion();
            return oSuscripcionCTRL.InsertarSuscripcion(oSuscripcion);
        }
        [WebMethod]
        public int ModificarSuscripcion(SuscripcionBO obj)
        {
            SuscripcionBO oSuscripcion = obj;
            oSuscripcionCTRL = new Services.CtrlSuscripcion();
            return oSuscripcionCTRL.ModificarSuscripcion(oSuscripcion);
        }
        [WebMethod]
        public int EliminarSuscripcion(SuscripcionBO obj)
        {
            SuscripcionBO oSuscripcion = obj;
            oSuscripcionCTRL = new Services.CtrlSuscripcion();
            return oSuscripcionCTRL.EliminarSuscripcion(oSuscripcion);
        }
        #endregion
        //------------- Móvil ---------------------------------
        #region "Acciones móvil"
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Winsertar_dispositivo(string Token)
        {
            oUsuarioCTRL = new Services.CtrlUsuario();
            oUsuarioCTRL.insertar_dispositivo(Token);
        }
        #endregion

        [WebMethod]
        public DataSet Wver_dispositivos()
        {
            oUsuarioCTRL = new Services.CtrlUsuario();
            return oUsuarioCTRL.ver_dispositivos();
        }



        //-----------------Pruebas de web_móvil letra de asignación
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Wver_servicios_movil()
        {

            oServicioCTRL = new Services.CtrlServicio();
            //Creamos un dataset para poder resivirlo de las clases
            DataSet DSmvil = new DataSet();
            //Asignamos la consulta directa de la base de datos.

            DSmvil = oServicioCTRL.top12Servicios();
            //Creamos un DataTable para poder transportarlo a Json.
            DataTable Tabla = DSmvil.Tables[0];

            //Creamos un string para poder asignarle la salida en formato Json.
            string SalidaJson = string.Empty;
            SalidaJson = JsonConvert.SerializeObject(Tabla);

            HttpContext Contexto = HttpContext.Current;
            Context.Response.ContentType = "application/json";
            Context.Response.Write(SalidaJson);
            Context.Response.End();
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Wver_servicios_movil2(string Nombre)
        {

            oServicioCTRL = new Services.CtrlServicio();
            //Creamos un dataset para poder resivirlo de las clases
            DataSet DSmvil = new DataSet();
            //Asignamos la consulta directa de la base de datos.

            DSmvil = oServicioCTRL.top12Servicios();
            //Creamos un DataTable para poder transportarlo a Json.
            DataTable Tabla = DSmvil.Tables[0];

            //Creamos un string para poder asignarle la salida en formato Json.
            string SalidaJson = string.Empty;
            SalidaJson = JsonConvert.SerializeObject(Tabla);

            HttpContext Contexto = HttpContext.Current;
            Context.Response.ContentType = "application/json";
            Context.Response.Write(SalidaJson);
            Context.Response.End();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

        public void WtipoServicioWS_movil()
        {
            oTipoServicioCTRL = new Services.CtrlTipoServicio();

            DataSet DSmvil = new DataSet();
            //Asignamos la consulta directa de la base de datos.

            DSmvil = oTipoServicioCTRL.topTipoServicios();
            //Creamos un DataTable para poder transportarlo a Json.
            DataTable Tabla = DSmvil.Tables[0];

            //Creamos un string para poder asignarle la salida en formato Json.
            string SalidaJson = string.Empty;
            SalidaJson = JsonConvert.SerializeObject(Tabla);

            HttpContext Contexto = HttpContext.Current;
            Context.Response.ContentType = "application/json";
            Context.Response.Write(SalidaJson);
            Context.Response.End();



        }


        //Recuperara imagenes Servicios.
        [WebMethod]
        public byte[] WverFotoSer_movil(int Ser)
        {
            oServicioCTRL = new Services.CtrlServicio();
            //return oServicioCTRL.verfoto(Ser);
            byte[] foto = oServicioCTRL.verfoto(Ser);
            ImageConverter ic = new ImageConverter();
            Image img = (Image)ic.ConvertFrom(foto);

            //Cración de un nuevo lienzo de trabajo
            var newImage = new Bitmap(400, 400);
            //Se dibuja la imagen para poder pasarla al lienzo.
            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(img, 0, 0, 400, 400);

            //Se convierte a una matriz depediendo del formato de salida.
            MemoryStream ms = new MemoryStream();
            //Recepcionamos la imangen nueva generada y la convertimos.
            newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();

        }





        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]

        //public void Wver_sitiosMovil_all()
        //{
        //    oSitioCtrl = new Services.CtrlSitio();
        //    DataSet Datos = oSitioCtrl.topSitioDS();
        //    DataTable tabla = Datos.Tables[0];

        //    DataTable TablaNueva = tabla.Clone();




        //   foreach (DataRow row in tabla.Rows)
        //    {
              
        //        var codigo = Convert.ToInt32(row["Código"]);
        //        var  Nombre = Convert.ToString(row["Nombre"]);

        //        byte[] foto =(byte[])row["Foto"];

        //        ImageConverter ic = new ImageConverter();
        //        Image img = (Image)ic.ConvertFrom(foto);

        //        //Cración de un nuevo lienzo de trabajo
        //        var newImage = new Bitmap(400, 400);
        //        //Se dibuja la imagen para poder pasarla al lienzo.
        //        using (var graphics = Graphics.FromImage(newImage))
        //            graphics.DrawImage(img, 0, 0, 400, 400);

        //        //Se convierte a una matriz depediendo del formato de salida.
        //        MemoryStream ms = new MemoryStream();
        //        //Recepcionamos la imangen nueva generada y la convertimos.
        //        newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        var Foto1 = ms.ToArray();


        //        DataRow Row2 = TablaNueva.NewRow();

        //        Row2["Código"] = codigo;

        //        Row2["Nombre"] = Nombre;

        //        Row2["Foto"] = Foto1;

        //        TablaNueva.Rows.Add(Row2);

                
        //    }

        //    EnviarJson(TablaNueva);
        //}


        public void EnviarJson(DataTable dt)
        {
            string SalidaJson = string.Empty;
            SalidaJson = JsonConvert.SerializeObject(dt);
            HttpContext Contexto = HttpContext.Current;
            Context.Response.ContentType = "application/json";
            Context.Response.Write(SalidaJson);
            Context.Response.End();
        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Wver_sitiosMovil_all()
        {
            oSitioCtrl = new Services.CtrlSitio();
            DataSet Datos = oSitioCtrl.topSitioDS();
            DataTable tabla = Datos.Tables[0];

            DataTable TablaNueva = new DataTable();
            TablaNueva.Columns.Add("Código", typeof(int));
            TablaNueva.Columns.Add("Nombre", typeof(String));
            TablaNueva.Columns.Add("Foto", typeof(Array));

            foreach (DataRow row in tabla.Rows)
            {

                var codigo = Convert.ToInt32(row["Código"]);
                var Nombre = Convert.ToString(row["Nombre"]);

                byte[] foto = (byte[])row["Foto"];

                ImageConverter ic = new ImageConverter();
                Image img = (Image)ic.ConvertFrom(foto);

                //Cración de un nuevo lienzo de trabajo
                var newImage = new Bitmap(400, 400);
                //Se dibuja la imagen para poder pasarla al lienzo.
                using (var graphics = Graphics.FromImage(newImage))
                    graphics.DrawImage(img, 0, 0, 400, 400);

                //Se convierte a una matriz depediendo del formato de salida.
                MemoryStream ms = new MemoryStream();
                //Recepcionamos la imangen nueva generada y la convertimos.
                newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                var Foto1 = ms.ToArray();


                DataRow Row2 = TablaNueva.NewRow();

                Row2["Código"] = codigo;

                Row2["Nombre"] = Nombre;

                Row2["Foto"] = Foto1;

                TablaNueva.Rows.Add(Row2);


            }

            EnviarJson(TablaNueva);
        }


        //Se encarga de listar el sitio por id para la descripción

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Wver_sitiosMovil_id(int id)
        {
            oSitioCtrl = new Services.CtrlSitio();
            DataSet Datos = oSitioCtrl.topSitio_id(id);
            DataTable tabla = Datos.Tables[0];

            DataTable TablaNueva = new DataTable();
            TablaNueva.Columns.Add("Código", typeof(int));
            TablaNueva.Columns.Add("Nombre", typeof(String));
            TablaNueva.Columns.Add("Descripción", typeof(String));
            TablaNueva.Columns.Add("Sucesosimportantes", typeof(String));
            TablaNueva.Columns.Add("Historia", typeof(String));
            TablaNueva.Columns.Add("Dirección", typeof(String));
            TablaNueva.Columns.Add("Latitud", typeof(Double));
            TablaNueva.Columns.Add("Longitud", typeof(Double));
            TablaNueva.Columns.Add("idTipoSitio", typeof(int));

            foreach (DataRow row in tabla.Rows)
            {

                var codigo = Convert.ToInt32(row["Código"]);
                var Nombre = Convert.ToString(row["Nombre"]);
                var Descripcion = Convert.ToString(row["Descripción"]);
                var sucesosimportantes = Convert.ToString(row["Sucesosimportantes"]);
                var  Historia = Convert.ToString(row["Historia"]);
                var Direccion = Convert.ToString(row["Dirección"]);
                var Latitud = Convert.ToDouble(row["Latitud"]);
                var longitud = Convert.ToDouble(row["Longitud"]);
                var idTipoSitio = Convert.ToInt32(row["idTipoSitio"]);


                //Instancia cada Row para asignarle a cada fila el valor que le corresponde
                DataRow Row2 = TablaNueva.NewRow();

                Row2["Código"] = codigo;
                Row2["Nombre"] = Nombre;
                Row2["Descripción"] = Descripcion;
                Row2["Sucesosimportantes"] = sucesosimportantes;
                Row2["Historia"] = Historia;
                Row2["Dirección"] = Direccion;
                Row2["Latitud"] = Latitud;
                Row2["Longitud"] = longitud;
                Row2["idTipoSitio"] = idTipoSitio;
                //Final agrega la fila completa
                TablaNueva.Rows.Add(Row2);

            }

            EnviarJson(TablaNueva);
        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Wver_sitiosMovil_Descripcion()
        {
            oSitioCtrl = new Services.CtrlSitio();
            DataSet Datos = oSitioCtrl.topSitioDS();
            DataTable tabla = Datos.Tables[0];

            DataTable TablaNueva = new DataTable();
            TablaNueva.Columns.Add("Código", typeof(int));
            TablaNueva.Columns.Add("Nombre", typeof(String));
            TablaNueva.Columns.Add("Descripción", typeof(String));
            TablaNueva.Columns.Add("Sucesosimportantes", typeof(String));
            TablaNueva.Columns.Add("Historia", typeof(String));
            TablaNueva.Columns.Add("Dirección", typeof(String));
            TablaNueva.Columns.Add("Latitud", typeof(Double));
            TablaNueva.Columns.Add("Longitud", typeof(Double));
            TablaNueva.Columns.Add("idTipoSitio", typeof(int));

            foreach (DataRow row in tabla.Rows)
            {

                var codigo = Convert.ToInt32(row["Código"]);
                var Nombre = Convert.ToString(row["Nombre"]);
                var Descripcion = Convert.ToString(row["Descripción"]);
                var sucesosimportantes = Convert.ToString(row["Sucesosimportantes"]);
                var Historia = Convert.ToString(row["Historia"]);
                var Direccion = Convert.ToString(row["Dirección"]);
                var Latitud = Convert.ToDouble(row["Latitud"]);
                var longitud = Convert.ToDouble(row["Longitud"]);
                var idTipoSitio = Convert.ToInt32(row["idTipoSitio"]);


                //Instancia cada Row para asignarle a cada fila el valor que le corresponde
                DataRow Row2 = TablaNueva.NewRow();

                Row2["Código"] = codigo;
                Row2["Nombre"] = Nombre;
                Row2["Descripción"] = Descripcion;
                Row2["Sucesosimportantes"] = sucesosimportantes;
                Row2["Historia"] = Historia;
                Row2["Dirección"] = Direccion;
                Row2["Latitud"] = Latitud;
                Row2["Longitud"] = longitud;
                Row2["idTipoSitio"] = idTipoSitio;
                //Final agrega la fila completa
                TablaNueva.Rows.Add(Row2);

            }

            EnviarJson(TablaNueva);
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Wver_establecimiento_movil_Descripcion()
        {
            oEstablecimiento = new Services.CtrlEstablecimiento();
            DataSet DsEstablecimientos = new DataSet();
            DsEstablecimientos = oEstablecimiento.topEstablecimientos_adminDS();
            DataTable tabla = DsEstablecimientos.Tables[0];
          




            DataTable TablaNueva = new DataTable();
            TablaNueva.Columns.Add("Código", typeof(int));
            TablaNueva.Columns.Add("Nombre", typeof(String));
            TablaNueva.Columns.Add("HoraInicio", typeof(String));
            TablaNueva.Columns.Add("HoraCierre", typeof(String));
            TablaNueva.Columns.Add("Latitud", typeof(Double));
            TablaNueva.Columns.Add("Longitud", typeof(Double));
   

           
            foreach (DataRow row in tabla.Rows)
            {

             var codigo = Convert.ToInt32(row["Código"]);
                var Nombre = Convert.ToString(row["Nombre"]);
                var HorarioInicio = Convert.ToString(row["HoraInicio"]);
                var HoarioCierre = Convert.ToString(row["HoraCierre"]);
                 var Latitud = Convert.ToDouble(row["Latitud"]);
                var longitud = Convert.ToDouble(row["Longitud"]);
               


                //Instancia cada Row para asignarle a cada fila el valor que le corresponde
                DataRow Row2 = TablaNueva.NewRow();

                Row2["Código"] = codigo;
                Row2["Nombre"] = Nombre;
                Row2["HoraInicio"] = HorarioInicio;
                Row2["HoraCierre"] = HoarioCierre;
                Row2["Latitud"] = Latitud;
                Row2["Longitud"] = longitud;
                //Final agrega la fila completa
                TablaNueva.Rows.Add(Row2);

            }
             EnviarJson(TablaNueva);

        }

        //Evento para mostrar los Servicios
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void WverServicios_TipoSitio(string Sitio)
        {
            oServicioCTRL = new Services.CtrlServicio();
            DataSet Servicios = new DataSet();
            Servicios = oServicioCTRL.Servicios_TipoSitio(Sitio);
            DataTable tabla = Servicios.Tables[0];

            DataTable TablaNueva = new DataTable();
            TablaNueva.Columns.Add("idServicio", typeof(int));
            TablaNueva.Columns.Add("NombreServ", typeof(String));
            TablaNueva.Columns.Add("PreciosServicio", typeof(Double));
            TablaNueva.Columns.Add("Popularidad", typeof(int));
            TablaNueva.Columns.Add("Foto", typeof(Array));
            TablaNueva.Columns.Add("NombreUsuario", typeof(String));
            TablaNueva.Columns.Add("Apellidos", typeof(String));
            TablaNueva.Columns.Add("FotoUsuario", typeof(Array));

            TablaNueva.Columns.Add("Longitud", typeof(Double));
            TablaNueva.Columns.Add("Latitud", typeof(Double));





            foreach (DataRow row in tabla.Rows)
            {

                var idServicio = Convert.ToInt32(row["idServicio"]);
                var NombreServ = Convert.ToString(row["NombreServ"]);
                var PreciosServicio = Convert.ToDouble(row["PreciosServicio"]);
                var Latitud = Convert.ToDouble(row["Latitud"]);
                var longitud = Convert.ToDouble(row["Longitud"]);
                byte[] foto = (byte[])row["Foto"];

                ImageConverter ic = new ImageConverter();
                Image img = (Image)ic.ConvertFrom(foto);

                //Cración de un nuevo lienzo de trabajo
                var newImage = new Bitmap(400, 400);
                //Se dibuja la imagen para poder pasarla al lienzo.
                using (var graphics = Graphics.FromImage(newImage))
                    graphics.DrawImage(img, 0, 0, 400, 400);

                //Se convierte a una matriz depediendo del formato de salida.
                MemoryStream ms = new MemoryStream();
                //Recepcionamos la imangen nueva generada y la convertimos.
                newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                var Foto1 = ms.ToArray();

                var Popularidad = Convert.ToInt32(row["Popularidad"]);
                var NombreUsuario = Convert.ToString(row["NombreUsuario"]);
                var Apellidos = Convert.ToString(row["Apellidos"]);



                byte[] FotoUsuario = (byte[])row["FotoUsuario"];

                ImageConverter ics = new ImageConverter();
                Image imgs = (Image)ics.ConvertFrom(foto);

                //Cración de un nuevo lienzo de trabajo
                var newImage1 = new Bitmap(150, 150);
                //Se dibuja la imagen para poder pasarla al lienzo.
                using (var graphics = Graphics.FromImage(newImage1))
                    graphics.DrawImage(imgs, 0, 0, 150, 150);


                //Se convierte a una matriz depediendo del formato de salida.
                MemoryStream mss = new MemoryStream();
                //Recepcionamos la imangen nueva generada y la convertimos.
                newImage.Save(mss, System.Drawing.Imaging.ImageFormat.Jpeg);
                var FotoUser = mss.ToArray();


                DataRow Row2 = TablaNueva.NewRow();



                Row2["idServicio"] = idServicio;

                Row2["NombreServ"] = NombreServ;

                Row2["PreciosServicio"] = PreciosServicio;
                Row2["Popularidad"] = Popularidad;
                Row2["Foto"] = Foto1;
                Row2["NombreUsuario"] = NombreServ;
                Row2["Apellidos"] = Apellidos;
                Row2["FotoUsuario"] = FotoUser;

                Row2["Latitud"] = Latitud;
                Row2["Longitud"] = longitud;


                TablaNueva.Rows.Add(Row2);


            }

            EnviarJson(tabla);
            
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void WsVerEventos_Date(string Dia)
        {
           
            oEventoCTRL = new Services.CtrlEvento();
            DataSet Eventos = new DataSet();
            Eventos = oEventoCTRL.Wver_Eventos_date(Dia);
            DataTable tabla = Eventos.Tables[0];


            DataTable TablaNueva = new DataTable();
            TablaNueva.Columns.Add("idEvento", typeof(int));
            TablaNueva.Columns.Add("NombreEvent", typeof(String));
            TablaNueva.Columns.Add("Foto", typeof(Array));
            TablaNueva.Columns.Add("FechaIncio", typeof(string));
            TablaNueva.Columns.Add("Nombre", typeof(string));
            TablaNueva.Columns.Add("FotoUser", typeof(Array));
            TablaNueva.Columns.Add("idSitio", typeof(int));
            TablaNueva.Columns.Add("HoroInicio", typeof(string));

            TablaNueva.Columns.Add("Longitud", typeof(Double));
            TablaNueva.Columns.Add("Latitud", typeof(Double));

            foreach (DataRow row in tabla.Rows)
            {

                var idEvento = Convert.ToInt32(row["idEvento"]);
                var NombreEvent = Convert.ToString(row["NombreEvent"]);
                string FechaInicio1 = Convert.ToString(row["FechaIncio"]);
                var FechaIncio = FechaInicio1.Substring(0, 10);
                // var FechaIncio = Convert.ToString(row["FechaIncio"]);

                var Nombre = Convert.ToString(row["Nombre"]);
                var idSitio = Convert.ToInt32(row["idSitio"]);
                var HoroInicio = Convert.ToString(row["HoroInicio"]);
                byte[] foto = (byte[])row["Foto"];
                var Latitud = Convert.ToDouble(row["Latitud"]);
                var longitud = Convert.ToDouble(row["Longitud"]);


                ImageConverter ic = new ImageConverter();
                Image img = (Image)ic.ConvertFrom(foto);

                //Cración de un nuevo lienzo de trabajo
                var newImage = new Bitmap(400, 400);
                //Se dibuja la imagen para poder pasarla al lienzo.
                using (var graphics = Graphics.FromImage(newImage))
                    graphics.DrawImage(img, 0, 0, 400, 400);

                //Se convierte a una matriz depediendo del formato de salida.
                MemoryStream ms = new MemoryStream();
                //Recepcionamos la imangen nueva generada y la convertimos.
                newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                var Foto1 = ms.ToArray();

             

                byte[] FotoUsuario = (byte[])row["FotoUser"];

                ImageConverter ics = new ImageConverter();
                Image imgs = (Image)ics.ConvertFrom(foto);

                //Cración de un nuevo lienzo de trabajo
                var newImage1 = new Bitmap(150, 150);
                //Se dibuja la imagen para poder pasarla al lienzo.
                using (var graphics = Graphics.FromImage(newImage1))
                    graphics.DrawImage(imgs, 0, 0, 150, 150);


                //Se convierte a una matriz depediendo del formato de salida.
                MemoryStream mss = new MemoryStream();
                //Recepcionamos la imangen nueva generada y la convertimos.
                newImage.Save(mss, System.Drawing.Imaging.ImageFormat.Jpeg);
                var FotoUser = mss.ToArray();


                DataRow Row2 = TablaNueva.NewRow();



                Row2["idEvento"] = idEvento;

                Row2["NombreEvent"] = NombreEvent;

                Row2["Foto"] = Foto1;
                Row2["HoroInicio"] = HoroInicio;
                Row2["FechaIncio"] = FechaIncio;
                Row2["Nombre"] = Nombre;
                Row2["FotoUser"] = FotoUser;
                Row2["idSitio"] = idSitio;
                Row2["Latitud"] = Latitud;
                Row2["Longitud"] = longitud;
                   TablaNueva.Rows.Add(Row2);
            }

            EnviarJson(TablaNueva);



        }


    }
}
