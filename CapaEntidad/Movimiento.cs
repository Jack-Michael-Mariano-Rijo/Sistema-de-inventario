using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Movimiento
    {
        public int IdMovimiento { get; set; }
        public int IdTipoMovimiento { get; set; }
        public int IdProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public string Numero { get; set; }
        public string Usuario { get; set; }

        // Detalle
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public int Cantidad { get; set; }
    }
}
