using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BE
{
    public partial class PasswordTextBox : UserControl
    {
        public PasswordTextBox()
        {
            InitializeComponent();
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
          

        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            string contraseña = txtContraseña.Text;

            if (ValidarContraseña(contraseña))
            {
                string contraseñaHasheada = AplicarHash(contraseña);
                MessageBox.Show("Contraseña válida");
            }
            else
            {
                MessageBox.Show("La contraseña debe tener más de 6 caracteres y no puede incluir símbolos especiales.");
            }
        }

        private bool ValidarContraseña(string contraseña)
        {
            if (contraseña.Length <= 6)
            {
                return false;
            }

            string patronEspecial = @"[!@#$%^&*(),.?\";

            if (Regex.IsMatch(contraseña, patronEspecial))
            {
                return false;
            }

            return true;
        }

        private string AplicarHash(string contraseña)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
