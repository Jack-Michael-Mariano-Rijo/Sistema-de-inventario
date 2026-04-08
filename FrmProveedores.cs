using System;
using CapaDato;
using CapaEntidad;
using CapaNegocio;
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
    public partial class FrmProveedores : Form
    {

        ProveedoresBL proveedorBL = new ProveedoresBL();
        int idSeleccionado;

        public FrmProveedores()
        {
            InitializeComponent();
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            MostrarProveedores();
        }

        private void MostrarProveedores()
        {
            dataGridView1.DataSource = proveedorBL.ListarProveedores();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();

            // Resetear selección
            idSeleccionado = 0;

            // Opcional: quitar selección del grid
            dataGridView1.ClearSelection();

            // Enfocar el primer campo
            txtNombre.Focus();
        }



        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idSeleccionado = Convert.ToInt32(
                    dataGridView1.Rows[e.RowIndex].Cells["id_proveedor"].Value);

                txtNombre.Text = dataGridView1.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                txtTelefono.Text = dataGridView1.Rows[e.RowIndex].Cells["telefono"].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells["email"].Value.ToString();
                txtDireccion.Text = dataGridView1.Rows[e.RowIndex].Cells["direccion"].Value.ToString();

                dataGridView1.Columns["id_proveedor"].Visible = false;
                dataGridView1.Columns["Estado"].Visible = false;
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            Proveedor p = new Proveedor()
            {
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,
                Direccion = txtDireccion.Text
            };

            proveedorBL.InsertarProveedor(p);

            MessageBox.Show("Proveedor guardado");

            MostrarProveedores();
            LimpiarCampos();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            Proveedor p = new Proveedor()
            {
                IdProveedor = idSeleccionado,
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,
                Direccion = txtDireccion.Text
            };

            proveedorBL.ActualizarProveedor(p);

            MessageBox.Show("Proveedor actualizado");

            MostrarProveedores();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            proveedorBL.EliminarProveedor(idSeleccionado);

            MessageBox.Show("Proveedor eliminado");

            MostrarProveedores();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
