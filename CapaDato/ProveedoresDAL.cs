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
    public class ProveedoresDAL
    {
        Conexion cn = new Conexion();
        SqlCommand cmd = new SqlCommand();

        // LISTAR
        public DataTable ListarProveedores()
        {
            DataTable tabla = new DataTable();

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "sp_listar_proveedores";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader leer = cmd.ExecuteReader();
            tabla.Load(leer);

            cn.CerrarConexion();

            return tabla;
        }

        // INSERTAR
        public void InsertarProveedor(Proveedor obj)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "sp_insertar_proveedor";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
            cmd.Parameters.AddWithValue("@telefono", obj.Telefono);
            cmd.Parameters.AddWithValue("@email", obj.Email);
            cmd.Parameters.AddWithValue("@direccion", obj.Direccion);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            cn.CerrarConexion();
        }

        // ACTUALIZAR
        public void ActualizarProveedor(Proveedor obj)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "sp_actualizar_proveedor";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_proveedor", obj.IdProveedor);
            cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
            cmd.Parameters.AddWithValue("@telefono", obj.Telefono);
            cmd.Parameters.AddWithValue("@email", obj.Email);
            cmd.Parameters.AddWithValue("@direccion", obj.Direccion);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            cn.CerrarConexion();
        }

        // ELIMINAR
        public void EliminarProveedor(int id)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "sp_eliminar_proveedor";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_proveedor", id);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            cn.CerrarConexion();
        }
    }
}
