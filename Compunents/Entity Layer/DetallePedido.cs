using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    /// <summary>
    /// Representa el detalle de un producto específico dentro de un pedido
    /// </summary>
    public class DetallePedido
    {
        public int Id_Detalle { get; set; }
        public int Id_Pedido { get; set; }
        public int Id_Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
