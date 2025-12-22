using Business_Logical_Layer;
using Data_Access_Layer.Mappers;
using Entity_Layer;
using System;
using System.Linq;

public class CarritoBLL
{

    private CarritoDAL carritoDAL = new CarritoDAL();
    private ProductoBLL productoBLL = new ProductoBLL();

    /// <summary>
    /// Obtiene el carrito activo del usuario, creándolo si no existe
    /// </summary>
    public Carrito ObtenerCarritoActivo(int idUsuario)
    {
        int idCarrito = carritoDAL.ObtenerOCrearCarritoId(idUsuario);

        Carrito carrito = new Carrito
        {
            IdCarrito = idCarrito,
            IdUsuario = idUsuario,
            Items = carritoDAL.ObtenerItemsPorCarrito(idCarrito)
        };

        return carrito;
    }

    /// <summary>
    /// Agrega un producto al carrito o actualiza su cantidad si ya existe
    /// </summary>
    public void AgregarProducto(int idUsuario, int idProducto, int cantidad)
    {
        if (idUsuario <= 0 || idProducto <= 0 || cantidad <= 0)
        {
            return;
        }

        carritoDAL.AgregarOActualizarItem(idUsuario, idProducto, cantidad);
    }

    /// <summary>
    /// Elimina un producto específico del carrito del usuario
    /// </summary>
    public void EliminarProducto(int idUsuario, int idProducto)
    {
        Carrito carritoActual = ObtenerCarritoActivo(idUsuario);
        CarritoItem itemExistente = carritoActual.Items.FirstOrDefault(item => item.IdProducto == idProducto);
        if (itemExistente != null)
        {
            carritoDAL.EliminarItem(itemExistente.IdItem);
        }
    }

    /// <summary>
    /// Vacía completamente el carrito del usuario
    /// </summary>
    public void VaciarCarrito(int idUsuario)
    {
        Carrito carritoActual = ObtenerCarritoActivo(idUsuario);
        if (carritoActual != null)
        {
            carritoDAL.VaciarCarrito(carritoActual.IdCarrito);
        }
    }

    /// <summary>
    /// Calcula el subtotal del carrito sin impuestos
    /// </summary>
    public decimal ObtenerSubtotal(int idUsuario)
    {
        Carrito carritoActual = ObtenerCarritoActivo(idUsuario);
        return carritoActual.Subtotal;
    }

    /// <summary>
    /// Calcula el total final del carrito incluyendo impuestos
    /// </summary>
    public decimal ObtenerTotal(int idUsuario)
    {
        Carrito carritoActual = ObtenerCarritoActivo(idUsuario);
        return carritoActual.Total;
    }

    /// <summary>
    /// Actualiza la cantidad de un producto específico en el carrito
    /// </summary>
    public void ActualizarCantidadItem(int idUsuario, int idProducto, int nuevaCantidad)
    {
        Carrito carritoActual = ObtenerCarritoActivo(idUsuario);
        CarritoItem itemExistente = carritoActual?.Items.FirstOrDefault(item => item.IdProducto == idProducto);

        if (itemExistente != null)
        {
            carritoDAL.ActualizarCantidadItem(itemExistente.IdItem, nuevaCantidad, itemExistente.PrecioUnitario);
        }
    }

}