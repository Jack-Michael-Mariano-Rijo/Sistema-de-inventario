using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDato
{
    public class UsuarioDAL
    {

        Conexion cn = new Conexion();
        SqlCommand cmd = new SqlCommand();

        public DataTable ListarUsuarios()
        {
            DataTable tabla = new DataTable();

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "sp_listar_usuarios";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader leer = cmd.ExecuteReader();
            tabla.Load(leer);

            cn.CerrarConexion(); // 👈 TE FALTABA ESTO

            return tabla;
        }

        public void InsertarUsuario(Usuario obj)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "sp_insertar_usuario";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
            cmd.Parameters.AddWithValue("@username", obj.Username);
            cmd.Parameters.AddWithValue("@password", obj.Password);
            cmd.Parameters.AddWithValue("@id_rol", obj.IdRol);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }


        public DataTable Login(string usuario, string password)
        {
            DataTable tabla = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.AbrirConexion();

            cmd.CommandText = "sp_Login";
            cmd.CommandType = CommandType.StoredProcedure;

            // Nombres exactos de los parámetros que espera el SP
            cmd.Parameters.AddWithValue("@username", usuario);
            cmd.Parameters.AddWithValue("@password", password);

            SqlDataReader leer = cmd.ExecuteReader();
            tabla.Load(leer);

            cn.CerrarConexion();

            return tabla;
        }
        
    }
}
