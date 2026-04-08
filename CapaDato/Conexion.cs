using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDato
{
    public class Conexion : IDisposable
    {
        private SqlConnection conexion = new SqlConnection(
        "Server=JACKMICHAEL3000;Database=Inventario;Integrated Security=true");

        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();

            return conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();

            return conexion;
        }

        public void Dispose()
        {
            if (conexion != null)
            {
                conexion.Dispose();
                conexion = null;
            }
        }
    }
}
