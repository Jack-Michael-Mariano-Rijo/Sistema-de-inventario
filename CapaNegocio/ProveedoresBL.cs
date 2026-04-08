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
    public class ProveedoresBL
    {
        ProveedoresDAL datos = new ProveedoresDAL();

        public DataTable ListarProveedores()
        {
            return datos.ListarProveedores();
        }

        public void InsertarProveedor(Proveedor obj)
        {
            datos.InsertarProveedor(obj);
        }

        public void ActualizarProveedor(Proveedor obj)
        {
            datos.ActualizarProveedor(obj);
        }

        public void EliminarProveedor(int id)
        {
            datos.EliminarProveedor(id);
        }
    }
}

