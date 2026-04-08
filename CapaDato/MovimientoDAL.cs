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
    public class MovimientoDAL
    {
        Conexion objConexion = new Conexion();

        // INSERTAR MOVIMIENTO
        public void InsertarMovimiento(Movimiento obj)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertarMovimiento", objConexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_tipo", obj.IdTipoMovimiento);
            cmd.Parameters.AddWithValue("@id_proveedor", obj.IdProveedor);
            cmd.Parameters.AddWithValue("@fecha", obj.Fecha);
            cmd.Parameters.AddWithValue("@numero", obj.Numero);
            cmd.Parameters.AddWithValue("@usuario", obj.Usuario);

            cmd.ExecuteNonQuery();
            objConexion.CerrarConexion();
        }

        // INSERTAR DETALLE
        public void InsertarDetalle(Movimiento obj)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertarDetalleMovimiento", objConexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_producto", obj.IdProducto);
            cmd.Parameters.AddWithValue("@id_categoria", obj.IdCategoria);
            cmd.Parameters.AddWithValue("@cantidad", obj.Cantidad);

            cmd.ExecuteNonQuery();
            objConexion.CerrarConexion();
        }

    }
}
