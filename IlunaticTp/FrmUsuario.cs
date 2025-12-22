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
    public partial class FrmUsuario : Form
    {
        BLLUsuario bllUsuario = new BLLUsuario();
        Usuario usuario = new Usuario();

        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.IdUsuario = int.Parse(txtId.Text);
                usuario.NombreApellidos = txtNombreCompleto.Text;
                usuario.DNI = txtDni.Text;
                usuario.Correo = txtCorreo.Text;
                usuario.IdRol = Convert.ToInt32(((OpcionCombo)cbRol.SelectedItem).Valor);
                usuario.Clave = txtContraseña.Text;
                usuario.EsActivo = Convert.ToString(((OpcionCombo)cbEstado.SelectedItem).Valor);


                bllUsuario.AgregarUsuario(usuario);
                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = bllUsuario.ListarUsuario();

                MessageBox.Show("Usuario creado exitosamente");       

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //dgvUsuarios.DataSource = null;
            //dgvUsuarios.DataSource = bllUsuario.ListarUsuario();

            Limpiar();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            cbEstado.Items.Clear();
            cbEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Si" });
            cbEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No" });
            cbEstado.DisplayMember = "Texto";
            cbEstado.ValueMember = "Valor";
            cbEstado.SelectedIndex = 0;

            List<Rol> listarRol = new BLLRol().ListarRol();
            foreach (Rol rol in listarRol)
            {
                cbRol.Items.Add(new OpcionCombo() { Valor = rol.IdRol,
                    Texto = rol.Descripcion }) ;
            }
            cbRol.DisplayMember = "Texto";
            cbRol.ValueMember = "Valor";
            cbRol.SelectedIndex = 0;


            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = bllUsuario.ListarUsuario();
     
        }

        private void Limpiar()
        {
            txtId.Text = "0";
            txtNombreCompleto.Text = " ";
            txtCorreo.Text = " ";
            txtContraseña.Text = " ";
            txtConfContraseña.Text = " ";
            txtDni.Text = " ";
            cbRol.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0;

        }
        private int ObtenerIdDesdeTexto(string texto)
        {
        
            if (texto.Contains("(") && texto.Contains(")"))
            {
                int inicio = texto.IndexOf("(") + 1; 
                int fin = texto.IndexOf(")");       

                string idEnParentesis = texto.Substring(inicio, fin - inicio);
                return int.Parse(idEnParentesis); 
            }

            throw new FormatException("El formato del texto no es válido.");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.IdUsuario = int.Parse(txtId.Text);
                usuario.NombreApellidos = txtNombreCompleto.Text;
                usuario.DNI = txtDni.Text;
                usuario.Correo = txtCorreo.Text;
                usuario.IdRol = Convert.ToInt32(((OpcionCombo)cbRol.SelectedItem).Valor);
                usuario.Clave = txtContraseña.Text;
                usuario.EsActivo = Convert.ToString(((OpcionCombo)cbEstado.SelectedItem).Valor);

                bllUsuario.ModificarUsuario(usuario);
                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = bllUsuario.ListarUsuario();

                MessageBox.Show("Usuario modificado exitosamente");

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
                usuario.IdUsuario = Convert.ToInt32(txtId.Text);
                bllUsuario.EliminarUsuario(usuario);
                dgvUsuarios.DataSource = bllUsuario.ListarUsuario();
                MessageBox.Show("Se eliminó un usuario");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCargar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
