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
    public class UsuarioBL
    {
        UsuarioDAL datos = new UsuarioDAL();

        public DataTable ListarUsuarios()
        {
            return datos.ListarUsuarios();
        }

        public void InsertarUsuario(Usuario obj)
        {
            datos.InsertarUsuario(obj);
        }
    }
}
