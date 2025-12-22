using Services_Layer.Composite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Mappers
{
    public class FamiliaDAL
    {
        private readonly DataAccess data = new DataAccess();


        /// <summary>
        /// Asigna múltiples permisos a una familia de permisos
        /// </summary>
        public int AgregarPermisosAFamilia(List<Permiso> permisos,Familia fam)
        {
            int res = 0;
            foreach(var per in permisos)
            {
                SqlParameter[] sql = new SqlParameter[]
                {
                    new SqlParameter("@Nombre", per.Nombre),

                };
                res = data.Escribir("SP_AgregarPermisoAFamilia", sql);
            }
            return res;
        }
       

        /// <summary>
        /// Crea una nueva familia de permisos en el sistema
        /// </summary>
        public int AgregarFamilia(Familia fam)
        {
            int res = 0;

            SqlParameter[] sql = new SqlParameter[]
            {
                    new SqlParameter("@Nombre", fam.Nombre),
                    new SqlParameter("@FamiliaId", fam.Id)

               };
            res = data.Escribir("SP_AgregarPermisoAFamilia", sql);

            return res;
        }

        /// <summary>
        /// Obtiene todas las familias de permisos disponibles
        /// </summary>
        public DataTable ObtenerFamilias()
        {
            var da = data.Leer("SP_ObtenerFamilias");

            return da;
        }


        /// <summary>
        /// Elimina una familia de permisos del sistema
        /// </summary>
        public int EliminarFamilia(Familia fam)
        {
            int res = 0;

            SqlParameter[] sql = new SqlParameter[]
            {
                    new SqlParameter("@Nombre", fam.Nombre),
                    new SqlParameter("@FamiliaId", fam.Id)
               };
            res = data.Escribir("SP_EliminarFamilia", sql);

            return res;
        }


        /// <summary>
        /// Elimina múltiples permisos de una familia específica
        /// </summary>
        public int EliminarPermisosAFamilia(List<Permiso> permisos, Familia fam)
        {
            int res = 0;
            foreach (var per in permisos)
            {
                SqlParameter[] sql = new SqlParameter[]
                {
                    new SqlParameter("@Nombre", per.Nombre),
                    new SqlParameter("@FamiliaId", fam.Id),

                };
                res = data.Escribir("SP_EliminarPermisosFamilia", sql);
            }
            return res;
        }

        /// <summary>
        /// Verifica si una familia de permisos existe en el sistema
        /// </summary>
        public object ValidarFamilia(Familia fam)
        {
            SqlParameter[] sql = new SqlParameter[]
            {
                new SqlParameter("@Nombre", fam.Nombre),
                new SqlParameter("@FamiliaId", fam.Id)
            };
            var res = data.Verificar("SP_ValidarFamilia", sql);
            return res;

        }

        /// <summary>
        /// Verifica si un permiso específico está asignado a una familia
        /// </summary>
        public object ValidarPermisoFamilia(Permiso per, Familia fam)
        {
            SqlParameter[] sql = new SqlParameter[]
            {
                new SqlParameter("Permiso_Id",per.Id),
                new SqlParameter("@FamiliaId", fam.Id)
            };
            var res = data.Verificar("SP_ValidarPermisoFamilia", sql);
            return res;
        }




    }
}
