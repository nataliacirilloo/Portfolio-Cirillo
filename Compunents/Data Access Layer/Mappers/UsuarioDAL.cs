using Entity_Layer;
using Services_Layer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public class UsuarioDAL
    {
        private readonly DataAccess data = new DataAccess();

        /// <summary>
        /// Crea un nuevo usuario en la base de datos
        /// </summary>
        public bool CrearUser(Usuario user)
        {
            SqlParameter[] parametros = new SqlParameter[] {
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

        /// <summary>
        /// Obtiene todos los perfiles de usuario disponibles
        /// </summary>
        public DataTable ObtenerPerfiles()
        {
            return data.Leer("SP_ObtenerPerfiles");
        }

        /// <summary>
        /// Autentica un usuario verificando su contraseña encriptada
        /// </summary>
        public bool AutenticarUsuario(string username, string contraseña)
        {
            SqlParameter[] parametros = new SqlParameter[] {
                new SqlParameter("@UserName", username),
            };
            DataTable dt = new DataTable();
            dt = data.Leer("SP_TraerUsuario", parametros);
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            string hashedPassword = dt.Rows[0]["Clave"].ToString();
            // Verificar la contraseña encriptada
            return Encriptaciones.VerifyPassword(contraseña, hashedPassword);
        }

        /// <summary>
        /// Obtiene los datos completos de un usuario por su nombre de usuario
        /// </summary>
        public DataTable TraerUsuarios(string user)
        {
            SqlParameter[] par = new SqlParameter[]{
                new SqlParameter("@UserName",user) };

            return data.Leer("SP_TraerUsuario", par);
        }

        /// <summary>
        /// Obtiene el rol de un usuario específico por su ID
        /// </summary>
        public string ObtenerRolUsuario(int idUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[]{
            new SqlParameter("@IdUsuario", idUsuario)};
            DataTable dt = data.Leer("SP_ObtenerRolPorUsuario", parametros);

            if (dt.Rows.Count > 0){
                return dt.Rows[0]["Rol"].ToString();
            }
            return "Desconocido";
        }

        /// <summary>
        /// Verifica si un usuario existe por su DNI
        /// </summary>
        public bool VerificarUsuarioExiste(int dni)
        {
            SqlParameter[] par = new SqlParameter[] {
                new SqlParameter("@Dni", dni)
            };
            var res = data.Verificar("SP_VerificarUsuarioNuevo", par);
            return res;
        }

        /// <summary>
        /// Obtiene los datos de un usuario registrado por nombre de usuario
        /// </summary>
        public DataTable TraerUsuarioRegistrado(string username)
        {
            SqlParameter[] par = new SqlParameter[]{
                new SqlParameter("@UserName", username)
            };
            return data.Leer("SP_TraerUsuario", par);
        }

        /// <summary>
        /// Registra un intento de login fallido para un usuario
        /// </summary>
        public void RegistrarIntentoFallido(int idUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[] {
                new SqlParameter("@IdUsuario", idUsuario)
            };
            data.Escribir("SP_RegistrarIntentoFallido", parametros);
        }

        /// <summary>
        /// Resetea el contador de intentos fallidos de un usuario
        /// </summary>
        public void ResetearIntentos(int idUsuario)
        {
            SqlParameter[] parametros = new SqlParameter[] {
                new SqlParameter("@IdUsuario", idUsuario)
            };
            data.Escribir("SP_ResetearIntentos", parametros);
        }

        /// <summary>
        /// Verifica si un usuario existe por su email
        /// </summary>
        public bool VerificarUsuarioExiste(string email)
        {
            SqlParameter[] parametros = new SqlParameter[] {
                new SqlParameter("@Email", email)
            };
            var res = data.Verificar("SP_VerificarUsuarioPorEmail", parametros);
            return res;
        }

        /// <summary>
        /// Guarda un token de recuperación de contraseña con fecha de expiración
        /// </summary>
        public void GuardarTokenRecuperacion(string email, string token, DateTime fechaExpiraUtc)
        {
            SqlParameter[] parametros = new SqlParameter[] {
                new SqlParameter("@Email", email),
                new SqlParameter("@Token", token),
                new SqlParameter("@ExpiraUtc", fechaExpiraUtc)
            };
            data.Escribir("SP_PasswordReset_Guardar", parametros);
        }

        /// <summary>
        /// Verifica si un token de recuperación es válido para un email específico
        /// </summary>
        public bool VerificarToken(string token, string email)
        {
            SqlParameter[] parametros = new SqlParameter[] {
                new SqlParameter("@Token", token),
                new SqlParameter("@Email", email)
            };
            return data.Verificar("SP_VerificarToken", parametros);
        }

        /// <summary>
        /// Restablece la contraseña de un usuario por su email
        /// </summary>
        public bool RestablecerContraseña(string email, string nuevaContraseña)
        {
            SqlParameter[] parametros = new SqlParameter[] {
                new SqlParameter("@Email", email),
                new SqlParameter("@NuevaContraseña", nuevaContraseña)
            };
            return data.Verificar("SP_RestablecerContraseña", parametros);
        }

    }
}
