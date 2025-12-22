using BE;
using BLL;
using IlunaticTp.Utilidades;
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
    public partial class frmVentas : Form
    {
        public frmVentas()
        {
            InitializeComponent();
        }

        BLLCliente bllCliente = new BLLCliente();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            cbTipoDocumento.Items.Add(new OpcionCombo() { Valor = "Boleta", Texto = "Boleta" });
            cbTipoDocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cbTipoDocumento.DisplayMember = "Texto";
            cbTipoDocumento.ValueMember = "Valor";
            cbTipoDocumento.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtCodProducto.Text = "0";

            List<Cliente> listarCliente = new BLLCliente().ListarCliente();
            foreach (Cliente cliente in listarCliente)
            {
                cbDNI.Items.Add(new OpcionCombo()
                {
                    Valor = cliente.IdCliente,
                    Texto = cliente.Documento
                });
            }
            cbDNI.DisplayMember = "Texto";
            cbDNI.ValueMember = "Valor";
            //cbDNI.SelectedIndex = 0;
        }

        private void cbDNI_SelectedIndexChanged(object sender, EventArgs e)
        {
            string documentoSeleccionado = cbDNI.Text;
            Cliente cliente = bllCliente.ObtenerClientePorDNI(documentoSeleccionado);

            if (cliente != null)
            {
                txtNombreCliente.Text = cliente.NombreCompletp;
            }
            else
            {
                txtNombreCliente.Text = "";
            }
        }
    }
}
