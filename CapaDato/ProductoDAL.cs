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
    public class ProductoDAL
    {
        private Conexion objConexion = new Conexion();

        // 🔹 INSERTAR
        public void InsertarProducto(Producto obj)
        {
            SqlCommand cmd = new SqlCommand("sp_Insertar_Producto", objConexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
            cmd.Parameters.AddWithValue("@precio", obj.Precio);
            cmd.Parameters.AddWithValue("@stock", obj.Stock);
            cmd.Parameters.AddWithValue("@id_categoria", obj.IdCategoria);
            cmd.Parameters.AddWithValue("@creado_por", obj.CreadoPor);

            cmd.ExecuteNonQuery();
            objConexion.CerrarConexion();
        }

        // 🔹 EDITAR
        public void EditarProducto(Producto obj)
        {
            SqlCommand cmd = new SqlCommand("sp_EditarProducto", objConexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_producto", obj.IdProducto);
            cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
            cmd.Parameters.AddWithValue("@precio", obj.Precio);
            cmd.Parameters.AddWithValue("@stock", obj.Stock);
            cmd.Parameters.AddWithValue("@id_categoria", obj.IdCategoria);

            cmd.ExecuteNonQuery();
            objConexion.CerrarConexion();
        }

        // 🔹 ELIMINAR
        public void EliminarProducto(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_Eliminar_Producto", objConexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_producto", id);

            cmd.ExecuteNonQuery();
            objConexion.CerrarConexion();
        }

        // 🔹 MOSTRAR
        public DataTable MostrarProductos()
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_MostrarProductos", objConexion.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            da.Fill(dt);

            objConexion.CerrarConexion();
            return dt;
        }
    }
}