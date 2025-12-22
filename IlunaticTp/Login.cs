using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IlunaticTp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {

            Usuario usuario = new BLLUsuario().ListarUsuario().Where(u => u.DNI == txtUsuario.Text &&
            u.Clave == txtContraseña.Text).FirstOrDefault();

            if (usuario != null)
            {
                Inicio form = new Inicio(usuario);
                form.Show();
                this.Hide();

                form.FormClosing += closeForm;
            }
            else
            {
                MessageBox.Show("Usuario no encontrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void closeForm(object sender, FormClosingEventArgs e)
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            this.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
