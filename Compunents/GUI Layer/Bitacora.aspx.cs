using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business_Logical_Layer;

namespace GUI_Layer
{

    /// <summary>
    /// Página de administración para consulta y filtrado de registros de la bitácora del sistema
    /// </summary>
    public partial class Bitacora : System.Web.UI.Page
    {
        BitacoraBLL bitacoraBLL = new BitacoraBLL();

        /// <summary>
        /// Inicializa la página verificando permisos de administrador y cargando registros
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBitacora();
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
        /// Aplica estilos visuales a las celdas de criticidad según su nivel
        /// </summary>
        protected void GridViewBitacora_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string criticidad = DataBinder.Eval(e.Row.DataItem, "Criticidad")?.ToString();
                string badgeClass = "";
                string texto = "";

                switch (criticidad)
                {
                    case "3":
                        badgeClass = "badge badge-low";
                        texto = "Baja";
                        break;
                    case "2":
                        badgeClass = "badge badge-medium";
                        texto = "Media";
                        break;
                    case "1":
                        badgeClass = "badge badge-high";
                        texto = "Alta";
                        break;
                    default:
                        texto = "N/A";
                        break;
                }

                e.Row.Cells[5].Text = $"<span class='{badgeClass}'>{texto}</span>";
            }
        }

        /// <summary>
        /// Carga los registros de bitácora aplicando los filtros seleccionados
        /// </summary>
        private void LoadBitacora()
        {
            var todosLosRegistros = bitacoraBLL.ConsultarBitacora();

            var registrosFiltrados = todosLosRegistros;

            if (!string.IsNullOrEmpty(txtUsuarioID.Text))
            {
                if (int.TryParse(txtUsuarioID.Text, out int usuarioId))
                {
                    registrosFiltrados = registrosFiltrados.Where(r => r.Id_user == usuarioId).ToList();
                }
            }

            if (!string.IsNullOrEmpty(ddlModulo.SelectedValue))
            {
                registrosFiltrados = registrosFiltrados.Where(r => r.Modulo == ddlModulo.SelectedValue).ToList();
            }

            if (!string.IsNullOrEmpty(ddlEvento.SelectedValue))
            {
                registrosFiltrados = registrosFiltrados.Where(r => r.Evento == ddlEvento.SelectedValue).ToList();
            }

            if (!string.IsNullOrEmpty(ddlCriticidad.SelectedValue))
            {
                if (int.TryParse(ddlCriticidad.SelectedValue, out int criticidad))
                {
                    registrosFiltrados = registrosFiltrados.Where(r => r.Criticidad == criticidad).ToList();
                }
            }

            if (!string.IsNullOrEmpty(txtFechaDesde.Text))
            {
                if (DateTime.TryParse(txtFechaDesde.Text, out DateTime fechaDesde))
                {
                    registrosFiltrados = registrosFiltrados.Where(r => r.Fecha >= fechaDesde).ToList();
                }
            }

            if (!string.IsNullOrEmpty(txtFechaHasta.Text))
            {
                if (DateTime.TryParse(txtFechaHasta.Text, out DateTime fechaHasta))
                {
                    registrosFiltrados = registrosFiltrados.Where(r => r.Fecha < fechaHasta.AddDays(1)).ToList();
                }
            }

            GridViewBitacora.DataSource = registrosFiltrados;
            GridViewBitacora.DataBind();
        }

        /// <summary>
        /// Aplica los filtros seleccionados y recarga la grilla
        /// </summary>
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            GridViewBitacora.PageIndex = 0;
            LoadBitacora();
        }

        /// <summary>
        /// Limpia todos los filtros y recarga la grilla con todos los registros
        /// </summary>
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUsuarioID.Text = string.Empty;
            txtFechaDesde.Text = string.Empty;
            txtFechaHasta.Text = string.Empty;
            ddlModulo.ClearSelection();
            ddlEvento.ClearSelection();
            ddlCriticidad.ClearSelection();

            GridViewBitacora.PageIndex = 0;
            LoadBitacora();
        }

        /// <summary>
        /// Maneja el cambio de página en la grilla de bitácora
        /// </summary>
        protected void GridViewBitacora_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewBitacora.PageIndex = e.NewPageIndex;
            LoadBitacora();
        }

    }
}