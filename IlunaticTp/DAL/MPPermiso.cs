using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MPPermiso
    {
        Acceso acceso = new Acceso();
        //public List<Permiso> ListarPermiso(int idUsuario)
        //{
        //    List<Permiso> permisos = new List<Permiso>();
        //    DataTable dt = new DataTable();

        //    SqlParameter[] parametros = new SqlParameter[1];
        //    parametros[0] = new SqlParameter("@idUsuario", idUsuario); 

        //    try
        //    {
        //        dt = acceso.Leer("ListarPermiso", parametros); 
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error al leer permisos: " + ex.Message);
        //        return permisos; 
        //    }

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        Permiso permiso = new Permiso();
        //        permiso.IdRol = Convert.ToInt32(dr["idRol"]);
        //        permiso.NombreMenu = dr["nombreMenu"].ToString();
        //        permisos.Add(permiso);
        //    }

        //    return permisos;
        //}
    }
}
