using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDato; 

namespace CapaDato
{
    public class ClientesDAL
    {
        Conexion cn = new Conexion();
        SqlCommand cmd = new SqlCommand();

        public DataTable ListarClientes()
        {
            DataTable tabla = new DataTable();

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "sp_listar_clientes";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader leer = cmd.ExecuteReader();
            tabla.Load(leer);

            cn.CerrarConexion();

            return tabla;
        }

        public void InsertarCliente(Clientes obj)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "sp_insertar_cliente";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
            cmd.Parameters.AddWithValue("@telefono", obj.Telefono);
            cmd.Parameters.AddWithValue("@email", obj.Email);
            cmd.Parameters.AddWithValue("@direccion", obj.Direccion);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            cn.CerrarConexion();
        }

        public void Eliminar(int id)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "sp_eliminar_cliente";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            cn.CerrarConexion();
        }
    }
}
