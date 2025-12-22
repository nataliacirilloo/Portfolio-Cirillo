using Business_Logical_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI_Layer
{
    /// <summary>
    /// Página del catálogo de productos con funcionalidad de carrito de compras integrado
    /// </summary>
    public partial class Compras : Page
    {
        private static int MasVendidoId = -1;
        private CarritoBLL carritoBLL = new CarritoBLL();
        private ProductoBLL productoBLL = new ProductoBLL();

        /// <summary>
        /// Inicializa la página verificando permisos de cliente y cargando productos
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] == null || Session["Rol"]?.ToString().ToLower() != "cliente")
                {
                    Response.Redirect("~/Login.aspx");
                    return;
                }
                WS_Ventas ws = new WS_Ventas();
                Producto masVendido = ws.ObtenerProductoMasVendido();

                if (masVendido != null)
                {
                    ViewState["MasVendidoId"] = masVendido.Id;
                }

                TopBarControl.SetActivePage("Compras.aspx");
                CargarProductos();
                CargarYActualizarWidget();
            }
        }

        /// <summary>
        /// Carga todos los productos activos en el catálogo
        /// </summary>
        private void CargarProductos()
        {
            rptProductos.DataSource = productoBLL.ObtenerProductosActivos();
            rptProductos.DataBind();
        }

        /// <summary>
        /// Maneja la adición de productos al carrito desde el catálogo principal
        /// </summary>
        protected void rptProductos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AgregarCarrito")
            {
                if (Session["UserId"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                    return;
                }

                int idUsuario = Convert.ToInt32(Session["UserId"]);
                int idProducto = Convert.ToInt32(e.CommandArgument);

                TextBox txtCantidad = (TextBox)e.Item.FindControl("txtCantidad");
                int cantidad = Convert.ToInt32(txtCantidad.Text);

                Producto producto = productoBLL.ObtenerProductoPorId(idProducto);
                if (producto == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Toast", "showToast('Producto no válido.');", true);
                    return;
                }

                if (producto.Stock <= 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Toast", "showToast('El producto no tiene stock disponible.');", true);
                    return;
                }

                Carrito carrito = carritoBLL.ObtenerCarritoActivo(idUsuario);
                int cantidadEnCarrito = carrito?.Items.FirstOrDefault(i => i.IdProducto == idProducto)?.Cantidad ?? 0;
                int totalSolicitado = cantidadEnCarrito + cantidad;

                if (totalSolicitado > producto.Stock)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Toast", $"showToast('Stock insuficiente. Máximo disponible: {producto.Stock - cantidadEnCarrito} unidades.');", true);
                    return;
                }

                carritoBLL.AgregarProducto(idUsuario, idProducto, cantidad);
                CargarYActualizarWidget();

                ScriptManager.RegisterStartupScript(this, GetType(), "Toast", "showToast('¡Producto agregado al carrito!');", true);
            }
        }

        /// <summary>
        /// Maneja las acciones del widget de carrito flotante (sumar, restar, eliminar)
        /// </summary>
        protected void rptWidgetCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (Session["UserId"] == null) { Response.Redirect("~/Login.aspx"); return; }
            int idUsuario = Convert.ToInt32(Session["UserId"]);
            int idItem = Convert.ToInt32(e.CommandArgument);

            Carrito carrito = carritoBLL.ObtenerCarritoActivo(idUsuario);
            CarritoItem item = carrito?.Items.FirstOrDefault(i => i.IdItem == idItem);
            Producto producto = productoBLL.ObtenerProductoPorId(item?.IdProducto ?? 0);

            if (item == null || producto == null) return;

            switch (e.CommandName)
            {
                case "Sumar":
                    if (item.Cantidad < producto.Stock)
                    {
                        carritoBLL.ActualizarCantidadItem(idUsuario, item.IdProducto, item.Cantidad + 1);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Toast", "showToast('No hay más stock disponible.');", true);
                    }
                    break;

                case "Restar":
                    if (item.Cantidad > 1)
                    {
                        carritoBLL.ActualizarCantidadItem(idUsuario, item.IdProducto, item.Cantidad - 1);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Toast", "showToast('La cantidad mínima es 1.');", true);
                    }
                    break;

                case "Eliminar":
                    carritoBLL.EliminarProducto(idUsuario, item.IdProducto);
                    break;
            }

            CargarYActualizarWidget();
        }

        /// <summary>
        /// Actualiza el widget de carrito con los items actuales y calcula totales
        /// </summary>
        private void CargarYActualizarWidget()
        {
            if (Session["UserId"] == null) return;
            int idUsuario = Convert.ToInt32(Session["UserId"]);

            Carrito carrito = carritoBLL.ObtenerCarritoActivo(idUsuario);

            if (carrito != null && carrito.Items.Any())
            {
                pnlWidgetItems.Visible = true;
                pnlWidgetVacio.Visible = false;
                pnlWidgetFooter.Visible = true;
                cartBadge.Visible = true;
                cartBadge.InnerText = carrito.Items.Count.ToString();

                var itemsParaWidget = from item in carrito.Items
                                      let producto = productoBLL.ObtenerProductoPorId(item.IdProducto)
                                      where producto != null
                                      select new
                                      {
                                          IdItem = item.IdItem,
                                          UrlImagen = producto.UrlImagen,
                                          Nombre = producto.Nombre,
                                          PrecioUnitario = item.PrecioUnitario,
                                          Cantidad = item.Cantidad,
                                      };

                rptWidgetCarrito.DataSource = itemsParaWidget.ToList();
                rptWidgetCarrito.DataBind();
                lblWidgetTotal.Text = carrito.Total.ToString("C");
            }
            else
            {
                pnlWidgetItems.Visible = false;
                pnlWidgetVacio.Visible = true;
                pnlWidgetFooter.Visible = false;
                cartBadge.Visible = false;
            }

            updPanelWidget.Update();
        }

        /// <summary>
        /// Aplica filtros de búsqueda al catálogo de productos
        /// </summary>
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string busqueda = txtBuscar.Text.Trim();
                string categoria = ddlCategoria.SelectedValue;
                decimal precioMax = 0;
                decimal.TryParse(txtPrecioMax.Text, out precioMax);

                var productos = FiltrarProductosEjemplo(busqueda, categoria, precioMax);

                if (productos.Count > 0)
                {
                    rptProductos.DataSource = productos;
                    rptProductos.DataBind();
                    pnlEmpty.Visible = false;
                }
                else
                {
                    rptProductos.DataSource = null;
                    rptProductos.DataBind();
                    pnlEmpty.Visible = true;
                }
            }
            catch (Exception ex)
            {
                pnlEmpty.Visible = true;
            }
        }

        /// <summary>
        /// Redirige a la página del carrito de compras
        /// </summary>
        protected void btnVerCarrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MiCarrito.aspx");
        }

        /// <summary>
        /// Obtiene la lista de productos activos del sistema
        /// </summary>
        private List<Producto> ObtenerProductos()
        {
            return productoBLL.ObtenerProductosActivos();
        }

        /// <summary>
        /// Aplica filtros de búsqueda, categoría y precio a la lista de productos
        /// </summary>
        private List<dynamic> FiltrarProductosEjemplo(string busqueda, string categoria, decimal precioMax)
        {
            var productos = ObtenerProductos();
            var resultado = new List<dynamic>();

            foreach (var producto in productos)
            {
                bool cumpleFiltros = true;

                if (!string.IsNullOrEmpty(busqueda))
                {
                    cumpleFiltros = cumpleFiltros && producto.Nombre.ToLower().Contains(busqueda.ToLower());
                }

                if (!string.IsNullOrEmpty(categoria))
                {
                    cumpleFiltros = cumpleFiltros && producto.Categoria == categoria;
                }

                if (precioMax > 0)
                {
                    cumpleFiltros = cumpleFiltros && producto.Precio <= precioMax;
                }

                if (cumpleFiltros)
                {
                    resultado.Add(producto);
                }
            }

            return resultado;
        }
        protected void rptProductos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Si tu datasource es List<Producto>
                var dataItem = (Producto)e.Item.DataItem;
                int idProducto = dataItem.Id;

                Panel pnlMasVendido = (Panel)e.Item.FindControl("pnlMasVendido");
                int masVendidoId = (int)(ViewState["MasVendidoId"] ?? -1);

                pnlMasVendido.Visible = (idProducto == masVendidoId);
            }
        }

    }
}
