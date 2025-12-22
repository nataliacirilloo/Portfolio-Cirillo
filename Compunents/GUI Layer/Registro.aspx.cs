using Business_Logical_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI_Layer
{
    public partial class Registro : System.Web.UI.Page
    {

        UsuarioBLL user = new UsuarioBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPerfiles();
            }
        }

        private void CargarPerfiles()
        {
            DataTable dt = user.ObtenerPerfiles();

            ddlPerfil.DataSource = dt;
            ddlPerfil.DataTextField = "Nombre";
            ddlPerfil.DataValueField = "Id_Perfil";
            ddlPerfil.DataBind();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Usuario nuevoUsuario = new Usuario
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Dni = Convert.ToInt32(txtDni.Text),
                Mail = txtMail.Text,
                UserName = txtUserName.Text,
                Contraseña = txtClave.Text,
                Id_Perfil = int.Parse(ddlPerfil.SelectedValue)
            };

            bool creado = user.CrearUsuario(nuevoUsuario);

            lblResultado.Text = creado ? "Usuario registrado correctamente." : "Error al registrar el usuario.";
        }
    }
}