using Business_Logical_Layer;
using Entity_Layer;
using System;
using System.Web.UI;

namespace GUI_Layer.Controls
{
    public partial class TopBar : UserControl
    {
        UsuarioBLL user = new UsuarioBLL();
        public event EventHandler LogoutClicked;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRolUsuario();
                MostrarNavegacionSegunRol();
            }
        }

        private void CargarRolUsuario()
        {
            string username = Session["username"] as string;

            if (username == null)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            try
            {
                var usuario = user.TraerUser(username);
                LblRol.Text = usuario.Nombre_Perfil;

                // Sincronizar con la sesión de Rol si no existe
                if (Session["Rol"] == null)
                {
                    Session["Rol"] = usuario.Nombre_Perfil;
                }
            }
            catch (Exception)
            {
                // Si hay error al obtener el usuario, limpiar sesión y redirigir
                Session.Clear();
                Response.Redirect("~/Login.aspx");
            }
        }

        private void MostrarNavegacionSegunRol()
        {
            // Ocultar todos los paneles primero
            PanelCliente.Visible = false;
            PanelEmpleado.Visible = false;
            PanelAdmin.Visible = false;

            // Mostrar panel según el rol
            string rolUsuario = Session["Rol"]?.ToString()?.ToLower();

            switch (rolUsuario)
            {
                case "admin":
                case "administrador":
                    PanelAdmin.Visible = true;
                    break;
                case "empleado":
                    PanelEmpleado.Visible = true;
                    break;
                case "cliente":
                    PanelCliente.Visible = true;
                    break;
                default:
                    // Rol no reconocido, redirigir al login
                    Response.Redirect("~/Login.aspx");
                    break;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Limpiar sesión
            Session.Clear();
            Session.Abandon();

            // Disparar evento personalizado si hay suscriptores
            LogoutClicked?.Invoke(this, e);

            // Redirigir al login
            Response.Redirect("~/Login.aspx");
        }

        // Método público para establecer el usuario desde la página padre
        public void SetUser(string username, string rol)
        {
            Session["username"] = username;
            Session["Rol"] = rol;
            LblRol.Text = rol;
            MostrarNavegacionSegunRol();
        }

        // Método público para obtener el rol actual
        public string GetUserRole()
        {
            return Session["Rol"]?.ToString() ?? "";
        }

        // Método público para obtener el username actual
        public string GetUsername()
        {
            return Session["username"]?.ToString() ?? "";
        }

        // Método para resaltar la página activa
        public void SetActivePage(string pageName)
        {
            string script = $@"
                document.addEventListener('DOMContentLoaded', function() {{
                    var navLinks = document.querySelectorAll('.nav-bar a');
                    navLinks.forEach(function(link) {{
                        link.classList.remove('active');
                        if (link.getAttribute('href') === '{pageName}') {{
                            link.classList.add('active');
                        }}
                    }});
                }});";

            if (Page != null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SetActivePage", script, true);
            }
        }

        // Método para recargar información del usuario
        public void RefreshUserInfo()
        {
            CargarRolUsuario();
            MostrarNavegacionSegunRol();
        }
    }
}
