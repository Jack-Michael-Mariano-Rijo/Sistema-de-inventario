using CapaDato;
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
    public partial class Principal : Form
    {

        // Declarar el campo Usuario
        private string Usuario;
        private string rol;
        private readonly string nombreUsuario;
        private readonly string rolUsuario;

        Color colorMenu = Color.FromArgb(30, 58, 138);
        Color colorHover = Color.FromArgb(59, 130, 246);

        public Principal(string nombre, string rol)
        {
            InitializeComponent();

            nombreUsuario = nombre;
            rolUsuario = rol;
            Usuario = rol;
            this.rol = rol;      

            ConfigurarPermisos();
        }

        private void ConfigurarPermisos()
        {
            if (Usuario == "Consulta")
            {
                bntCategorias.Visible = true;
                bntCategorias.Enabled = false;
                btnProducto.Visible = true;
                btnProducto.Enabled = false;
                btnMovimientos.Visible = true;
                btnMovimientos.Enabled = false;
                btnConsultaMovimiento.Visible = true;
                btnConsultaMovimiento.Enabled = true;
                btnCliente.Visible = false;
                btnCliente.Enabled = false;
                btnCrearUs.Visible = false;
                btnCrearUs.Enabled = false;
                btnProveedores.Visible = false;
                btnProveedores.Enabled = false;
            }
            else if (Usuario == "Almacen")
            {
                bntCategorias.Visible = true;
                bntCategorias.Enabled = false;
                btnProducto.Visible = true;
                btnProducto.Enabled = false;
                btnMovimientos.Visible = true;
                btnMovimientos.Enabled = true;
                btnCliente.Visible = false;
                btnCliente.Enabled = false;
                btnCrearUs.Visible = false;
                btnCrearUs.Enabled = false;
                btnProveedores.Visible = false;
                btnProveedores.Enabled = false;
            }
            else if (Usuario == "Administrador")
            {
                // ve todo y puede usar todo
                bntCategorias.Visible = true;
                bntCategorias.Enabled = true;
                btnProducto.Visible = true;
                btnProducto.Enabled = true;
                btnMovimientos.Visible = true;
                btnMovimientos.Enabled = true;
                btnCliente.Visible = false;
                btnCliente.Enabled = false;
                btnCrearUs.Visible = false;
                btnCrearUs.Enabled = false;
                btnProveedores.Visible = false;
                btnProveedores.Enabled = false;
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
        
        }

        private void AbrirFormulario(Form formulario)
        {
            panelContenedor.Controls.Clear(); // limpia lo que hay

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(formulario);
            panelContenedor.Tag = formulario;

            formulario.Show();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUsuarios_Click_1(object sender, EventArgs e)
        {
            Acceso Ace = new Acceso();
            Ace.Show();
            this.Hide();
        }

        private void panelUsuario_Paint_1(object sender, PaintEventArgs e)
        {
            // Panel para usuario, al lado derecho del título
            Panel panelUsuario = new Panel
            {
                Width = 200,
                Height = 60,
                Top = 10,
                Left = this.Width - 220, // Ajusta según tamaño de formulario
                BackColor = System.Drawing.Color.LightSteelBlue
            };
            this.Controls.Add(panelUsuario);
            panelUsuario.BringToFront();

            // Label para nombre
            Label lblNombre = new Label
            {
                Text = $"Usuario: Juan Perez",
                Left = 10,
                Top = 5,
                AutoSize = true,
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold)
            };
            panelUsuario.Controls.Add(lblNombre);

            // Label para rol
            Label lblRol = new Label
            {
                Text = $"Rol: {rolUsuario}",
                Left = 10,
                Top = 25,
                AutoSize = true,
                Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Italic)
            };
            panelUsuario.Controls.Add(lblRol);

            // Label para hora
            Label lblHora = new Label
            {
                Text = DateTime.Now.ToString("HH:mm:ss"),
                Left = 10,
                Top = 40,
                AutoSize = true,
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold)
            };
            panelUsuario.Controls.Add(lblHora);

            // Timer para actualizar la hora
            Timer timer = new Timer { Interval = 1000 };
            timer.Tick += (s, evt) => lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            timer.Start();
        }

        private void bntCategorias_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Categorias());
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnProducto_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmProducto());
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Movimiento());
        }

        private void btnConsultaMovimiento_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ConsultarMovimiento());
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmClientes());
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmProveedores());
        }

        private void btnCrearUs_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmUsuario());
        }
    }
}
