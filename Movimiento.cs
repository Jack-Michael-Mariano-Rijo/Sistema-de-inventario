using CapaDato;
using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion2._0
{
    public partial class Movimiento : Form
    {
        MovimientoBL objBL = new MovimientoBL();

        public Movimiento()
        {
            InitializeComponent();
        }

        private void Movimiento_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarProveedores();
            CargarProductos();
            CargarCategorias();

            comboTipo.Items.Add("Entrada");
            comboTipo.Items.Add("Salida");
            comboTipo.SelectedIndex = -1;
        }

        private void CargarProveedores()
        {
            using (Conexion cn = new Conexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT id_proveedor, nombre FROM Proveedores",
                    cn.AbrirConexion()
                );
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboProveedor.DataSource = dt;
                comboProveedor.DisplayMember = "nombre";
                comboProveedor.ValueMember = "id_proveedor";

                cn.CerrarConexion();
            }
        }

        private void CargarProductos()
        {
            using (Conexion cn = new Conexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT id_producto, nombre FROM productos",
                    cn.AbrirConexion()
                );
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboProducto.DataSource = dt;
                comboProducto.DisplayMember = "nombre";
                comboProducto.ValueMember = "id_producto";

                cn.CerrarConexion();
            }
        }

        private void CargarCategorias()
        {
            using (Conexion cn = new Conexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT id_categoria, nombre FROM categorias",
                    cn.AbrirConexion()
                );
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboCategoria.DataSource = dt;
                comboCategoria.DisplayMember = "nombre";
                comboCategoria.ValueMember = "id_categoria";

                cn.CerrarConexion();
            }
        }

        private void ConfigurarGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id_producto", "ID");
            dataGridView1.Columns["id_producto"].Visible = false;
            dataGridView1.Columns.Add("producto", "Producto");
            dataGridView1.Columns.Add("categoria", "Categoría");
            dataGridView1.Columns.Add("cantidad", "Cantidad");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                Name = "Eliminar",
                Text = "X",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(btn);
        }

        private bool ExisteProducto(int idProducto)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["id_producto"].Value != null &&
                    Convert.ToInt32(row.Cells["id_producto"].Value) == idProducto)
                {
                    return true;
                }
            }
            return false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (comboProducto.SelectedIndex == -1 ||
                comboCategoria.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Complete los datos");
                return;
            }

            int idProducto = Convert.ToInt32(comboProducto.SelectedValue);
            int cantidadSolicitada = Convert.ToInt32(txtCantidad.Text);

            // Obtener stock actual del producto
            int stockActual = objBL.ObtenerStock(idProducto); // Método que debes tener en tu BL

            if (comboTipo.Text == "Salida" && cantidadSolicitada > stockActual)
            {
                MessageBox.Show($"Cantidad excede el stock disponible ({stockActual})");
                return;
            }

            if (ExisteProducto(idProducto))
            {
                MessageBox.Show("El producto ya está agregado");
                return;
            }

            int fila = dataGridView1.Rows.Add();
            dataGridView1.Rows[fila].Cells["id_producto"].Value = idProducto;
            dataGridView1.Rows[fila].Cells["producto"].Value = comboProducto.Text;
            dataGridView1.Rows[fila].Cells["categoria"].Value = comboCategoria.Text;
            dataGridView1.Rows[fila].Cells["cantidad"].Value = cantidadSolicitada;

            txtCantidad.Clear();
        }

        private void comboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = comboTipo.Text;

            if (tipo == "Entrada")
            {
                // Modo entrada → se habilitan proveedores
                lProveedor.Text = "Proveedor";
                comboProveedor.Enabled = true;

                ProveedoresBL prov = new ProveedoresBL();
                comboProveedor.DataSource = prov.ListarProveedores();
                comboProveedor.DisplayMember = "nombre";
                comboProveedor.ValueMember = "id_proveedor";
            }
            else if (tipo == "Salida")
            {
                // Modo salida → se habilitan clientes
                lProveedor.Text = "Cliente";
                comboProveedor.Enabled = true;

                ClientesBL cli = new ClientesBL();
                comboProveedor.DataSource = cli.ListarClientes();
                comboProveedor.DisplayMember = "nombre";
                comboProveedor.ValueMember = "id_cliente"; // Cambia según tu DB
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (Conexion cn = new Conexion())
            {
                SqlConnection conexion = cn.AbrirConexion();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertarMovimiento", conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@tipo_movimiento", comboTipo.Text.ToLower());
                    cmd.Parameters.AddWithValue("@id_usuario", 1);
                    cmd.Parameters.AddWithValue("@id_proveedor",
                        comboProveedor.SelectedValue ?? (object)DBNull.Value);

                    int idMovimiento = Convert.ToInt32(cmd.ExecuteScalar());
                    MessageBox.Show("ID Movimiento: " + idMovimiento);

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["id_producto"].Value != null)
                        {
                            SqlCommand cmdDetalle = new SqlCommand("sp_InsertarDetalleMovimiento", conexion)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmdDetalle.Parameters.AddWithValue("@id_movimiento", idMovimiento);
                            cmdDetalle.Parameters.AddWithValue("@id_producto", row.Cells["id_producto"].Value);
                            cmdDetalle.Parameters.AddWithValue("@cantidad", row.Cells["cantidad"].Value);
                            cmdDetalle.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Guardado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    cn.CerrarConexion();
                }
            }
        }

        private void Limpiar()
        {
            comboTipo.SelectedIndex = -1;
            comboProveedor.SelectedIndex = -1;
            comboProducto.SelectedIndex = -1;
            comboCategoria.SelectedIndex = -1;
            txtCantidad.Clear();
            dataGridView1.Rows.Clear();
        }
    }
}