using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Mappers;

namespace Business_Logical_Layer
{
    public class ProductoBLL
    {

        ProductoDAL productoDAL = new ProductoDAL();

        /// <summary>
        /// Obtiene todos los productos que están activos en el sistema
        /// </summary>
        public List<Producto> ObtenerProductosActivos()
        {
            return productoDAL.ObtenerProductosActivos();
        }

        /// <summary>
        /// Obtiene un producto específico por su ID
        /// </summary>
        public Producto ObtenerProductoPorId(int id)
        {
            return productoDAL.ObtenerProductosActivos().FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Elimina todos los productos del sistema
        /// </summary>
        public void EliminarTodos()
        {
            productoDAL.EliminarTodos();
        }

        /// <summary>
        /// Actualiza los datos de un producto existente con validaciones
        /// </summary>
        public void ActualizarProducto(Producto producto)
        {
            if (producto == null)
            {
                throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo.");
            }
            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                throw new ArgumentException("El nombre del producto no puede estar vacío.", nameof(producto.Nombre));
            }
            if (producto.Precio < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(producto.Precio), "El precio del producto no puede ser negativo.");
            }
            if (producto.Stock < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(producto.Stock), "El stock del producto no puede ser negativo.");
            }
            productoDAL.ActualizarProducto(producto);
        }

        /// <summary>
        /// Inserta un nuevo producto en el sistema con validaciones
        /// </summary>
        public void InsertarProducto(Producto producto)
        {
            if (producto == null)
            {
                throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo.");
            }
            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                throw new ArgumentException("El nombre del producto no puede estar vacío.", nameof(producto.Nombre));
            }
            if (producto.Precio < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(producto.Precio), "El precio del producto no puede ser negativo.");
            }
            if (producto.Stock < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(producto.Stock), "El stock del producto no puede ser negativo.");
            }
            productoDAL.InsertarProductoConId(producto);
        }

        /// <summary>
        /// Simula una corrupción de datos para pruebas de recuperación
        /// </summary>
        public void Corromper()
        {
            productoDAL.Corromper();
        }
    }
}
