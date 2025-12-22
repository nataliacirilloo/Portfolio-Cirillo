using Data_Access_Layer.Mappers;
using System.Collections.Generic;
using System;

namespace Business_Logical_Layer
{
    public class ReporteMensualBLL
    {
        ReporteMensualDAL reporteMensualDAL = new ReporteMensualDAL();

        /// <summary>
        /// Método encargado de obtener una lista de productos vendidos en el último mes.
        /// <summary>
        public List<ReporteMensual> ObtenerFilasParaReporte()
        {
            return reporteMensualDAL.ListarVentasUltimosMes();
        }

        public List<ReporteMensual> ObtenerReporteMensual()
        {
            var filasEntity = ObtenerFilasParaReporte();   // List<Entity_Layer.ReporteMensual>

            // mapear -> array del proxy
            var request = new ReportesWS.ReporteMensual[filasEntity.Count];
            for (int i = 0; i < filasEntity.Count; i++)
            {
                var f = filasEntity[i];
                request[i] = new ReportesWS.ReporteMensual
                {
                    Id_Pedido = f.Id_Pedido,
                    FechaPedido = f.FechaPedido,
                    MontoEnvio = f.MontoEnvio,
                    TotalPedidoGuardado = f.TotalPedidoGuardado,
                    Id_Producto = f.Id_Producto,
                    NombreProducto = f.NombreProducto,
                    SubtotalItem = f.SubtotalItem,
                    TotalItems = f.TotalItems,
                    TotalCalculado = f.TotalCalculado
                };
            }

            var ws = new ReportesWS.WS_Ventas();
            var response = ws.ResumenMensualPorProducto(request); // devuelve array del proxy

            // mapear <- Entity
            var salida = new List<ReporteMensual>(response.Length);
            for (int i = 0; i < response.Length; i++)
            {
                var r = response[i];
                salida.Add(new ReporteMensual
                {
                    Id_Pedido = r.Id_Pedido,
                    FechaPedido = r.FechaPedido,
                    MontoEnvio = r.MontoEnvio,
                    TotalPedidoGuardado = r.TotalPedidoGuardado,
                    Id_Producto = r.Id_Producto,
                    NombreProducto = r.NombreProducto,
                    SubtotalItem = r.SubtotalItem,
                    TotalItems = r.TotalItems,
                    TotalCalculado = r.TotalCalculado
                });
            }

            return salida;
        }


    }
}
