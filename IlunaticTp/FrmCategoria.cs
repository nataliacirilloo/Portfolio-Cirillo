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
    public partial class FrmCategoria : Form
    {
        BLLCategoria bLLCategoria = new BLLCategoria();
        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            cbEstado.Items.Clear();
            cbEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Si" });
            cbEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No" });
            cbEstado.DisplayMember = "Texto";
            cbEstado.ValueMember = "Valor";
            cbEstado.SelectedIndex = 0;

            dgvCategoria.DataSource = null;
            dgvCategoria.DataSource = bLLCategoria.ListarCategoria();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Categoria categoria = new Categoria();
            //    categoria.IdCategoria = int.Parse(txtId.Text);
            //    categoria.Descripcion = txtDescripcion.Text;
            //    categoria.EsActivo = cbEstado.Text;
        

            //    bLLCategoria.AgregarCategoria(categoria);
            //    dgvCategoria.DataSource = null;
            //    dgvCategoria.DataSource = bLLCategoria.ListarCategoria();

            //    MessageBox.Show("Categoria creada exitosamente");
            //    Limpiar();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
          
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
          
        }
        private void Limpiar()
        {
            txtId.Text = "0";
            txtDescripcion.Text = " ";
            cbEstado.SelectedIndex = 0;

        }

        private void btnCargar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Categoria categoria = new Categoria();
                categoria.IdCategoria = int.Parse(txtId.Text);
                categoria.Descripcion = txtDescripcion.Text;
                categoria.EsActivo = Convert.ToString(((OpcionCombo)cbEstado.SelectedItem).Valor);


                bLLCategoria.AgregarCategoria(categoria);
                dgvCategoria.DataSource = null;
                dgvCategoria.DataSource = bLLCategoria.ListarCategoria();

                MessageBox.Show("Categoria creada exitosamente");
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Categoria categoria = new Categoria();
                categoria.IdCategoria = int.Parse(txtId.Text);
                categoria.Descripcion = txtDescripcion.Text;
                categoria.EsActivo = cbEstado.Text;


                bLLCategoria.ModificarCategoria(categoria);
                dgvCategoria.DataSource = null;
                dgvCategoria.DataSource = bLLCategoria.ListarCategoria();

                MessageBox.Show("Categoria modificada exitosamente");
                Limpiar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Categoria categoria = new Categoria();
                categoria.IdCategoria = Convert.ToInt32(txtId.Text);
                bLLCategoria.EliminarCategoria(categoria);
                dgvCategoria.DataSource = bLLCategoria.ListarCategoria();
                MessageBox.Show("Se eliminó la categoria");

                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}