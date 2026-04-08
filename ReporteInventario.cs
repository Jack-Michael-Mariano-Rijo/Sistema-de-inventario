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
using Microsoft.Reporting.WinForms;

namespace CapaPresentacion2._0
{
    public partial class ReporteInventario : Form
    {

   public int idMovimiento;
        public ReporteInventario()
        {
            InitializeComponent();
        }

        private void ReporteInventario_Load(object sender, EventArgs e)
        {
            CargarReporte();
            this.reportViewer1.RefreshReport();
        }


        private void CargarReporte()
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection("Server=JACKMICHAEL3000;Database=Inventario;Integrated Security=true"))
            {
                SqlCommand cmd = new SqlCommand("sp_ReporteMovimientos", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                // 👇 FILTRO POR ID
                cmd.Parameters.AddWithValue("@id_movimiento", idMovimiento);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

         

            ReportDataSource rds = new ReportDataSource("DataSetMovimiento", dt);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.ReportEmbeddedResource =
     "CapaPresentacion2._0.RptMovimientos.rdlc";

            reportViewer1.RefreshReport();
        }
    }
}
