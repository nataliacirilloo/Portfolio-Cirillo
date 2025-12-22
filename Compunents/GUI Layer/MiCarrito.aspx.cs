using Business_Logical_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity_Layer;

namespace GUI_Layer
{
    public partial class MiCarrito : System.Web.UI.Page
    {
        private CarritoBLL carritoBLL = new CarritoBLL();
        private ProductoBLL productoBLL = new ProductoBLL();
        private LocalidadBLL localidadBLL = new LocalidadBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarLocalidades();
                CargarYEnlazarCarrito();
            }
        }

        private void CargarYEnlazarCarrito()
        {
            try
            {
                if (Session["UserId"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                    return;
                }
                int idUsuario = Convert.ToInt32(Session["UserId"]);

                Carrito carrito = carritoBLL.ObtenerCarritoActivo(idUsuario);

                if (carrito != null && carrito.Items.Any())
                {
                    pnlCarritoConItems.Visible = true;
                    pnlCarritoVacio.Visible = false;

                    var itemsParaMostrar = from item in carrito.Items
                                           let producto = productoBLL.ObtenerProductoPorId(item.IdProducto)
                                           where producto != null
                                           select new
                                           {
                                               IdItem = item.IdItem,
                                               UrlImagen = producto.UrlImagen,
                                               Nombre = producto.Nombre,
                                               PrecioUnitario = item.PrecioUnitario,
                                               Cantidad = item.Cantidad,
                                               Subtotal = item.Cantidad * item.PrecioUnitario
                                           };

                    rptCarrito.DataSource = itemsParaMostrar.ToList();
                    rptCarrito.DataBind();

                    // --- LÓGICA DE CÁLCULO DE ENVÍO ---
                    decimal costoEnvio = 0;
                    bool envioGratisAlcanzado = false;
                    pnlLocalidades.Visible = rbEnvioDomicilio.Checked; 

                    if (rbEnvioDomicilio.Checked && ddlLocalidades.SelectedValue != "0")
                    {
                        int idLocalidadSeleccionada = Convert.ToInt32(ddlLocalidades.SelectedValue);
                        Localidad localidad = localidadBLL.ObtenerPorId(idLocalidadSeleccionada);

                        if (localidad != null)
                        {
                            // Comprobamos si el subtotal supera el monto mínimo para envío gratis
                            if (carrito.Subtotal >= localidad.MontoMinimoEnvio)
                            {
                                costoEnvio = 0; 
                                envioGratisAlcanzado = true;
                            }
                            else
                            {
                                costoEnvio = localidad.CostoEnvio;
                            }
                        }
                    }

                    lblSubtotalResumen.Text = carrito.Subtotal.ToString("C");
                    if (envioGratisAlcanzado)
                    {
                        lblCostoEnvio.Text = "Gratis!";
                        lblCostoEnvio.CssClass += " text-success font-weight-bold"; // Opcional: le damos color verde
                    }
                    else
                    {
                        lblCostoEnvio.Text = costoEnvio.ToString("C"); // Muestra $0,00 para retiro o el costo
                        lblCostoEnvio.CssClass = lblCostoEnvio.CssClass.Replace(" text-success font-weight-bold", "");
                    }
                    lblTotal.Text = (carrito.Total + costoEnvio).ToString("C");
                    ViewState["CostoEnvioNumerico"] = costoEnvio;
                }
                else
                {
                    pnlCarritoConItems.Visible = false;
                    pnlCarritoVacio.Visible = true;
                }
            }
            catch (Exception ex)
            {
                // Manejar error
                pnlCarritoConItems.Visible = false;
                pnlCarritoVacio.Visible = true;
            }
        }
        protected void rptCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            int idUsuario = Convert.ToInt32(Session["UserId"]);
            int idItem = Convert.ToInt32(e.CommandArgument);

            Carrito carrito = carritoBLL.ObtenerCarritoActivo(idUsuario);
            CarritoItem item = carrito?.Items.FirstOrDefault(i => i.IdItem == idItem);
            if (item == null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Toast", "showToast('Item no encontrado en el carrito.');", true);
                return;
            }

            Producto producto = new ProductoBLL().ObtenerProductoPorId(item.IdProducto);
            if (producto == null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Toast", "showToast('Producto no disponible.');", true);
                return;
            }

            switch (e.CommandName)
            {
                case "Sumar":
                    if (item.Cantidad < producto.Stock)
                    {
                        carritoBLL.ActualizarCantidadItem(idUsuario, item.IdProducto, item.Cantidad + 1);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Toast", $"showToast('No hay más stock disponible. Máximo: {producto.Stock}.');", true);
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

                case "ActualizarCantidad":
                    Label txtCantidad = (Label)e.Item.FindControl("txtCantidad");
                    if (txtCantidad != null && int.TryParse(txtCantidad.Text, out int nuevaCantidad))
                    {
                        if (nuevaCantidad < 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Toast", "showToast('La cantidad mínima es 1.');", true);
                        }
                        else if (nuevaCantidad > producto.Stock)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Toast", $"showToast('Stock insuficiente. Máximo permitido: {producto.Stock}.');", true);
                        }
                        else
                        {
                            carritoBLL.ActualizarCantidadItem(idUsuario, item.IdProducto, nuevaCantidad);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Toast", "showToast('Cantidad inválida.');", true);
                    }
                    break;

                case "Eliminar":
                    carritoBLL.EliminarProducto(idUsuario, item.IdProducto);
                    break;
            }

            CargarYEnlazarCarrito();
        }


        protected void btnProceedToPayment_Click(object sender, EventArgs e)
        {
            // Verificamos la sesión aquí también por seguridad
            if (Session["UserId"] == null)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            decimal costoEnvio = (decimal)(ViewState["CostoEnvioNumerico"] ?? 0.0m);

            Session["CostoEnvio"] = costoEnvio;
            Session["IdLocalidad"] = rbEnvioDomicilio.Checked ? ddlLocalidades.SelectedValue : "0";

            Response.Redirect("~/Checkout.aspx");
        }

        private void CargarLocalidades()
        {
            ddlLocalidades.DataSource = localidadBLL.ObtenerLocalidades();
            ddlLocalidades.DataTextField = "Nombre"; 
            ddlLocalidades.DataValueField = "IdLocalidad"; 
            ddlLocalidades.DataBind();
            ddlLocalidades.Items.Insert(0, new ListItem("Seleccione una localidad...", "0"));
        }

        protected void shippingOption_CheckedChanged(object sender, EventArgs e)
        {
            CargarYEnlazarCarrito();
        }
    }
}