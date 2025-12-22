// ===============================
// Restore.aspx.cs (XML-ready)
// ===============================
using Business_Logical_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI_Layer
{
    /// <summary>
    /// Página de administración para restaurar backups de la base de datos
    /// </summary>
    public partial class Restore : Page
    {
        /// <summary>
        /// Clase para representar información de archivos de backup
        /// </summary>
        public class BackupFile
        {
            public string FileName { get; set; }
            public DateTime CreationDate { get; set; }
            public string FileSize { get; set; }
        }

        // Nota: se elimina BackupData (era solo para JSON)

        /// <summary>
        /// Verifica permisos de administrador y carga la lista de archivos de backup
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["Rol"] == null || Session["Rol"].ToString().ToLower() != "admin")
            {
                Response.Redirect("Inicio.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CargarArchivosBackup();
            }
        }

        /// <summary>
        /// Maneja el cambio de página en la grilla de backups
        /// </summary>
        protected void GridViewBackups_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewBackups.PageIndex = e.NewPageIndex;
            CargarArchivosBackup();
        }

        /// <summary>
        /// Procesa la restauración de un backup seleccionado
        /// </summary>
        protected void GridViewBackups_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Restaurar")
            {
                try
                {
                    string fileName = e.CommandArgument?.ToString() ?? string.Empty;

                    // Seguridad básica: solo nombre de archivo y extensión .xml
                    string safeName = Path.GetFileName(fileName);
                    if (!safeName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                        throw new ArgumentException("El archivo debe tener extensión .xml.");

                    int idUsuario = Convert.ToInt32(Session["UserId"]);

                    // Delegar toda la validación y deserialización a la BLL
                    BackupBLL.RestaurarBackup(idUsuario, safeName);

                    MostrarMensaje($"La restauración desde el archivo '{safeName}' se ha completado correctamente.", "success");
                }
                catch (Exception ex)
                {
                    MostrarMensaje($"Ocurrió un error al intentar restaurar: {ex.Message}", "error");
                }
            }
        }

        /// <summary>
        /// Carga la lista de archivos de backup disponibles desde el directorio
        /// </summary>
        private void CargarArchivosBackup()
        {
            string backupFolderPath = Server.MapPath("~/Backups/");
            if (!Directory.Exists(backupFolderPath))
            {
                MostrarMensaje("La carpeta de backups no se encontró.", "error");
                GridViewBackups.DataSource = new List<BackupFile>();
                GridViewBackups.DataBind();
                return;
            }

            var backupFiles = Directory.GetFiles(backupFolderPath, "*.xml")
                .Select(file => new FileInfo(file))
                .Select(f => new BackupFile
                {
                    FileName = f.Name,
                    CreationDate = f.CreationTime,
                    FileSize = FormatFileSize(f.Length)
                })
                .OrderByDescending(f => f.CreationDate)
                .ToList();

            GridViewBackups.DataSource = backupFiles;
            GridViewBackups.DataBind();
        }

        /// <summary>
        /// Convierte el tamaño del archivo en bytes a formato legible (KB, MB, etc.)
        /// </summary>
        private string FormatFileSize(long bytes)
        {
            if (bytes < 1024) return $"{bytes} B";
            double size = bytes;
            string[] units = { "KB", "MB", "GB", "TB", "PB", "EB" };
            int unitIndex = -1;
            do
            {
                size /= 1024;
                unitIndex++;
            } while (size >= 1024 && unitIndex < units.Length - 1);

            return $"{size:F2} {units[unitIndex]}";
        }

        /// <summary>
        /// Muestra mensajes de resultado al usuario con estilos apropiados
        /// </summary>
        private void MostrarMensaje(string mensaje, string tipo)
        {
            lblResultado.Text = System.Web.HttpUtility.HtmlEncode(mensaje);
            lblResultado.CssClass = $"feedback-message feedback-{tipo}";
            lblResultado.Visible = true;
        }
    }
}
