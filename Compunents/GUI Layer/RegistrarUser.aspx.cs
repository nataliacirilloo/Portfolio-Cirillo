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
	public partial class RegistrarUser : System.Web.UI.Page
	{
        UsuarioBLL usuarioBLL = new UsuarioBLL();
        protected void Page_Load(object sender, EventArgs e)
		{
			

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // tu código acá
        
			try
			{
				Usuario user = new Usuario();


				user.Nombre = txtNombre.Text;
				user.Contraseña = txtcontra.Text;
				user.Apellido = txtApellido.Text;
				user.Dni = Convert.ToInt32(txtdni.Text.Replace(".", ""));
                user.Mail = txtMail.Text;
				user.UserName = txtusername.Text;

                var creacion = usuarioBLL.CrearUsuario(user);

				if (creacion == true)
				{
					lblError.Text = "Usuario creado correctamente"; 

                    Response.Redirect("Login.aspx");
                }
				else
				{
                    lblError.Text = "El usuario ya existe";
                }




            }
			catch(Exception ex)
			{
				lblError.Text = ex.Message;
			}



		}



    }
}