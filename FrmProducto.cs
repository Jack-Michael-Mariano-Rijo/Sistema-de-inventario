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
using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion2._0
{
    public partial class FrmProducto : Form
    {
        ProductoBL objNegocio = new ProductoBL();
        Conexion objConexion = new Conexion();

        int idProducto;

        public FrmProducto()
        {
            InitializeComponent();
        }

        private void Producto_Load(object sender, EventArgs e)
        {
            CargarProductos();
            CargarCategorias();
            CargarComboProducto();

            dataGridView1.Columns["id_producto"].Visible=false;
       
        }

        private void CargarProductos()
        {
            dataGridView1.DataSource = objNegocio.MostrarProductos();
        }

        private void CargarComboProducto()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT id_producto, nombre, precio FROM Productos WHERE estado = 1", objConexion.AbrirConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboNombre.DataSource = dt;
            comboNombre.DisplayMember = "nombre";
            comboNombre.ValueMember = "id_producto";

            objConexion.CerrarConexion();
        }


        private void comboNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboNombre.SelectedIndex != -1)
            {
                DataRowView fila = (DataRowView)comboNombre.SelectedItem;
                txtPrecio.Text = fila["precio"].ToString();
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto obj = new Producto();

            obj.Nombre = comboNombre.Text;
            obj.Precio = Convert.ToDecimal(txtPrecio.Text);
            obj.Stock = Convert.ToInt32(txtStock.Text);
            obj.IdCategoria = Convert.ToInt32(comboCategoria.SelectedValue);
            obj.CreadoPor = 1;

            objNegocio.InsertarProducto(obj);

            MessageBox.Show("Producto guardado");
            CargarProductos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Producto obj = new Producto();

            obj.IdProducto = idProducto;
            obj.Nombre = comboNombre.Text;
            obj.Precio = Convert.ToDecimal(txtPrecio.Text);
            obj.Stock = Convert.ToInt32(txtStock.Text);
            obj.IdCategoria = Convert.ToInt32(comboCategoria.SelectedValue);

            objNegocio.EditarProducto(obj);

            MessageBox.Show("Producto editado");
            CargarProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Producto obj = new Producto();
            obj.IdProducto = idProducto;

            objNegocio.EliminarProducto(obj);

            MessageBox.Show("Producto eliminado");
            CargarProductos();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idProducto = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_producto"].Value);
            comboNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
            txtPrecio.Text = dataGridView1.CurrentRow.Cells["precio"].Value.ToString();
            txtStock.Text = dataGridView1.CurrentRow.Cells["stock"].Value.ToString();
        }

        private void CargarCategorias()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM categorias", objConexion.AbrirConexion());
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboCategoria.DataSource = dt;
            comboCategoria.DisplayMember = "nombre";
            comboCategoria.ValueMember = "id_categoria";

            objConexion.CerrarConexion();
        }



    }
}
