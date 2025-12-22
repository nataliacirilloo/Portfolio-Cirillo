using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IlunaticTp.Utilidades
{
    public partial class txtCorreo : UserControl
    {
        public txtCorreo()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            string correo = textBox1.Text.Trim();

            // Expresión regular para validar el formato del correo
            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(correo, patronCorreo))
            {
                MessageBox.Show("Por favor, ingresa un correo electrónico válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; 
            }
        }
    }
}
