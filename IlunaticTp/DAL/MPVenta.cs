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
    public class MPVenta
    {
        Acceso acceso = new Acceso();

        public List<Venta> ListarVenta()
        {
            List<Venta> ventas = new List<Venta>();
            DataTable dt = new DataTable();
            dt = acceso.Leer("ListarVentas", null);
            foreach (DataRow dr in dt.Rows)
            {
                Venta venta = new Venta();
                venta.IdVenta = Convert.ToInt32(dr["idVenta"]);
                venta.NroDocumento = dr["nroDocumento"].ToString();
                venta.TipoPago = dr["tipoPago"].ToString();
                venta.Total= Convert.ToSingle(dr["total"]);
                venta.FechaRegistro= dr["fechaRegistro"].ToString();
                ventas.Add(venta);

            }
            return ventas;
        }

        public int AltaVenta(Venta venta)
        {
            int fa = 0;

            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@idVenta", venta.IdVenta),
                new SqlParameter("@nroDocumento", venta.NroDocumento),
                new SqlParameter("@tipoPago", venta.TipoPago),
                new SqlParameter("@total", venta.Total),
                new SqlParameter("@fechaRegistro", venta.FechaRegistro)
            };
            fa = acceso.Escribir("AltaVentas", sp);
            return fa;
        }
    }
}
