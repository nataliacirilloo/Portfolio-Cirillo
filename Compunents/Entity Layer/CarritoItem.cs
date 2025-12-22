using System;

namespace Entity_Layer
{
    /// <summary>
    /// Representa un item individual dentro del carrito de compras
    /// </summary>
    public class CarritoItem
    {
        private int idItem;
        private int idCarrito;
        private int idProducto;
        private int cantidad;
        private decimal precioUnitario;

        public int IdItem { get => idItem; set => idItem = value; }
        public int IdCarrito { get => idCarrito; set => idCarrito = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
    }
}
