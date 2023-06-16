using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using WcfDomain.Entity;
using WcfInterfaces.Contracts;
using WcfInfrastructure.Common;

namespace WcfInfrastructure.Repositories
{
    public class LogRepository : ILogRepository
    {
        private Conexion conexion = new Conexion();
        SqlCommand comando = new SqlCommand();
        public void InsertLog(string log)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarLogs";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Description", log);
            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }

    }
}
