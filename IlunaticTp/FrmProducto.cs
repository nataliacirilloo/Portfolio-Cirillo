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
    public partial class FrmProducto : Form
    {
        BLLCategoria bLLCategoria = new BLLCategoria();
        BLLProducto bllProducto = new BLLProducto();
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Productos prod = new Productos();
                prod.IdProducto = int.Parse(txtId.Text);
                prod.Nombre = txtNombre.Text;
                prod.IdCategoria = Convert.ToInt32(((OpcionCombo)cbCategoria.SelectedItem).Valor);
                prod.Stock = Convert.ToInt32(txtStock.Text);
                prod.Precio = Convert.ToInt32(txtPrecio.Text);
                prod.EsActivo = cbEstado.Text;


                bllProducto.ModificarProducto(prod);
                dgvProd.DataSource = null;
                dgvProd.DataSource = bllProducto.ListarProducto();

                MessageBox.Show("Producto modificado exitosamente");
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
                Productos productos = new Productos();
                productos.IdProducto = Convert.ToInt32(txtId.Text);
                bllProducto.EliminarProducto(productos);
                dgvProd.DataSource = bllProducto.ListarProducto();
                MessageBox.Show("Se eliminó un producto");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            cbEstado.Items.Clear();
            cbEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Si" });
            cbEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No" });
            cbEstado.DisplayMember = "Texto";
            cbEstado.ValueMember = "Valor";
            cbEstado.SelectedIndex = 0;

            //cbCategoria.DataSource = null;
            //cbCategoria.DataSource = bLLCategoria.ListarCategoria();
            //cbCategoria.DisplayMember = "Descripcion";


            List<Categoria> listarCategorias = new BLLCategoria().ListarCategoria();
            foreach (Categoria cat in listarCategorias)
            {
                cbCategoria.Items.Add(new OpcionCombo()
                {
                    Valor = cat.IdCategoria,
                    Texto = cat.Descripcion
                });
            }
            cbCategoria.DisplayMember = "Texto";
            cbCategoria.ValueMember = "Valor";
            cbCategoria.SelectedIndex = 0;

            dgvProd.DataSource = null;
            dgvProd.DataSource = bllProducto.ListarProducto();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                Productos prod = new Productos();
                prod.IdProducto = int.Parse(txtId.Text);
                prod.Nombre = txtNombre.Text;
                prod.IdCategoria = Convert.ToInt32(((OpcionCombo)cbCategoria.SelectedItem).Valor);
                prod.Stock = Convert.ToInt32(txtStock.Text);
                prod.Precio = Convert.ToInt32(txtPrecio.Text);
                prod.EsActivo = cbEstado.Text;


                bllProducto.AgregarProducto(prod);
                dgvProd.DataSource = null;
                dgvProd.DataSource = bllProducto.ListarProducto();

                MessageBox.Show("Producto creado exitosamente");
                //Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
