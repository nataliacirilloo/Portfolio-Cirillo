using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MPProducto
    {

        Acceso acceso = new Acceso();

        public List<Productos> ListarProducto()
        {
            List<Productos> Productos = new List<Productos>();
            DataTable dt = new DataTable();
            dt = acceso.Leer("ListarProductos", null);
            foreach (DataRow dr in dt.Rows)
            {
                Productos Producto = new Productos();
                Producto.IdProducto = Convert.ToInt32(dr["idProducto"]);
                Producto.Nombre= dr["nombre"].ToString();
                Producto.IdCategoria = Convert.ToInt32(dr["idCategoria"]);
                Producto.Stock = Convert.ToInt32(dr["stock"]);
                Producto.EsActivo = dr["esActivo"].ToString();
                //Producto.FechaRegistro= dr["fechaRegistro"].ToString();
                Productos.Add(Producto);

            }
            return Productos;
        }

        public int AltaProducto(Productos producto)
        {
            int fa = 0;

            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@idProducto", producto.IdProducto),
                new SqlParameter("@nombre", producto.Nombre),
                new SqlParameter("@idCategoria", producto.IdCategoria),
                new SqlParameter("@stock", producto.Stock),
                new SqlParameter("@esActivo", producto.EsActivo)
            };
            fa = acceso.Escribir("AddProducto", sp);
            return fa;
        }

        public int ModificarProducto(Productos producto)
        {
            int fa = 0;

            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@idProducto", producto.IdProducto),
                new SqlParameter("@nombre", producto.Nombre),
                new SqlParameter("@idCategoria", producto.IdCategoria),
                new SqlParameter("@stock", producto.Stock),
                new SqlParameter("@esActivo", producto.EsActivo)
            };
            fa = acceso.Escribir("ModificarProducto", sp);
            return fa;
        }

        public int EliminarProducto(Productos producto)
        {
            int fa = 0;

            SqlParameter[] parameters = new SqlParameter[1]
            {
                new SqlParameter("idProducto",producto.IdProducto)
            };
            fa = acceso.Escribir("EliminarProducto", parameters);
            return fa;
        }
    }
}
