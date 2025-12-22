using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Mappers
{
    public class ProductoDAL
    {
        DataAccess DataAccess = new DataAccess();
        
        /// <summary>
        /// Obtiene todos los productos activos disponibles en el sistema
        /// </summary>
        public List<Producto> ObtenerProductosActivos()
        {
            DataTable dt = DataAccess.Leer("SP_ObtenerProductos");
            List<Producto> productos = new List<Producto>();

            foreach (DataRow dr in dt.Rows)
            {
                Producto p = new Producto();

                p.Id = Convert.ToInt32(dr["Id"]);
                p.Nombre = dr["Nombre"].ToString();
                p.Descripcion = dr["Descripcion"].ToString();
                p.Precio = Convert.ToDecimal(dr["Precio"]);
                p.Stock = Convert.ToInt32(dr["Stock"]);
                p.UrlImagen = dr["ImagenUrl"].ToString();
                p.Categoria = dr["Categoria"].ToString();
                p.Estado = Convert.ToInt32(dr["Activo"]);
                p.FechaAlta = Convert.ToDateTime(dr["FechaAlta"]);
                p.FechaModificacion = dr["FechaModificacion"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(dr["FechaModificacion"]) : null;

                productos.Add(p);
            }

            return productos;
        }

        /// <summary>
        /// Elimina todos los productos de la base de datos
        /// </summary>
        public void EliminarTodos()
        {
            DataAccess.Escribir("SP_EliminarTodosLosProductos", null);
        }

        /// <summary>
        /// Inserta un nuevo producto en la base de datos
        /// </summary>
        public void InsertarProducto(Producto producto)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Nombre", producto.Nombre),
                new SqlParameter("@Descripcion", producto.Descripcion),
                new SqlParameter("@Precio", producto.Precio),
                new SqlParameter("@Stock", producto.Stock),
                new SqlParameter("@UrlImagen", producto.UrlImagen),
                new SqlParameter("@Categoria", producto.Categoria),
                new SqlParameter("@Estado", producto.Estado),
                new SqlParameter("@FechaAlta", producto.FechaAlta)
            };
            DataAccess.Escribir("SP_InsertarProducto", parameters);
        }

        /// <summary>
        /// Inserta un producto especificando manualmente su ID
        /// </summary>
        public void InsertarProductoConId(Producto producto)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", producto.Id),
                new SqlParameter("@Nombre", producto.Nombre),
                new SqlParameter("@Descripcion", producto.Descripcion),
                new SqlParameter("@Precio", producto.Precio),
                new SqlParameter("@Stock", producto.Stock),
                new SqlParameter("@UrlImagen", producto.UrlImagen),
                new SqlParameter("@Categoria", producto.Categoria),
                new SqlParameter("@Estado", producto.Estado),
                new SqlParameter("@FechaAlta", producto.FechaAlta)
            };
            DataAccess.Escribir("SP_InsertarProductoConID", parameters);
        }

        /// <summary>
        /// Actualiza los datos de un producto existente en la base de datos
        /// </summary>
        public void ActualizarProducto(Producto producto)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", producto.Id),
                new SqlParameter("@Nombre", producto.Nombre),
                new SqlParameter("@Descripcion", producto.Descripcion),
                new SqlParameter("@Precio", producto.Precio),
                new SqlParameter("@Stock", producto.Stock),
                new SqlParameter("@ImagenUrl", producto.UrlImagen),
                new SqlParameter("@Categoria", producto.Categoria),
                new SqlParameter("@Activo", producto.Estado),
                new SqlParameter("@FechaAlta", producto.FechaAlta)
            };
            DataAccess.Escribir("SP_ActualizarProducto", parameters);
        }

        /// <summary>
        /// Simula la corrupción de datos de productos para pruebas de recuperación
        /// </summary>
        public void Corromper()
        {
            DataAccess.Escribir("SP_CorromperProductos", null);

        }
    }
}
