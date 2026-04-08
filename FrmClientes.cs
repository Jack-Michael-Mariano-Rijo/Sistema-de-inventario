using CapaNegocio;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion2._0
{
    public partial class FrmClientes : Form
    {

        int idSeleccionado;

        public FrmClientes()
        {
            InitializeComponent();
            MostrarClientes();

           dgvCliente.Columns["id_Cliente"].Visible = false;
            dgvCliente.Columns["Estado"].Visible = false;

        }

        private void MostrarClientes()
        {
            dgvCliente.DataSource = new ClientesBL().ListarClientes();
        }


        ClientesBL clientesBL = new ClientesBL();

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
        }


        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idSeleccionado = Convert.ToInt32(dgvCliente.Rows[e.RowIndex].Cells["id_Cliente"].Value);

                txtNombre.Text = dgvCliente.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtTelefono.Text = dgvCliente.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txtEmail.Text = dgvCliente.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtDireccion.Text = dgvCliente.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            Clientes c = new Clientes()
            {
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,
                Direccion = txtDireccion.Text
            };

            clientesBL.InsertarCliente(c);

            MessageBox.Show("Cliente guardado correctamente");

            MostrarClientes();
            LimpiarCampos();

        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            new ClientesBL().Eliminar(idSeleccionado);

            MessageBox.Show("Cliente eliminado");

            MostrarClientes();
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
