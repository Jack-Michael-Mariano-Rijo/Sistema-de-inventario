using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDato;
using CapaEntidad;

namespace CapaPresentacion2._0
{
    public partial class Categorias : Form
    {

        Conexion objConexion = new Conexion();
        public Categorias()
        {
            InitializeComponent();
        }

        private void panelUsuario_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Categorias_Load(object sender, EventArgs e)
        {
            MostrarCategorias();
            CargarCombo();

            dataGridView1.Columns["id_categoria"].Visible = false;
        }

        void CargarCombo()
        {
            SqlCommand cmd = new SqlCommand("sp_MostrarCategorias", objConexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "id_categoria";
        }


        void MostrarCategorias()
        {
            SqlCommand cmd = new SqlCommand("sp_MostrarCategorias", objConexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            objConexion.CerrarConexion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Ingrese una categoría");
                return;
            }

            SqlCommand cmd = new SqlCommand("sp_InsertarCategoria", objConexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nombre", comboBox1.Text);

            objConexion.AbrirConexion();
            cmd.ExecuteNonQuery();
            objConexion.CerrarConexion();

            MessageBox.Show("Guardado correctamente");

            MostrarCategorias();
            CargarCombo();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_EditarCategoria", objConexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_categoria", comboBox1.SelectedValue);
            cmd.Parameters.AddWithValue("@nombre", comboBox1.Text);

            cmd.ExecuteNonQuery();
            objConexion.CerrarConexion();

            MessageBox.Show("Editado correctamente");

            MostrarCategorias();
            CargarCombo();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_EliminarCategoria", objConexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_categoria", comboBox1.SelectedValue);

            cmd.ExecuteNonQuery();
            objConexion.CerrarConexion();

            MessageBox.Show("Eliminado correctamente");

            MostrarCategorias();
            CargarCombo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
        }
    }
}

