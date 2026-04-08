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
    public class ClientesBL
    {
        ClientesDAL datos = new ClientesDAL();

        public DataTable ListarClientes()
        {
            return datos.ListarClientes();
        }


        public void Eliminar(int idSeleccionado)
        {
            datos.Eliminar(idSeleccionado);
        }


        public void InsertarCliente(Clientes obj)
        {
            datos.InsertarCliente(obj);
        }

        public void Guardar(Clientes c)
        {
            throw new NotImplementedException();
        }

        public void Actualizar(Clientes c)
        {
            throw new NotImplementedException();
        }
    }
}
