using Business_Logical_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI_Layer
{
    public partial class MisCompras : System.Web.UI.Page
    {
        private readonly PedidoBLL pedidoBLL = new PedidoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                    return;
                }
                CargarPedidos();
            }
        }

        private void CargarPedidos()
        {
            int idUsuario = Convert.ToInt32(Session["UserId"]);
            List<Pedido> pedidos = pedidoBLL.ObtenerPedidosPorUsuario(idUsuario);

            if (pedidos.Any())
            {
                pnlConPedidos.Visible = true;
                pnlSinPedidos.Visible = false;
                rptPedidos.DataSource = pedidos;
                rptPedidos.DataBind();
            }
            else
            {
                pnlConPedidos.Visible = false;
                pnlSinPedidos.Visible = true;
            }
        }


        protected void rptPedidos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Pedido pedidoActual = (Pedido)e.Item.DataItem;
                int idPedido = pedidoActual.IdPedido;

                Repeater rptDetalle = (Repeater)e.Item.FindControl("rptDetallePedido");
                List<DetallePedidoDTO> detalles = pedidoBLL.ObtenerDetallePorPedido(idPedido);

                rptDetalle.DataSource = detalles;
                rptDetalle.DataBind();
            }
        }
    }
}