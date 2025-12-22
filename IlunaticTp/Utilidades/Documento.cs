using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IlunaticTp.Utilidades
{
    public partial class Documento : UserControl
    {
        public Documento()
        {
            InitializeComponent();
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la tecla de retroceso 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void txtDni_Validating(object sender, CancelEventArgs e)
        {
            string dni = txtDni.Text.Trim();

            if (dni.Length != 8)  
            {
                MessageBox.Show("El DNI debe tener exactamente 8 dígitos.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;  
            }
        }
    }
}
