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
    public class MPUsuario
    {
        Acceso acceso = new Acceso();

        public List<Usuario> ListarUsuario()
        {
            List<Usuario> usuarios = new List<Usuario>();
            DataTable dt = new DataTable();
            dt = acceso.Leer("ListarUsuarios", null);
            foreach (DataRow dr in dt.Rows)
            {
                Usuario usuario = new Usuario();
                usuario.IdUsuario = Convert.ToInt32(dr["idUsuario"]);
                usuario.DNI = dr["dni"].ToString();
                usuario.NombreApellidos = dr["nombreApellidos"].ToString();
                usuario.Correo = dr["correo"].ToString();
                usuario.IdRol = Convert.ToInt32(dr["idRol"]);
                usuario.Clave = dr["clave"].ToString();
                usuario.EsActivo = dr["esActivo"].ToString();
                usuarios.Add(usuario);

            }


            return usuarios;
        }

        public int AltaUsuario(Usuario usuario)
        {
            int fa = 0;

            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@idUsuario", usuario.IdUsuario),
                new SqlParameter("@nombreApellidos", usuario.NombreApellidos),
                new SqlParameter("@dni", usuario.DNI),
                new SqlParameter("@correo", usuario.Correo),
                new SqlParameter("@idRol", usuario.IdRol),
                new SqlParameter("@clave", usuario.Clave),
                new SqlParameter("@esActivo", usuario.EsActivo)
            };
            fa = acceso.Escribir("AltaUsuario", sp);
            return fa;
        }

        public int ModificarUsuario(Usuario usuario) {
            int fa = 0;

            SqlParameter[] p = new SqlParameter[]
            {
             new SqlParameter("@idUsuario", usuario.IdUsuario),
                new SqlParameter("@dni", usuario.DNI),
                new SqlParameter("@nombreApellidos", usuario.NombreApellidos),
                new SqlParameter("@correo", usuario.Correo),
                new SqlParameter("@idRol", usuario.IdRol),
                new SqlParameter("@clave", usuario.Clave),
                new SqlParameter("@esActivo", usuario.EsActivo)
            };
            fa = acceso.Escribir("ModificarUsuario", p);
            return fa;
        }

        public int EliminarUsuario(Usuario usuario)
        {
            int fa = 0;

            SqlParameter[] parameters = new SqlParameter[1]
            {
                new SqlParameter("idUsuario",usuario.IdUsuario)
            };
            fa = acceso.Escribir("EliminarUsuario", parameters);
            return fa;
        }
    }
}
