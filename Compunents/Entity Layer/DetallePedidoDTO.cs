using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    /// <summary>
    /// DTO que extiende DetallePedido con información adicional del producto para visualización
    /// </summary>
    // Hereda de DetallePedido y añade las propiedades del producto
    public class DetallePedidoDTO : DetallePedido
    {
        public string NombreProducto { get; set; }
        public string UrlImagen { get; set; }
    }
}