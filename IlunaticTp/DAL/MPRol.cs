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
    public class MPRol
    {
        Acceso acceso = new Acceso();
        public List<Rol> ListarRol()
        {
    
            List<Rol> roles = new List<Rol>();
            DataTable dt = new DataTable();
            dt = acceso.Leer("ListarRoles", null);
            foreach (DataRow dr in dt.Rows)
            {
                Rol rol = new Rol();
                rol.IdRol = Convert.ToInt32(dr["idRol"]);
                rol.Descripcion = dr["descripcion"].ToString();
                rol.EsActivo = dr["esActivo"].ToString();
                roles.Add(rol);

            }


            return roles;
        }
    }
}
