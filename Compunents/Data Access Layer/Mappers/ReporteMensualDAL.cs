using System;
using System.Collections.Generic;
using System.Data;


namespace Data_Access_Layer.Mappers
{
    public class ReporteMensualDAL
    {
        DataAccess DataAccess = new DataAccess();

        /// <summary>
        /// Obtiene la lista de productos vendidos en el último mes.
        /// </summary>
        public List<ReporteMensual> ListarVentasUltimosMes()
        {
            DataTable dt = DataAccess.Leer("SP_ObtenerVentasUltimos30Dias");
            List<ReporteMensual> pedidos = new List<ReporteMensual>();

            foreach (DataRow dr in dt.Rows)
            {
                ReporteMensual rm = new ReporteMensual();

                rm.Id_Pedido = Convert.ToInt32(dr["Id_Pedido"]);
                rm.FechaPedido = Convert.ToDateTime(dr["FechaPedido"]);
                rm.MontoEnvio = Convert.ToInt32(dr["MontoEnvio"]);
                rm.TotalPedidoGuardado = Convert.ToInt32(dr["TotalPedidoGuardado"]);
                rm.Id_Producto = Convert.ToInt32(dr["Id_Producto"]);
                rm.NombreProducto = dr["NombreProducto"].ToString();
                rm.SubtotalItem = Convert.ToInt32(dr["SubtotalItem"]);
                rm.TotalItems = Convert.ToInt32(dr["TotalItems"]);
                rm.TotalCalculado = Convert.ToInt32(dr["TotalCalculado"]);

                pedidos.Add(rm);
            }

            return pedidos;
        }
    }
}
