using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDato;

namespace CapaPresentacion2._0
{
    public partial class Acceso : Form
    {
        private int intentos;

        public Acceso()
        {
            InitializeComponent();

            txtContraseña.UseSystemPasswordChar = true;
        }


        private void bntOK_Click(object sender, EventArgs e)
        {
            UsuarioDAL negocio = new UsuarioDAL();
            DataTable tabla = negocio.Login(txtUsuario.Text, txtContraseña.Text);

            if (tabla.Rows.Count > 0)
            {
                string rol = tabla.Rows[0]["nombre_rol"].ToString();
                string usuario = tabla.Rows[0]["Nombre_rol"].ToString();

                Principal menu = new Principal(rol, usuario);
                menu.Show();
                this.Hide();
            }
            else
            {
                intentos++;

                if (intentos >= 3)
                {
                    MessageBox.Show("Has superado el número máximo de intentos.");
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos. Intento " + intentos + " de 3.");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtContraseña.UseSystemPasswordChar = false; // Se muestra
            }
            else
            {
                txtContraseña.UseSystemPasswordChar = true; // Se oculta
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
