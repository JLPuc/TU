using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WSMCTuristic_CentroHistorico.DAO
{
    public class EventoDAO
    {

        SqlCommand cmd;
        Conexion conn;
        BO.EventoBO oEventoBO;

        public int InsertarEvento(object obj)
        {
            cmd = new SqlCommand();
            conn = new Conexion();
            oEventoBO = (BO.EventoBO)obj;

            cmd.Connection = conn.Establecer();
            cmd.CommandText = "insertar_evento";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@NombreEvent", SqlDbType.VarChar).Value = oEventoBO.NombreEvento;
            cmd.Parameters.Add("@HoraIncio", SqlDbType.VarChar).Value = oEventoBO.HoraInicioEvento;
            cmd.Parameters.Add("@HoraFinalizacion", SqlDbType.VarChar).Value = oEventoBO.HoraFinalizacion;
            cmd.Parameters.Add("@FechaIncio", SqlDbType.Date).Value = oEventoBO.FechaInicio;
            cmd.Parameters.Add("@FechaFinalizacion", SqlDbType.Date).Value = oEventoBO.FechaFinalizacion;
            cmd.Parameters.Add("@Foto", SqlDbType.Image).Value = oEventoBO.Foto;
            cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = oEventoBO.IdUsuario;
            cmd.Parameters.Add("@IdSitio", SqlDbType.Int).Value = oEventoBO.IdSitio;

            conn.Abrir();
            int retorno = cmd.ExecuteNonQuery();

            if (retorno <= 0)
            {
                retorno = 0;
            }
            else
            {
                retorno = 1;
            }

            return retorno;
        }

        public int ModificarEvento(object obj)
        {
            cmd = new SqlCommand();
            conn = new Conexion();
            oEventoBO = (BO.EventoBO)obj;

            cmd.Connection = conn.Establecer();
            cmd.CommandText = "actualizar_evento";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@idEvento", SqlDbType.Int).Value = oEventoBO.IdEvento;
            cmd.Parameters.Add("@NombreEvent", SqlDbType.VarChar).Value = oEventoBO.NombreEvento;
            cmd.Parameters.Add("@HoraIncio", SqlDbType.VarChar).Value = oEventoBO.HoraInicioEvento;
            cmd.Parameters.Add("@HoraFinalizacion", SqlDbType.VarChar).Value = oEventoBO.HoraFinalizacion;
            cmd.Parameters.Add("@FechaIncio", SqlDbType.Date).Value = oEventoBO.FechaInicio;
            cmd.Parameters.Add("@FechaFinalizacion", SqlDbType.Date).Value = oEventoBO.FechaFinalizacion;
            cmd.Parameters.Add("@Foto", SqlDbType.Image).Value = oEventoBO.Foto;
            cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = oEventoBO.IdUsuario;
            cmd.Parameters.Add("@IdSitio", SqlDbType.Int).Value = oEventoBO.IdSitio;

            conn.Abrir();
            int retorno = cmd.ExecuteNonQuery();

            if (retorno <= 0)
            {
                retorno = 0;
            }
            else
            {
                retorno = 1;
            }

            return retorno;
        }


        public int EliminarEvento(object obj)
        {
            cmd = new SqlCommand();
            conn = new Conexion();
            oEventoBO = (BO.EventoBO)obj;

            cmd.Connection = conn.Establecer();
            cmd.CommandText = "eliminar_evento";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@idEvento", SqlDbType.Int).Value = oEventoBO.IdEvento;


            conn.Abrir();
            int retorno = cmd.ExecuteNonQuery();

            if (retorno <= 0)
            {
                retorno = 0;
            }
            else
            {
                retorno = 1;
            }

            return retorno;
        }

        //Agregue el dataset y el metodo de imagen de esta tabla. Diosemir Nah
        public DataSet ver_Eventos(object obj)
        {
            oEventoBO = (BO.EventoBO)obj;
            conn = new Conexion();
            string sql;
            sql = "EXEC ver_Eventos '"+oEventoBO.IdSitio+"' ";
            return conn.TablaDS(sql);
        }

        public DataSet ver_Eventos_fecha(String Fecha)
        {
            string fecha = Fecha;
            conn = new Conexion();
            string sql;
            sql = "EXEC  Wver_calendario_fecha '" + fecha + "' ";
            return conn.TablaDS(sql);
        }

        public DataSet ver_Eventos_user(object obj)
        {
            oEventoBO = (BO.EventoBO)obj;
            conn = new Conexion();
            string sql;
            sql = "EXEC ver_eventos_user '" + oEventoBO.IdUsuario + "' ";
            return conn.TablaDS(sql);
        }

        public DataSet ver_Eventos_admin(object obj)
        {
            oEventoBO = (BO.EventoBO)obj;
            conn = new Conexion();
            string sql;
            sql = "EXEC ver_eventos_admin";
            return conn.TablaDS(sql);
        }



        public DataSet ver_Eventos_movil()
        {
            conn = new Conexion();
            string sql;
            sql = "EXEC ver_eventos_admin";
            return conn.TablaDS(sql);
        }

    }
}