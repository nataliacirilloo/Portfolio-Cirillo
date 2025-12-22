using Business_Logical_Layer;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;

namespace GUI_Layer
{
    /// <summary>
    /// Página de administración para gestión de backups y recuperación de la base de datos
    /// </summary>
    public partial class Backup : System.Web.UI.Page
    {
        /// <summary>
        /// Verifica permisos de administrador al cargar la página
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null && Session["Rol"] == null)
                {
                    Response.Redirect("Inicio.aspx");
                    return;
                }

                if (Session["Rol"].ToString() != "admin")
                {
                    Response.Redirect("Inicio.aspx");
                    return;
                }
            }
        }

        /// <summary>
        /// Ejecuta el proceso de backup de la base de datos
        /// </summary>
        protected void btnRealizarBackup_Click(object sender, EventArgs e)
        {
            try
            {
                int idUsuario = Convert.ToInt32(Session["UserId"]);
                BackupBLL.HacerBackup(idUsuario);
                MostrarExito($"Backup realizado con éxito. {DateTime.Now}");
            }
            catch (Exception ex)
            {
                MostrarError($"Error al realizar el backup: {ex.Message}");
            }
        }

        /// <summary>
        /// Muestra mensaje de éxito con estilos apropiados
        /// </summary>
        private void MostrarExito(string mensaje)
        {
            lblResultado.Text = mensaje;
            lblResultado.CssClass = "feedback-message feedback-success";
            lblResultado.Visible = true;
        }

        /// <summary>
        /// Muestra mensaje de error con estilos apropiados
        /// </summary>
        private void MostrarError(string mensaje)
        {
            lblResultado.Text = mensaje;
            lblResultado.CssClass = "feedback-message feedback-error";
            lblResultado.Visible = true;
        }

        /// <summary>
        /// Simula corrupción de datos para pruebas de recuperación
        /// </summary>
        protected void btnCorromperDB_Click(object sender, EventArgs e)
        {
            ProductoBLL productoBLL = new ProductoBLL();
            LocalidadBLL localidadBLL = new LocalidadBLL();
            try
            {
                productoBLL.Corromper();
                localidadBLL.Corromper();
                MostrarExito("Base de datos corrompida exitosamente.");
            }
            catch (Exception ex)
            {
                MostrarError($"Error al corromper la base de datos: {ex.Message}");
            }


        }
    }
}