using System;
using System.Collections.Generic;
using System.Linq;
using Entity_Layer;

/// <summary>
/// Representa el carrito de compras de un usuario con sus items y cálculos automáticos
/// </summary>
public class Carrito
{
    public int IdCarrito { get; set; }
    public int IdUsuario { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
    public List<CarritoItem> Items { get; set; }

    public decimal Subtotal
    {
        get { return Items.Sum(item => item.Cantidad * item.PrecioUnitario); }
    }

    public decimal Total
    {
        get { return Subtotal; }
    }

    public Carrito()
    {
        Items = new List<CarritoItem>();
        FechaCreacion = DateTime.Now;
        FechaModificacion = DateTime.Now;
    }
}