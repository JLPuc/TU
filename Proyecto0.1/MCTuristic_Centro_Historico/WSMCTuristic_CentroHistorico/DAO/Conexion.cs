using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WSMCTuristic_CentroHistorico.DAO
{
    public class Conexion
    {
        string sql;
        SqlConnection conn = new SqlConnection();

        public SqlConnection Establecer()
        {
            //sql = "Data source = ANDRE-PC\\SQLSERVER; Initial Catalog=MCTuristic; Integrated Security=True";
            //sql = "Data source =25.65.245.232; Initial Catalog=MCTuristic;User id=user;password=1234";
            //sql = "Data source =DESKTOP-71TOP8C; Initial Catalog=MCTuristic; Integrated Security=True";
            //some sql = "workstation id=DBMCTuristic.mssql.somee.com;packet size=4096;user id=LuisPuc_SQLLogin_1;pwd=b888jh3jlc;data source=DBMCTuristic.mssql.somee.com;persist security info=False;initial catalog=DBMCTuristic";

            sql = "Server = tcp:dbmcturistic.database.windows.net,1433; Initial Catalog = MCTuristic; Persist Security Info = False; User ID = user; Password =Atomiclotus3.; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            conn = new SqlConnection(sql);
            return conn;
        }

        public void Abrir()
        {
            conn.Open();
        }

        public void Cerrar()
        {
            conn.Close();
        }
        public DataSet TablaDS(string sql)
        {
            SqlDataAdapter dat = new SqlDataAdapter(sql, Establecer());
            DataSet TablaNueva = new DataSet();
            dat.Fill(TablaNueva);
            return TablaNueva;
        }
    }
}