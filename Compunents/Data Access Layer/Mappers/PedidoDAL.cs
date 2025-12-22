using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class PedidoDAL
    {

        DataAccess dataAccess = new DataAccess();

        /// <summary>
        /// Confirma una compra convirtiendo el carrito en un pedido y retorna el ID del pedido creado
        /// </summary>
        public int ConfirmarCompra(int idCarrito, int? idLocalidad, decimal montoEnvio, string metodoPago)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdCarrito", idCarrito),
                new SqlParameter("@IdLocalidad", (object)idLocalidad ?? DBNull.Value),
                new SqlParameter("@MontoEnvio", montoEnvio),
                new SqlParameter("@MetodoPago", metodoPago)
            };

            DataTable tablaResultado = dataAccess.Leer("SP_ConfirmarPedido", parametros.ToArray());

            if (tablaResultado != null && tablaResultado.Rows.Count > 0)
            {
                object nuevoId = tablaResultado.Rows[0][0];
                return Convert.ToInt32(nuevoId);
            }
            else
            {
                throw new Exception("No se pudo obtener el ID del nuevo pedido después de la confirmación.");
            }
        }

        /// <summary>
        /// Obtiene todos los pedidos realizados por un usuario específico
        /// </summary>
        public List<Pedido> ObtenerPedidosPorUsuario(int idUsuario)
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            SqlParameter[] parametros = new SqlParameter[]
            { 
                new SqlParameter("@IdUsuario", idUsuario) 
            };
            DataTable tabla = dataAccess.Leer("SP_ObtenerPedidosPorUsuario", parametros);

            foreach (DataRow dr in tabla.Rows)
            {
                listaPedidos.Add(new Pedido
                {
                    IdPedido = Convert.ToInt32(dr["Id_Pedido"]),
                    FechaPedido = Convert.ToDateTime(dr["FechaPedido"]),
                    Total = Convert.ToDecimal(dr["Total"]),
                    Estado = dr["Estado"].ToString(),
                    MetodoPago = dr["MetodoPago"].ToString()
                });
            }
            return listaPedidos;
        }

        /// <summary>
        /// Obtiene el detalle de productos de un pedido específico
        /// </summary>
        public List<DetallePedidoDTO> ObtenerDetallePorPedido(int idPedido)
        {
            List<DetallePedidoDTO> listaDetalle = new List<DetallePedidoDTO>();
            SqlParameter[] parametros = new SqlParameter[] 
            { 
                new SqlParameter("@IdPedido", idPedido) 
            };
            DataTable tabla = dataAccess.Leer("SP_ObtenerDetallePorPedido", parametros);

            foreach (DataRow dr in tabla.Rows)
            {
                listaDetalle.Add(new DetallePedidoDTO
                {
                    Cantidad = Convert.ToInt32(dr["Cantidad"]),
                    PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]),
                    NombreProducto = dr["Nombre"].ToString(),
                    UrlImagen = dr["ImagenUrl"].ToString()
                });
            }
            return listaDetalle;
        }

    }
}
