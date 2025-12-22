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
        /// Asigna una familia de permisos a un perfil específico
        /// </summary>
        public int AgregarFamiliaPerfil(Familia fam, Perfil per)
        {
            int res = 0;

            SqlParameter[] sql = new SqlParameter[]
            {
                new SqlParameter("@Nombre", fam.Nombre),
                new SqlParameter("@FamiliaId", fam.Id),
                new SqlParameter("@PerfilId", per.Id),
                new SqlParameter("@PerfilNombre", per.Nombre)
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
        /// Obtiene todas las familias de permisos asignadas a un perfil específico
        /// </summary>
        public DataTable ObtenerFamiliasPorPerfil(int perfilId)
        {
            SqlParameter[] sql = new SqlParameter[]
            {
                new SqlParameter("@PerfilId", perfilId)
            };
            var dt = dataAccess.Leer("SP_ObtenerFamiliasPorPerfil", sql);
            return dt;
        }


        /// <summary>
        /// Elimina la asignación de una familia de permisos a un perfil
        /// </summary>
        public int EliminarFamiliaPerfil(Familia fam, Perfil per)
        {
            int res = 0;

            SqlParameter[] sql = new SqlParameter[]
            {
                new SqlParameter("@Nombre", fam.Nombre),
                new SqlParameter("@FamiliaId", fam.Id),
                new SqlParameter("@PerfilId", per.Id),
                new SqlParameter("@PerfilNombre", per.Nombre)
            };


            res = dataAccess.Escribir("SP_EliminarFamiliaPerfil", sql);

            return res;

        }


        




    }
}
