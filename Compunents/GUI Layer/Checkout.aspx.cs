using Business_Logical_Layer;
using Entity_Layer;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI_Layer
{
    /// <summary>
    /// Página de finalización de compra con opciones de pago por tarjeta y transferencia
    /// </summary>
    public partial class Checkout : System.Web.UI.Page
    {
        private readonly CarritoBLL carritoBLL = new CarritoBLL();
        private readonly ProductoBLL productoBLL = new ProductoBLL();
        private readonly PagoBLL pagoBLL = new PagoBLL(); 
        private readonly PedidoBLL pedidoBLL = new PedidoBLL(); 

        /// <summary>
        /// Carga el resumen de la compra al inicializar la página
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarResumenDeCompra();
            }
        }

        /// <summary>
        /// Carga y muestra el resumen de productos, subtotal, envío y total final
        /// </summary>
        private void CargarResumenDeCompra()
        {
            if (Session["UserId"] == null) { Response.Redirect("~/Login.aspx"); return; }
            int idUsuario = Convert.ToInt32(Session["UserId"]);

            Carrito carrito = carritoBLL.ObtenerCarritoActivo(idUsuario);

            if (carrito == null || !carrito.Items.Any())
            {
                Response.Redirect("~/Compras.aspx");
                return;
            }

            decimal costoEnvio = (decimal)(Session["CostoEnvio"] ?? 0.0m);
            decimal totalFinal = carrito.Total + costoEnvio;

            lblSubtotal.Text = carrito.Subtotal.ToString("C");
            lblEnvio.Text = costoEnvio.ToString("C");
            lblTotal.Text = totalFinal.ToString("C");
        }

        /// <summary>
        /// Procesa el pago con tarjeta de crédito/débito validando los datos ingresados
        /// </summary>
        protected void btnConfirmarConTarjeta_Click(object sender, EventArgs e)
        {
            string numero = txtNumeroTarjeta.Text.Trim();
            string nombre = txtNombreTitular.Text.Trim();
            string vencimiento = txtFechaVencimiento.Text.Trim();
            string cvv = txtCodigoSeguridad.Text.Trim();

            PagoBLL pagoBLL = new PagoBLL();
            bool esValida = pagoBLL.ValidarTarjeta(numero, nombre, vencimiento, cvv);

            if (esValida)
            {
                lblErrorPago.Visible = false;
                FinalizarCompra("Tarjeta de Crédito/Débito");
            }
            else
            {
                lblErrorPago.Text = "Los datos de la tarjeta son incorrectos o no son aceptados.";
                lblErrorPago.Visible = true;
            }
        }

        /// <summary>
        /// Procesa el pago por transferencia bancaria
        /// </summary>
        protected void btnConfirmarTransferencia_Click(object sender, EventArgs e)
        {
            FinalizarCompra("Transferencia Bancaria");
        }

        /// <summary>
        /// Finaliza el proceso de compra creando el pedido y vaciando el carrito
        /// </summary>
        private void FinalizarCompra(string metodoPago)
        {
            try
            {
                int idUsuario = Convert.ToInt32(Session["UserId"]);
                Carrito carrito = carritoBLL.ObtenerCarritoActivo(idUsuario);

                decimal costoEnvio = (decimal)(Session["CostoEnvio"] ?? 0.0m);
                int idLocalidad = Convert.ToInt32(Session["IdLocalidad"] ?? "0");

                if (idLocalidad == 0 && costoEnvio > 0)
                {
                    throw new Exception("Por favor, seleccione una localidad para el envío.");
                }

                int nuevoPedidoId = pedidoBLL.ConfirmarCompra(carrito.IdCarrito, idLocalidad, costoEnvio, metodoPago);

                Session.Remove("CostoEnvio");
                Session.Remove("IdLocalidad");

                Response.Redirect($"~/OrdenConfirmada.aspx?id={nuevoPedidoId}");
            }
            catch (Exception ex)
            {
                lblErrorPago.Text = "Error al procesar el pedido: " + ex.Message;
                lblErrorPago.Visible = true;
            }
        }
    }
}