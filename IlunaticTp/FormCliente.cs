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
    public partial class FormCliente : Form
    {
        BLLCliente bllCliente = new BLLCliente();
        public FormCliente()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.IdCliente = Convert.ToInt32(txtId.Text);
                bllCliente.EliminarCliente(cliente);
                dgvCliente.DataSource = bllCliente.ListarCliente();
                MessageBox.Show("Se eliminó el cliente");

                //Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            cbEstado.Items.Clear();
            cbEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Si" });
            cbEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No" });
            cbEstado.DisplayMember = "Texto";
            cbEstado.ValueMember = "Valor";
            cbEstado.SelectedIndex = 0;

            dgvCliente.DataSource = null;
            dgvCliente.DataSource = bllCliente.ListarCliente();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {

            try
            {
                Cliente cliente = new Cliente();
                cliente.IdCliente = int.Parse(txtId.Text);
                cliente.Documento = txtDocumento.Text;
                cliente.NombreCompletp = txtNombreCompleto.Text;
                cliente.Correo = txtCorreo.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.Estado = Convert.ToString(((OpcionCombo)cbEstado.SelectedItem).Valor);


                bllCliente.AgregarCliente(cliente);
                dgvCliente.DataSource = null;
                dgvCliente.DataSource = bllCliente.ListarCliente();

                MessageBox.Show("Categoria creada exitosamente");
                //Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            try
            {
                Cliente cliente = new Cliente();
                cliente.IdCliente = int.Parse(txtId.Text);
                cliente.Documento = txtDocumento.Text;
                cliente.NombreCompletp = txtNombreCompleto.Text;
                cliente.Correo = txtCorreo.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.Estado = Convert.ToString(((OpcionCombo)cbEstado.SelectedItem).Valor);


                bllCliente.ModificarCliente(cliente);
                dgvCliente.DataSource = null;
                dgvCliente.DataSource = bllCliente.ListarCliente();

                MessageBox.Show("Categoria modificada exitosamente");
                //Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
