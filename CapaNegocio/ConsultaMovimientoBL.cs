using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ConsultaMovimientoBL
    {
       ConsultaMovimientoDAL objConsulta = new ConsultaMovimientoDAL();

            public DataTable MostrarMovimientos()
            {
                return objConsulta.MostrarMovimientos();
            }
        }
    }
