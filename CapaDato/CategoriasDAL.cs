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
    public class CategoriaDAL
    {
        Conexion cn = new Conexion();
        SqlCommand cmd = new SqlCommand();

        public DataTable ListarCategorias()
        {
            DataTable tabla = new DataTable();

            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "sp_listar_categorias";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader leer = cmd.ExecuteReader();
            tabla.Load(leer);

            return tabla;
        }

        public void InsertarCategoria(Categorias obj)
        {
            cmd.Connection = cn.AbrirConexion();
            cmd.CommandText = "sp_insertar_categoria";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nombre", obj.Nombre);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
    }
}

