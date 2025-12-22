using Business_Logical_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI_Layer
{
    public partial class RegistroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        UsuarioBLL UsuarioBLL = new UsuarioBLL();

        // Metodo para registrar un nuevo cliente
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();    
            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.Dni = Convert.ToInt32(txtDni.Text);
            usuario.Mail = txtMail.Text;
            usuario.UserName = txtUserName.Text;
            usuario.Contraseña = txtPassword.Text;
            usuario.Id_Perfil = 3; // Asignar rol de cliente
        }

    }
}