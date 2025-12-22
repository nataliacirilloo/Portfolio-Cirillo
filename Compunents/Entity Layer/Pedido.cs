using System;

/// <summary>
/// Representa un pedido realizado por un usuario con toda su información de envío y pago
/// </summary>
public class Pedido
{
    public int IdPedido { get; set; }
    public int IdUsuario { get; set; }
    public DateTime FechaPedido { get; set; }
    public decimal Total { get; set; }
    public string Estado { get; set; }
    public decimal MontoEnvio { get; set; }
    public int Id_Localidad { get; set; } 
    public string Localidad { get; set; }
    public DateTime FechaAlta { get; set; }
    public DateTime? FechaModificacion { get; set; } 

    public string MetodoPago { get; set; } 
}
