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
    public partial class FrmProveedor : Form
    {
        BLLProveedor bllProveedor = new BLLProveedor();
        public FrmProveedor()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                Proveedor proveedor = new Proveedor();
                proveedor.IdProveedor = int.Parse(txtId.Text);
                proveedor.Nombre = txtNombre.Text;
                proveedor.NroDocumento = txtDocumento.Text;
                proveedor.RazonSocial = txtRazonSocial.Text;
                proveedor.Correo = txtCorreo.Text;
                proveedor.Telefono = txtTelefono.Text;
                proveedor.Estado = Convert.ToString(((OpcionCombo)cbEstado.SelectedItem).Valor);


                bllProveedor.Agregarproveedor(proveedor);
                dgvProveedor.DataSource = null;
                dgvProveedor.DataSource = bllProveedor.Listarproveedor();

                MessageBox.Show("Proveedor cargado exitosamente");
                
                //Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            cbEstado.Items.Clear();
            cbEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Si" });
            cbEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No" });
            cbEstado.DisplayMember = "Texto";
            cbEstado.ValueMember = "Valor";
            cbEstado.SelectedIndex = 0;

            dgvProveedor.DataSource = null;
            dgvProveedor.DataSource = bllProveedor.Listarproveedor();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Proveedor proveedor = new Proveedor();
                proveedor.IdProveedor = int.Parse(txtId.Text);
                proveedor.Nombre = txtNombre.Text;
                proveedor.NroDocumento = txtDocumento.Text;
                proveedor.RazonSocial = txtRazonSocial.Text;
                proveedor.Correo = txtCorreo.Text;
                proveedor.Telefono = txtTelefono.Text;
                proveedor.Estado = Convert.ToString(((OpcionCombo)cbEstado.SelectedItem).Valor);


                bllProveedor.Modificarproveedor(proveedor);
                dgvProveedor.DataSource = null;
                dgvProveedor.DataSource = bllProveedor.Listarproveedor();

                MessageBox.Show("Proveedor cargado exitosamente");

                //Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Proveedor proveedor = new Proveedor();
                proveedor.IdProveedor = Convert.ToInt32(txtId.Text);
                bllProveedor.Eliminarproveedor(proveedor);
                dgvProveedor.DataSource = bllProveedor.Listarproveedor();
                MessageBox.Show("Se eliminó el cliente");

                //Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
