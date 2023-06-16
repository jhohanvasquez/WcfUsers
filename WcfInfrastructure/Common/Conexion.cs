using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfInfrastructure.Common
{
    public class Conexion
    {
        private SqlConnection oConexion = new SqlConnection("Data Source=PRIJHOHANVS\\SQLEXPRESS;Initial Catalog=BDUsers;Integrated Security=SSPI;");
        public SqlConnection AbrirConexion()
        {
            if (oConexion.State == ConnectionState.Closed)
                oConexion.Open();
            return oConexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (oConexion.State == ConnectionState.Open)
                oConexion.Close();
            return oConexion;
        }
    }
}
