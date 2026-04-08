using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class ConsultaMovimiento
   {       public int IdMovimiento { get; set; }
            public string Tipo { get; set; }
            public DateTime Fecha { get; set; }
            public string Usuario { get; set; }
            public int Items { get; set; }
            public int CantidadTotal { get; set; }
   }
}
