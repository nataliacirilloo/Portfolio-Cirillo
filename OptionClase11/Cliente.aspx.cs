using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OptionClase11
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Session["Destino"] = rblDestino.SelectedItem.Text;
            Session["Estrella"] = rblEstrella.SelectedItem.Text;
            Session["Cantidad"] = txtCantidad.Text;
            Session["Dias"] = txtDias.Text;

            Response.Redirect("Servidor.aspx");
        }
    }
}