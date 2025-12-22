using System;

/// <summary>
/// Representa un pago realizado por un pedido con información de método y estado
/// </summary>
public class Pago
{
    private int idPago;
    private int idPedido;
    private string metodoPago;
    private DateTime fechaPago;
    private decimal monto;
    private string estadoPago;
    private DateTime fechaModificacion;

    public int IdPago { get => idPago; set => idPago = value; }
    public int IdPedido { get => idPedido; set => idPedido = value; }
    public string MetodoPago { get => metodoPago; set => metodoPago = value; }
    public DateTime FechaPago { get => fechaPago; set => fechaPago = value; }
    public decimal Monto { get => monto; set => monto = value; }
    public string EstadoPago { get => estadoPago; set => estadoPago = value; }
    public DateTime FechaModificacion { get => fechaModificacion; set => fechaModificacion = value; }
}
