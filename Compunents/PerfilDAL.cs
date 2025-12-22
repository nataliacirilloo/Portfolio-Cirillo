using Services_Layer;
using Services_Layer.Composite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Mappers
{
    /// <summary>
    /// Clase de acceso a datos para gestión de perfiles y sus relaciones con familias
    /// </summary>
    public class PerfilDAL
    {
        private readonly DataAccess dataAccess = new DataAccess();

        /// <summary>
        /// Agrega un nuevo perfil al sistema
        /// </summary>
        public int AgregarPerfil(Perfil perfil)
        {
            int res = 0;

            SqlParameter[] sql = new SqlParameter[]
            {
                new SqlParameter("@Nombre", perfil.Nombre),
            };
            res = dataAccess.Escribir("SP_AgregarPerfil", sql);

            return res;
        }

        /// <summary>
        /// Obtiene las familias asignadas a un perfil específico
        /// </summary>
        public DataTable ObtenerFamiliaPerfil(int idperfil)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Id_Perfil",idperfil)
            };

            return dataAccess.Leer("SP_ObtenerFamiliaAsignada", sp);
        }

        /// <summary>
        /// Obtiene el perfil asignado a un usuario específico
        /// </summary>
        public DataTable ObtenerPerfilUsuario(int idusuario)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Id_Usuario",idusuario)
            };

            return dataAccess.Leer("SP_ObtenerPerfilAsignado", sp);
        }

        /// <summary>
        /// Asigna una familia a un perfil específico
        /// </summary>
        public int AgregarFamiliaPerfil(int idfam, int idper)
        {
            int res = 0;

            SqlParameter[] sql = new SqlParameter[]
            {
                new SqlParameter("@Id_Familia", idfam),
                new SqlParameter("@Id_Perfil", idper),
            };

            res = dataAccess.Escribir("SP_AgregarFamiliaPerfil", sql);

            return res;
        }

        /// <summary>
        /// Obtiene todos los perfiles disponibles en el sistema
        /// </summary>
        public DataTable ObtenerPerfiles()
        {
            var dt = dataAccess.Leer("SP_ObtenerPerfiles");
            return dt;
        }

        /// <summary>
        /// Obtiene las familias asociadas a un perfil específico
        /// </summary>
        public DataTable ObtenerFamiliasPorPerfil(int perfilId)
        {
            SqlParameter[] sql = new SqlParameter[]
            {
                new SqlParameter("@Id_Perfil", perfilId)
            };
            var dt = dataAccess.Leer("SP_ObtenerFamiliasPorPerfil", sql);
            return dt;
        }

        /// <summary>
        /// Elimina la asignación de familia a un perfil
        /// </summary>
        public int EliminarFamiliaPerfil(Familia fam, Perfil per)
        {
            int res = 0;

            SqlParameter[] sql = new SqlParameter[]
            {
                new SqlParameter("@Id_Perfil", per.Id_Perfil),
            };

            res = dataAccess.Escribir("SP_EliminarFamiliaPerfil", sql);

            return res;
        }

        /// <summary>
        /// Busca un perfil por su nombre
        /// </summary>
        public DataTable ObtenerPerfilPorNombre(string nombre)
        {
            SqlParameter[] sql = new SqlParameter[]
          {
                new SqlParameter("@Nombre", nombre)
          };
            var dt = dataAccess.Leer("SP_ObtenerPerfilPorNombre", sql);
            return dt;
        }

        /// <summary>
        /// Obtiene un perfil específico por su ID
        /// </summary>
        public Perfil ObtenerPerfilPorId(int id)
        {
            SqlParameter[] sql = new SqlParameter[]
             {
                new SqlParameter("@Id_Perfil", id)
            };
            var dt = dataAccess.Leer("SP_ObtenerPerfilPorId", sql);

            return Conversor.DataTableToObject<Perfil>(dt);
        }

        /// <summary>
        /// Valida si una familia ya está asignada a un perfil
        /// </summary>
        public int ValidarPerfilFamilia(int idfam, int idper)
        {
            SqlParameter[] sql = new SqlParameter[]
            {
                new SqlParameter("@Id_Familia", idfam),
                new SqlParameter("@Id_Perfil", idper),
            };

            var res = dataAccess.Verificar("SP_ValidarPerfilFamilia", sql);

            if (res == true)
            {
                return -1; // Familia ya asignada al perfil
            }
            else
            {
                return 0; // Familia no asignada al perfil
            }
        }
        
        /// <summary>
        /// Asigna un perfil específico a un usuario
        /// </summary>
        public int AsignarPerfilUsuario(int idusuario,int idpefil)
        {
            SqlParameter[] sql = new SqlParameter[]
            {
                new SqlParameter("@Id_Usuario",idusuario),
                new SqlParameter("@Id_Perfil",idpefil)
            };

            var res = dataAccess.Escribir("AsignarPerfilUsuario", sql);

            return res;
        }
    }
}
