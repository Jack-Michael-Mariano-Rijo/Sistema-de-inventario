using System;
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
    public partial class FrmUsuario : Form
    {

        UsuarioBL usuarioBL = new UsuarioBL();

        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
            CargarRoles();
        }

        private void MostrarUsuarios()
        {
            dataGridView1.DataSource = usuarioBL.ListarUsuarios();
        }

        private void CargarRoles()
        {
            cbRol.Items.Add("Admin");
            cbRol.Items.Add("Empleado");
            cbRol.Items.Add("Consultor");
            cbRol.Items.Add("Sub-Director");

            cbRol.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario()
            {
                Nombre = txtNombre.Text,
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                IdRol = cbRol.SelectedIndex + 1 // 👈 ejemplo


            };

            usuarioBL.InsertarUsuario(u);

            if (txtNombre.Text == "" || txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Completa todos los campos");
                return;
            }

            MessageBox.Show("Usuario guardado correctamente");

            MostrarUsuarios();
            LimpiarCampos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cbRol.SelectedIndex = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Columns["id_usuario"].Visible = false;
            dataGridView1.Columns["id_rol"].Visible = false;
        }
    }
}
