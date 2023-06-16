using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using WcfDomain.Entity;
using WcfInterfaces.Contracts;
using WcfInfrastructure.Common;

namespace WcfInfrastructure.Repositories
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        public UserDetailsRepository() { }

        private Conexion conexion = new Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        public List<UserDetails> GetAllUser()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.Parameters.Clear();
            comando.CommandText = "MostrarUsuariosTodos";
            comando.CommandType = CommandType.StoredProcedure;
            var result = Util.DataReaderMapToList<UserDetails>(comando.ExecuteReader());
            conexion.CerrarConexion();
            return result;

        }
        public string InsertUserDetails(UserDetails UserID)
        {
            string strMessage = string.Empty;

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarUsuarios";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", UserID.Nombre);
            comando.Parameters.AddWithValue("@FechaNacimiento", UserID.FechaNacimiento);
            comando.Parameters.AddWithValue("@Sexo", UserID.Sexo);
            comando.ExecuteNonQuery();

            int result = comando.ExecuteNonQuery();
            if (result == 1)
            {
                strMessage = UserID.Nombre + " inserted successfully";
            }
            else
            {
                strMessage = UserID.Nombre + " not inserted successfully";
            }
            comando.Parameters.Clear();
            conexion.CerrarConexion();
            return strMessage;
        }
        public bool UpdateUser(UserDetails UserID)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarUsuarios";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", UserID.Nombre);
            comando.Parameters.AddWithValue("@FechaNacimiento", UserID.FechaNacimiento);
            comando.Parameters.AddWithValue("@Sexo", UserID.Sexo);
            comando.Parameters.AddWithValue("@Id", UserID.Id);

            int res = comando.ExecuteNonQuery();
            conexion.CerrarConexion();
            if (res == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteUser(int id)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "EliminarUsuarios";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Id", id);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conexion.CerrarConexion();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public bool FindById(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarUsuariosPorId";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", id);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            if (tabla.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<UserDetails> GetUserDetails(string UserName)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarUsuariosPorNombre";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", UserName);
            var result = Util.DataReaderMapToList<UserDetails>(comando.ExecuteReader());
            comando.Parameters.Clear();
            conexion.CerrarConexion();
            return result;
        }
    }
}
