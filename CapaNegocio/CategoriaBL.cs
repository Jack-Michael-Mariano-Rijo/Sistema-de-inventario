using CapaDato;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CategoriasBL
    {
        CategoriaDAL datos = new CategoriaDAL();

        public DataTable ListarCategorias()
        {
            return datos.ListarCategorias();
        }

        public void InsertarCategoria(Categorias obj)
        {
            datos.InsertarCategoria(obj);
        }

        public void Eliminar(int idSeleccionado)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Categorias c)
        {
            throw new NotImplementedException();
        }
    }
}
