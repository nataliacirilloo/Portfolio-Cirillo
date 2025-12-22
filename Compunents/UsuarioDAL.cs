using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class UsuarioDAL
    {
        private readonly DataAccess data = new DataAccess();

        public bool CrearUser(Usuario user)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Nombre", user.Nombre),
                new SqlParameter("@Apellido", user.Apellido),
                new SqlParameter("@Dni", user.Dni),
                new SqlParameter("@Mail", user.Mail),
                new SqlParameter("@UserName", user.UserName),
                new SqlParameter("@Clave", user.Contraseña),
                new SqlParameter("@Id_Perfil", user.Id_Perfil)
            };

            int resultado = data.Escribir("SP_CrearUsuario", parametros);
            return resultado > 0;
        }

        public DataTable ObtenerPerfiles()
        {
            return data.Leer("SP_ObtenerPerfiles");
        }

        public DataTable AutenticarUsuario(string username, string contraseña)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@UserName", username),
                new SqlParameter("@Clave", contraseña)
            };
            return data.Leer("SP_AutenticarUser", par);

        }

        public DataTable GetUsuarios()
        {
            return data.Leer("GetUsuarios");
        }
        public DataTable TraerUsuarios(string user)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@UserName",user)
            };

            return data.Leer("SP_TraerUsuario", par);
        }

        public string ObtenerRolUsuario(int idUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
        new SqlParameter("@IdUsuario", idUsuario)
            };

            DataTable dt = data.Leer("SP_ObtenerRolPorUsuario", parametros);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Rol"].ToString();
            }

            return "Desconocido";
        }

        public bool VerificarUsuarioExiste(int dni)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@Dni", dni)
            };
            var res = data.Verificar("SP_VerificarUsuarioNuevo", par);

            return res;
        }

        public DataTable TraerUsuarioRegistrado(string username)
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@UserName", username)
            };
            return data.Leer("SP_TraerUsuario", par);
        }

        public void RegistrarIntentoFallido(int idUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", idUsuario)
            };
            data.Escribir("SP_RegistrarIntentoFallido", parametros);
        }

        public void ResetearIntentos(int idUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", idUsuario)
            };
            data.Escribir("SP_ResetearIntentos", parametros);
        }

    }
}
