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
    public class MPProveedor
    {
        Acceso acceso = new Acceso();

        public List<Proveedor> ListarProveedor()
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            DataTable dt = new DataTable();
            dt = acceso.Leer("ListarProveedores", null);
            foreach (DataRow dr in dt.Rows)
            {
                Proveedor proveedor = new Proveedor();
                proveedor.IdProveedor = Convert.ToInt32(dr["idProveedor"]);
                proveedor.Nombre = dr["nombre"].ToString();
                proveedor.NroDocumento = dr["nroDocumento"].ToString();
                proveedor.RazonSocial = dr["razonSocial"].ToString();
                proveedor.Correo = dr["correo"].ToString();
                proveedor.Telefono = dr["telefono"].ToString();
                proveedor.Estado = dr["estado"].ToString();
                proveedores.Add(proveedor);

            }
            return proveedores;
        }

        public int AltaProveedor(Proveedor proveedor)
        {
            int fa = 0;

            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@idProveedor", proveedor.IdProveedor),
                new SqlParameter("@nombre", proveedor.Nombre),
                new SqlParameter("@nroDocumento", proveedor.NroDocumento),
                new SqlParameter("@razonSocial", proveedor.RazonSocial),
                new SqlParameter("@correo", proveedor.Correo),
                new SqlParameter("@telefono", proveedor.Telefono),
                new SqlParameter("@estado", proveedor.Estado),
            };
            fa = acceso.Escribir("AgregarProveedor", sp);
            return fa;
        }

        public int ModificarProveedor(Proveedor proveedor)
        {
            int fa = 0;

            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@idProveedor", proveedor.IdProveedor),
                new SqlParameter("@nombre", proveedor.Nombre),
                new SqlParameter("@nroDocumento", proveedor.NroDocumento),
                new SqlParameter("@razonSocial", proveedor.RazonSocial),
                new SqlParameter("@correo", proveedor.Correo),
                new SqlParameter("@telefono", proveedor.Telefono),
                new SqlParameter("@estado", proveedor.Estado),
            };
            fa = acceso.Escribir("ModificarProveedor", sp);
            return fa;
        }

        public int EliminarProveedor(Proveedor Proveedor)
        {
            int fa = 0;

            SqlParameter[] parameters = new SqlParameter[1]
            {
                new SqlParameter("idProveedor",Proveedor.IdProveedor)
            };
            fa = acceso.Escribir("BorrarProveedor", parameters);
            return fa;
        }
    }
}
