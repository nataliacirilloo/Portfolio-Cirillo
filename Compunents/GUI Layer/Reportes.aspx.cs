using Business_Logical_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace GUI_Layer
{
    /// <summary>
    /// Página de administración que muestra el reporte mensual usando el WS vía BLL.
    /// Reutiliza el mismo patrón de verificación de Backup.aspx (sesión y rol admin).
    /// </summary>
    public partial class Reportes : Page
    {
        ReporteMensualBLL bll = new ReporteMensualBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Mismo chequeo que usás en Backup.aspx.cs
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

                BindGrid();
            }
        }

        private void BindGrid(string sortExpression = null, bool asc = true)
        {
            try
            {
                List<ReporteMensual> data = bll.ObtenerReporteMensual(); // BLL llama al WS/mapeos

                if (!string.IsNullOrEmpty(sortExpression))
                {
                    // Orden simple en memoria
                    Func<ReporteMensual, object> key = r => r.Id_Producto;
                    switch (sortExpression)
                    {
                        case "NombreProducto": key = r => r.NombreProducto; break;
                        case "Id_Pedido": key = r => r.Id_Pedido; break;
                        case "TotalItems": key = r => r.TotalItems; break;
                        case "SubtotalItem": key = r => r.SubtotalItem; break;
                        case "TotalCalculado": key = r => r.TotalCalculado; break;
                        default: key = r => r.Id_Producto; break;
                    }
                    data = asc ? data.OrderBy(key).ToList() : data.OrderByDescending(key).ToList();
                }

                gvReporte.DataSource = data;
                gvReporte.DataBind();

                MostrarExito($"Se cargaron {data.Count} filas.");
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar el reporte: " + ex.Message);
            }
        }

        protected void btnRefrescar_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void gvReporte_Sorting(object sender, GridViewSortEventArgs e)
        {
            // Toggle simple: si repetís el mismo campo, invierte; si no, ascendente
            bool asc = true;
            if (ViewState["SortField"] as string == e.SortExpression)
                asc = !(ViewState["SortAsc"] as bool? ?? true);

            ViewState["SortField"] = e.SortExpression;
            ViewState["SortAsc"] = asc;
            BindGrid(e.SortExpression, asc);
        }

        // Exportar el reporte mensual a XML usando XSLT. 
        // Similar a Backup.aspx.cs pero con XSLT.
        protected void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                List<ReporteMensual> lista = bll.ObtenerReporteMensual();

                // Construyo el XML fuente
                var xml = new XDocument(
                    new XElement("ReporteMensual",
                        from r in lista
                        select new XElement("Producto",
                            new XElement("Id_Producto", r.Id_Producto),
                            new XElement("NombreProducto", r.NombreProducto ?? ""),
                            new XElement("Id_Pedido", r.Id_Pedido),
                            new XElement("TotalItems", r.TotalItems),
                            new XElement("SubtotalItem", r.SubtotalItem),
                            new XElement("TotalCalculado", r.TotalCalculado)
                        )
                    )
                );

                // Cargar XSLT
                string xsltPath = Server.MapPath("~/ExportacionXML/reporte_mensual.xslt");
                var transform = new XslCompiledTransform();
                var settings = new XsltSettings(false, false);
                using (var xrXslt = XmlReader.Create(xsltPath))
                {
                    transform.Load(xrXslt, settings, new XmlUrlResolver());
                }

                // Exportar la transformación como XML
                Response.Clear();
                Response.ContentType = "application/xml";
                Response.AddHeader("Content-Disposition", "attachment; filename=reporte_mensual.xml");

                using (var xr = xml.CreateReader())
                using (var xw = XmlWriter.Create(Response.OutputStream, transform.OutputSettings))
                {
                    transform.Transform(xr, xw);
                }

                // Limpiamos el html para que no interfiera con el archivo
                Response.Flush();
                Response.End();
            }
            // Catcheamos errores específicos de XSLT o cualquier otra excepción que pueda surgir
            catch (XsltException xe)
            {
                MostrarError($"XSLT error: {xe.Message} (L{xe.LineNumber}, C{xe.LinePosition})");
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo exportar: " + ex.Message);
            }
        }

        private void MostrarExito(string mensaje)
        {
            lblResultado.Text = mensaje;
            lblResultado.CssClass = "feedback-message feedback-success";
            lblResultado.Visible = true;
        }

        private void MostrarError(string mensaje)
        {
            lblResultado.Text = mensaje;
            lblResultado.CssClass = "feedback-message feedback-error";
            lblResultado.Visible = true;
        }
    }
}
