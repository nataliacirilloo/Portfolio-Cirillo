using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;

namespace GUI_Layer
{

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Ventas : System.Web.Services.WebService
    {

        public WS_Ventas()
        {

        }

        private class Acum // solo uso interno del método
        {
            public string Nombre = "";
            public HashSet<int> Pedidos = new HashSet<int>();
            public int Unidades = 0;
            public decimal Recaudacion = 0m;
        }


        [WebMethod]
        public Producto ObtenerProductoMasVendido()
        {
            DataAccess dataAccess = new DataAccess();

            // Llamar al Stored Procedure
            DataTable resultado = dataAccess.Leer("ObtenerProductoMasVendido");

            if (resultado.Rows.Count > 0)
            {
                DataRow row = resultado.Rows[0];
                return new Producto
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Nombre = row["Nombre"].ToString(),
                    Descripcion = row["Descripcion"].ToString(),
                    Precio = Convert.ToDecimal(row["Precio"]),
                    Stock = Convert.ToInt32(row["Stock"]),
                    UrlImagen = row["ImagenUrl"].ToString()
                };
            }

            return null;
        }


        /// <summary>
        /// Recibe filas del SP (últimos 30 días) y devuelve un resumen por producto.
        /// Mapea la salida en la MISMA clase ReporteMensual:
        ///   - Id_Pedido = # pedidos distintos
        ///   - TotalItems = unidades vendidas
        ///   - SubtotalItem = recaudación del producto
        ///   - TotalCalculado = % del mes (0–100)
        /// </summary>
        [WebMethod(Description = "Resumen mensual por producto (pedidos, unidades, recaudación y % del mes).")]
        public List<ReporteMensual> ResumenMensualPorProducto(List<ReporteMensual> filas)
        {
            var salida = new List<ReporteMensual>();
            if (filas == null || filas.Count == 0) return salida;

            // Acumuladores por producto (sin crear nuevas clases)
            var nombres = new Dictionary<int, string>();
            var pedidosPorProd = new Dictionary<int, HashSet<int>>();
            var unidadesPorProd = new Dictionary<int, int>();
            var recaudacionPorProd = new Dictionary<int, decimal>();

            decimal totalMes = 0m;

            // 1) Pasada de acumulación
            for (int i = 0; i < filas.Count; i++)
            {
                var f = filas[i];

                // Total del mes: suma de subtotales de todos los ítems
                totalMes += f.SubtotalItem;

                // Nombre
                if (!nombres.ContainsKey(f.Id_Producto))
                    nombres.Add(f.Id_Producto, f.NombreProducto);

                // Pedidos distintos
                if (!pedidosPorProd.ContainsKey(f.Id_Producto))
                    pedidosPorProd.Add(f.Id_Producto, new HashSet<int>());
                pedidosPorProd[f.Id_Producto].Add(f.Id_Pedido);

                // Unidades
                if (!unidadesPorProd.ContainsKey(f.Id_Producto))
                    unidadesPorProd.Add(f.Id_Producto, 0);
                unidadesPorProd[f.Id_Producto] = unidadesPorProd[f.Id_Producto] + f.TotalItems;

                // Recaudación
                if (!recaudacionPorProd.ContainsKey(f.Id_Producto))
                    recaudacionPorProd.Add(f.Id_Producto, 0m);
                recaudacionPorProd[f.Id_Producto] = recaudacionPorProd[f.Id_Producto] + f.SubtotalItem;
            }

            // 2) Armar salida y calcular porcentaje
            foreach (var kvp in recaudacionPorProd)
            {
                int idProd = kvp.Key;
                string nombre = nombres.ContainsKey(idProd) ? nombres[idProd] : string.Empty;
                int pedidos = pedidosPorProd.ContainsKey(idProd) ? pedidosPorProd[idProd].Count : 0;
                int unidades = unidadesPorProd.ContainsKey(idProd) ? unidadesPorProd[idProd] : 0;
                decimal recaudacion = kvp.Value;

                decimal porcentaje = 0m;
                if (totalMes > 0m)
                {
                    porcentaje = Math.Round((recaudacion / totalMes) * 100m, 2, MidpointRounding.AwayFromZero);
                }

                salida.Add(new ReporteMensual
                {
                    // Clave
                    Id_Producto = idProd,
                    NombreProducto = nombre,

                    // Mapeo del resumen en la misma clase
                    Id_Pedido = pedidos,                 // # de pedidos distintos
                    TotalItems = unidades,               // unidades vendidas
                    SubtotalItem = Math.Round(recaudacion, 2, MidpointRounding.AwayFromZero), // recaudación
                    TotalCalculado = porcentaje,         // % del mes

                    // No aplican en el resumen
                    MontoEnvio = 0m,
                    TotalPedidoGuardado = 0m,
                    FechaPedido = DateTime.MinValue
                });
            }

            // Ordenar por mayor recaudación (sin LINQ)
            salida.Sort((a, b) => b.SubtotalItem.CompareTo(a.SubtotalItem));
            return salida;
        }

    }
}
