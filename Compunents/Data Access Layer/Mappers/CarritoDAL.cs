using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Layer;

namespace Data_Access_Layer.Mappers
{
    public class CarritoDAL
    {
        private DataAccess dataAccess = new DataAccess();

        /// <summary>
        /// Obtiene el ID del carrito activo de un usuario o crea uno nuevo si no existe
        /// </summary>
        public int ObtenerOCrearCarritoId(int idUsuario)
        {

            SqlParameter[] parametros =  new SqlParameter[] 
            { 
                new SqlParameter("@Id_Usuario", idUsuario) 
            };
            DataTable dtCarrito = dataAccess.Leer("SP_ObtenerUltimoCarrito", parametros);

            if (dtCarrito.Rows.Count > 0)
            {
                return Convert.ToInt32(dtCarrito.Rows[0]["Id_Carrito"]);
            }
            else
            {
                SqlParameter[] parametrosCrear = new SqlParameter[]
                { 
                    new SqlParameter("@IdUsuario", idUsuario) 
                };
                DataTable dtNuevo = dataAccess.Leer("SP_CrearCarrito", parametrosCrear);
                return Convert.ToInt32(dtNuevo.Rows[0]["IdCarrito"]);
            }
        }

        /// <summary>
        /// Obtiene todos los items (productos) de un carrito específico
        /// </summary>
        public List<CarritoItem> ObtenerItemsPorCarrito(int idCarrito)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdCarrito", idCarrito)
            };
            DataTable dtItems = dataAccess.Leer("SP_ObtenerItemsPorCarrito", parametros);

            List<CarritoItem> listaItems = new List<CarritoItem>();

            foreach (DataRow dr in dtItems.Rows)
            {
                listaItems.Add(new CarritoItem
                {
                    // Este código ahora funcionará porque la consulta ya no fallará
                    IdItem = Convert.ToInt32(dr["Id_Item"]),
                    IdCarrito = Convert.ToInt32(dr["Id_Carrito"]),
                    IdProducto = Convert.ToInt32(dr["Id_Producto"]),
                    Cantidad = Convert.ToInt32(dr["Cantidad"]),
                    PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"])
                });
            }
            return listaItems;
        }

        /// <summary>
        /// Agrega un producto al carrito o actualiza su cantidad si ya existe
        /// </summary>
        public void AgregarOActualizarItem(int idUsuario, int idProducto, int cantidad)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", idUsuario),
                new SqlParameter("@IdProducto", idProducto),
                new SqlParameter("@Cantidad", cantidad)
            };
            dataAccess.Escribir("SP_AgregarAlCarrito", parametros);
        }

        /// <summary>
        /// Elimina un item específico del carrito
        /// </summary>
        public void EliminarItem(int idItem)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdItem", idItem)
            };
            
            dataAccess.Escribir("SP_EliminarItemDelCarrito", parametros);
        }

        /// <summary>
        /// Vacía completamente un carrito eliminando todos sus items
        /// </summary>
        public void VaciarCarrito(int idCarrito)
        {
            SqlParameter[] parametros = new SqlParameter[] 
            { 
                new SqlParameter("@IdCarrito", idCarrito) 
            };

            dataAccess.Escribir("SP_VaciarCarrito", parametros);
        }

        /// <summary>
        /// Actualiza la cantidad de un item específico en el carrito
        /// </summary>
        public void ActualizarCantidadItem(int idItem, int nuevaCantidad, decimal precioUnitario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdItem", idItem),
                new SqlParameter("@NuevaCantidad", nuevaCantidad),
                new SqlParameter("@PrecioUnitario", precioUnitario)
            };

            dataAccess.Escribir("SP_ActualizarCantidadItem", parametros);
        }

    }
}
