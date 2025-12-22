using Business_Logical_Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI_Layer
{
    /// <summary>
    /// Página de autenticación de usuarios con control de intentos fallidos y bloqueo
    /// </summary>
	public partial class Login : System.Web.UI.Page
	{
		UsuarioBLL user = new UsuarioBLL();
        BitacoraBLL BitacoraBLL = new BitacoraBLL();
        
        /// <summary>
        /// Inicializa la página y redirige si el usuario ya está autenticado
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["username"] != null && Session["Rol"] != null)
            {
                Response.Redirect("Inicio.aspx");
                return;
            }
            txtusername.Focus();
        }

        /// <summary>
        /// Procesa el intento de login con validaciones de seguridad y registro en bitácora
        /// </summary>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtusername.Text;
                string password = txtcontrasela.Text;

                var usuario = user.TraerUser(username);

                if (usuario == null)
                {
                    Resultado.Text = "Usuario inexistente.";
                    return;
                }

                if (usuario.Bloqueado)
                {
                    Resultado.Text = "El usuario está bloqueado. Contacte al administrador.";
                    return;
                }

                bool autenticacion = user.AutenticarUser(username, password);

                if (autenticacion)
                {
                    user.ResetearIntentos(usuario.Id_Usuario);

                    Session["username"] = username;
                    Session["password"] = password;
                    Session["UserId"] = usuario.Id_Usuario;
                    Session["rol"] = usuario.Nombre_Perfil?.Trim().ToLower();

                    BitacoraBLL.BitacoraLogin(usuario.Id_Usuario);
                    Response.Redirect("Inicio.aspx");
                }
                else
                {
                    user.RegistrarIntentoFallido(usuario.Id_Usuario);

                    usuario = user.TraerUser(username);

                    int restantes = 3 - usuario.IntentosFallidos;

                    Resultado.Text = restantes <= 0
                        ? "Usuario bloqueado por múltiples intentos fallidos."
                        : $"Contraseña incorrecta. Te quedan {restantes} intento(s).";
                }
            }
            catch (Exception ex)
            {
                Resultado.Text = "Error: " + ex.Message;
            }
        }

        /// <summary>
        /// Redirige a la página de registro de nuevos usuarios
        /// </summary>
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroCliente.aspx");
        }
    }
}