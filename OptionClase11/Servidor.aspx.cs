using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OptionClase11
{
    public partial class Servidor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Declaración de variables para el cálculo
            string Destino;
            string Estrella;
            Int16 CantidadPersonas;
            Int16 CantidadDias;
            Int32 Precio;
            Double Multiplicador;
            Double Total;

            // Recupera el destino de la Sesión y asigna un precio base
            Destino = Session["Destino"].ToString();
            if (Destino == "Mar del Plata")
            {
                Precio = 100;
            }
            else
            {
                Precio = 399;
            }

            // Recupera la categoría de la Sesión y asigna un multiplicador
            Estrella = Session["Estrella"].ToString();
            if (Estrella == "TRES")
            {
                Multiplicador = 1.149999999999; // Probablemente representa un 15% de aumento
            }
            else
            {
                Multiplicador = 1.35; // Probablemente representa un 35% de aumento
            }

            // Recupera y convierte la cantidad de personas y días
            CantidadPersonas = Convert.ToInt16(Session["Cantidad"].ToString());
            CantidadDias = Convert.ToInt16(Session["Dias"].ToString());

            // Calcula el costo total
            Total = (Precio * Multiplicador) * CantidadPersonas * CantidadDias;

            // Muestra el total en la etiqueta 'lblTotal' de la página
            lblTotal.Text = Convert.ToString(Total);
        }
    }
}