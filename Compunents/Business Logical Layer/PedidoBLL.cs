using Data_Access_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logical_Layer
{
    public class PedidoBLL
    {
        private PedidoDAL mapper = new PedidoDAL();

        /// <summary>
        /// Confirma y procesa una compra convirtiendo el carrito en un pedido
        /// </summary>
        public int ConfirmarCompra(int idCarrito, int idLocalidad, decimal montoEnvio, string metodoPago)
        {
            return mapper.ConfirmarCompra(idCarrito, idLocalidad, montoEnvio, metodoPago);
        }

        /// <summary>
        /// Obtiene todos los pedidos realizados por un usuario específico
        /// </summary>
        public List<Pedido> ObtenerPedidosPorUsuario(int idUsuario)
        {
            return mapper.ObtenerPedidosPorUsuario(idUsuario);
        }

        /// <summary>
        /// Obtiene el detalle completo de productos de un pedido específico
        /// </summary>
        public List<DetallePedidoDTO> ObtenerDetallePorPedido(int idPedido)
        {
            return mapper.ObtenerDetallePorPedido(idPedido);
        }

    }
}
