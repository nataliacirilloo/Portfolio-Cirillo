using System;


    /// <summary>
    /// Fila de reporte mensual tal como la devuelve el SP (últimos 30 días).
    /// Usada también como DTO de salida del resumen.
    /// </summary>
    public class ReporteMensual
    {
        private int id_Pedido;
        private DateTime fechaPedido;
        private decimal montoEnvio;
        private decimal totalPedidoGuardado;
        private int id_Producto;
        private string nombreProducto = string.Empty;
        private decimal subtotalItem;
        private int totalItems;
        private decimal totalCalculado;

        public int Id_Pedido
        {
            get { return id_Pedido; }
            set { id_Pedido = value; }
        }

        public DateTime FechaPedido
        {
            get { return fechaPedido; }
            set { fechaPedido = value; }
        }

        public decimal MontoEnvio
        {
            get { return montoEnvio; }
            set { montoEnvio = value; }
        }

        public decimal TotalPedidoGuardado
        {
            get { return totalPedidoGuardado; }
            set { totalPedidoGuardado = value; }
        }

        public int Id_Producto
        {
            get { return id_Producto; }
            set { id_Producto = value; }
        }

        public string NombreProducto
        {
            get { return nombreProducto; }
            set { nombreProducto = value ?? string.Empty; }
        }

        public decimal SubtotalItem
        {
            get { return subtotalItem; }
            set { subtotalItem = value; }
        }

        public int TotalItems
        {
            get { return totalItems; }
            set { totalItems = value; }
        }

        public decimal TotalCalculado
        {
            get { return totalCalculado; }
            set { totalCalculado = value; }
        }
    }

