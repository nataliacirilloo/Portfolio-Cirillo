using System;
using System.Data.SqlClient;
using System.Web.UI;
using Business_Logical_Layer;

namespace GUI_Layer
{
    /// <summary>
    /// Página principal del sistema que muestra el dashboard y alertas de corrupción
    /// </summary>
    public partial class Inicio : Page
    {
        UsuarioBLL user = new UsuarioBLL();
        BackupBLL backupBLL = new BackupBLL();

        /// <summary>
        /// Carga la página principal verificando autenticación y mostrando alertas de corrupción para administradores
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string username = Session["username"] as string;

                if (username == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                TopBarControl.SetActivePage("Inicio.aspx");

                if (Session["rol"].ToString() == "admin")
                {
                    var resultado = backupBLL.VerificarCorrupcion();
                    if (resultado.productosCorruptos || resultado.localidadesCorruptas)
                    {
                        string mensaje = "<div class='alert alert-danger mt-4' role='alert'>" +
                                         "<strong>¡Atención!</strong> Se detectaron registros corruptos en: ";

                        if (resultado.productosCorruptos) mensaje += "Productos ";
                        if (resultado.localidadesCorruptas) mensaje += "Localidades ";

                        mensaje += "</div>";

                        litAlertaCorrupcion.Text = mensaje;
                    }
                }

            }
        }

        /// <summary>
        /// Configura el evento de logout del control TopBar
        /// </summary>
        protected void Page_Init(object sender, EventArgs e)
        {
            TopBarControl.LogoutClicked += TopBarControl_LogoutClicked;
        }

        /// <summary>
        /// Maneja el evento de logout del usuario
        /// </summary>
        private void TopBarControl_LogoutClicked(object sender, EventArgs e)
        {
        }
    }
}
