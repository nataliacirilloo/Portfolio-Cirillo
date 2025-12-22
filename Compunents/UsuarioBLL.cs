using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Layer;
using Services_Layer;
using System.CodeDom;
using System.Security.Permissions;
using System.Data;
using System.Data.SqlClient;
using Data_Access_Layer.Mappers;

namespace Business_Logical_Layer
{
    public class UsuarioBLL
    {

        UsuarioDAL usuarioDal = new UsuarioDAL();

        /// <summary>
        /// Crea un nuevo usuario en el sistema con validaciones y encriptación de contraseña
        /// </summary>
        public bool CrearUsuario(Usuario user)
        {
            try
            {
                var verificacion = usuarioDal.VerificarUsuarioExiste(user.Dni);
                if (verificacion)
                {
                    string encriptacion = Encriptaciones.EncriptarContraseña(user.UserName, user.Contraseña);
                    user.Contraseña = encriptacion;

                    usuarioDal.CrearUser(user);

                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el usuario: " + ex.Message);

            }
        }

        /// <summary>
        /// Obtiene todos los usuarios del sistema en formato DataTable
        /// </summary>
        public DataTable GetUsuarios()
        {
            return usuarioDal.GetUsuarios();
        }
        
        /// <summary>
        /// Autentica un usuario verificando sus credenciales encriptadas
        /// </summary>
        public bool AutenticarUser(string username, string contraseña)
        {
            try
            {


                var contra = Encriptaciones.EncriptarContraseña(username, contraseña);

                var aut = usuarioDal.AutenticarUsuario(username, contra);

                if(aut.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Obtiene todos los perfiles disponibles en el sistema
        /// </summary>
        public DataTable ObtenerPerfiles()
        {
            try
            {
                return usuarioDal.ObtenerPerfiles();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los perfiles: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene los datos completos de un usuario específico por su nombre de usuario
        /// </summary>
        public Usuario TraerUser(string user)
        {
            try
            {
                var userData = usuarioDal.TraerUsuarios(user);

                if (userData.Rows.Count > 0)
                {
                    
                    DataRow row = userData.Rows[0];

                    Usuario us = new Usuario
                    {
                        Nombre = row["Nombre"].ToString(),
                        Apellido = row["Apellido"].ToString(),
                        Dni = Convert.ToInt32(row["Dni"]),
                        Mail = row["Mail"].ToString(),
                        UserName = row["UserName"].ToString(),
                        Id_Perfil = Convert.ToInt32(row["Id_Perfil"]),
                        Nombre_Perfil = row["Nombre_Perfil"].ToString(),
                        Id_Usuario = Convert.ToInt32(row["Id_Usuario"]),
                        IntentosFallidos = Convert.ToInt32(row["IntentosFallidos"]),
                        Bloqueado = Convert.ToBoolean(row["Bloqueado"])

                    };

                    return us;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Registra un intento de login fallido para un usuario
        /// </summary>
        public void RegistrarIntentoFallido(int idUsuario)
        {
            try
            {
                usuarioDal.RegistrarIntentoFallido(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar el intento fallido: " + ex.Message);
            }
        }

        /// <summary>
        /// Resetea el contador de intentos fallidos de un usuario
        /// </summary>
        public void ResetearIntentos(int idUsuario)
        {
            try
            {
                usuarioDal.ResetearIntentos(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al resetear los intentos: " + ex.Message);
            }

        }


    }
}
