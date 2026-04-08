using CapaNegocio;
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
    public partial class ConsultarMovimiento : Form
    {

        ConsultaMovimientoBL objBL = new ConsultaMovimientoBL();

        public ConsultarMovimiento()
        {
            InitializeComponent();
        }

        private void ConsultarMovimiento_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            dataGridView1.Columns["id_movimiento"].Visible = false;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void CargarMovimientos()
        {
            var tabla = objBL.MostrarMovimientos();

            dataGridView1.DataSource = tabla;

            // 🔥 IMPORTANTE: ocultar el ID pero mantenerlo para usarlo
            if (dataGridView1.Columns.Contains("id_movimiento"))
            {
                dataGridView1.Columns["id_movimiento"].Visible = false;
            }
        }

        private void btnVerReportes_Click_1(object sender, EventArgs e)
        {
            CargarMovimientos();
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                // 🔥 Obtener el ID oculto
                int id = Convert.ToInt32(
                    dataGridView1.CurrentRow.Cells["id_movimiento"].Value
                );

                // 🔥 Abrir el reporte
                ReporteInventario frm = new ReporteInventario();
                frm.idMovimiento = id;

                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }


    }

}

