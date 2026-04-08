using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDato
{
    public class ConsultaMovimientoDAL
    {
        Conexion objConexion = new Conexion();

        public DataTable MostrarMovimientos()
        {
            DataTable tabla = new DataTable();

            SqlCommand cmd = new SqlCommand("sp_Mostrar_Movimientos", objConexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();
            tabla.Load(dr);

            objConexion.CerrarConexion();

            return tabla;
        }
    }
}
