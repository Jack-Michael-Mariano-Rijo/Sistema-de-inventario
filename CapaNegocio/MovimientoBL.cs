using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class MovimientoBL
    {
        MovimientoDAL objDAL = new MovimientoDAL();

        public void GuardarMovimiento(Movimiento obj)
        {
            objDAL.InsertarMovimiento(obj);
        }

        public void GuardarDetalle(Movimiento obj)
        {
            objDAL.InsertarDetalle(obj);
        }

        public object MostrarMovimientos()
        {
            throw new NotImplementedException();
        }

        public int ObtenerStock(int idProducto)
        {
            throw new NotImplementedException();
        }
    }
}
