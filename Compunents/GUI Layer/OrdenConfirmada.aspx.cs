using System;
using System.Web.UI;

namespace GUI_Layer
{
    public partial class OrdenConfirmada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string pedidoId = Request.QueryString["id"];
                    lblNumeroPedido.Text = int.Parse(pedidoId).ToString("D6");
                }
                else
                {
                    Response.Redirect("~/Inicio.aspx");
                }
            }
        }
    }
}