using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace IlunaticTp
{
    public partial class Inicio : Form
    {
        private static Usuario usuarioActual;
        private static ToolStripMenuItem menuActivo = null;
        private static Form formActivo = null;
        public Inicio(Usuario usuario)
        {
            usuarioActual = usuario;
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
           // List<Permiso> permisos = new BLLPermiso().ListarPermiso(usuarioActual.IdUsuario);

            //Oculta los menu no autorizados para el usuario
            //foreach (ToolStripMenuItem menu in menu.Items)
            //{

            //    bool encontrado = permisos.Any(m => m.NombreMenu == menu.Name);

            //    if (encontrado == false)
            //    {
            //        menu.Visible = false;
            //    }

            //}

            lblUsuario.Text = usuarioActual.NombreApellidos;
        }

        private void AbrirFormulario(ToolStripMenuItem ts, Form form)
        {
            if (formActivo != null)
            {
                formActivo.Close(); // Cierra el formulario activo
                contenedor.Controls.Remove(formActivo); // Elimina el formulario del contenedor
            }

            // Restablece el color del menú anterior (si lo hay)
            if (menuActivo != null)
            {
                menuActivo.BackColor = Color.White;
            }

            // Asigna el nuevo formulario activo
            formActivo = form;
            menuActivo = ts; // Actualiza el menú activo

            // Configura el nuevo formulario
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.BackColor = Color.Black;

            // Agrega y muestra el formulario en el contenedor
            contenedor.Controls.Add(form);
            form.Show();
        }

        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            image.Visible = false;
            AbrirFormulario((ToolStripMenuItem)sender, new FrmUsuario());
        }

        private void menuProveedor_Click(object sender, EventArgs e)
        {
            image.Visible = false;
            AbrirFormulario((ToolStripMenuItem)sender, new FrmProveedor());
        }

        private void menuCompras_Click(object sender, EventArgs e)
        {
            image.Visible = false;
            AbrirFormulario((ToolStripMenuItem)sender, new FrmCompras());
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image.Visible = false;
            AbrirFormulario((ToolStripMenuItem)sender, new FrmCategoria());
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image.Visible = false;
            AbrirFormulario((ToolStripMenuItem)sender, new FrmProducto());
        }

        private void subMenuRegistrarCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuCompra, new FrmCompras());
        }


        private void contenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image.Visible = false;
            AbrirFormulario(menuCompra, new FormCliente());
        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image.Visible = false;
            AbrirFormulario((ToolStripMenuItem)sender, new frmVentas());
        }
    }
}
