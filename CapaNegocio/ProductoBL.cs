using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;

namespace CapaNegocio
{
    public class ProductoBL
    {
        private ProductoDAL objetoCD = new ProductoDAL();

        // 🔹 INSERTAR
        public void InsertarProducto(Producto obj)
        {
            objetoCD.InsertarProducto(obj);
        }

        // 🔹 EDITAR
        public void EditarProducto(Producto obj)
        {
            objetoCD.EditarProducto(obj);
        }

        // 🔹 ELIMINAR
        public void EliminarProducto(Producto obj)
        {
            objetoCD.EliminarProducto(obj.IdProducto);
        }

        // 🔹 MOSTRAR
        public DataTable MostrarProductos()
        {
            return objetoCD.MostrarProductos();
        }
    }
}
