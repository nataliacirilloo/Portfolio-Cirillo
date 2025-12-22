using Data_Access_Layer.Mappers;
using Services_Layer;
using Services_Layer.Composite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logical_Layer
{
    /// <summary>
    /// Clase de lógica de negocio para gestión de perfiles, familias y permisos
    /// </summary>
    public class PerfilFamiliasBLL
    {
        PerfilDAL per = new PerfilDAL();
        FamiliaDAL familiaDAL = new FamiliaDAL();

        /// <summary>
        /// Crea un nuevo perfil con validaciones de negocio
        /// </summary>
        public int AgregarPerfil(Perfil perfil)
        {
            int resultado = 0;
            var perfilesExistentes = per.ObtenerPerfiles();
            var validacion = ValidarPerfil(perfil);
            
            if (perfil == null || string.IsNullOrEmpty(perfil.Nombre))
            {
                throw new ArgumentException("El perfil no puede ser nulo y debe tener un nombre válido.");
            }
           if(validacion == 0)
            {
                resultado = -1;
                throw new ArgumentException("El perfil ya existe en la base de datos.");
            }
           else if(validacion == -1)
            {
                resultado = 0;
                per.AgregarPerfil(perfil);
            }

            return resultado;
        }

        /// <summary>
        /// Crea una nueva familia con validaciones de negocio
        /// </summary>
        public int AgregarFamilia(Familia familia)
        {
            int resultado = 0;
            var validacion = ValidarFamilia(familia);
            var fam= familiaDAL.ObtenerFamiliaPorNombre(familia.Nombre);

            if (familia == null || string.IsNullOrEmpty(familia.Nombre))
            {
                throw new ArgumentException("La familia no puede ser nula y debe tener un nombre válido.");
            }
            if (validacion == 0)
            {
                resultado = 0;
                throw new ArgumentException("La familia ya existe en la base de datos.");
            }
            else if (validacion == -1)
            {
                resultado = -1;
                familiaDAL.AgregarFamilia(familia);
            }
            return resultado;
        }

        /// <summary>
        /// Valida si una familia ya existe en el sistema
        /// </summary>
        public int ValidarFamilia(Familia familia)
        {
            int resultado = 0;
            var familias = familiaDAL.ObtenerFamilias();
            var fam = familiaDAL.ObtenerFamiliaPorNombre(familia.Nombre);
            var lista = Conversor.DataTableToList<Familia>(familias);
            if (familia == null || string.IsNullOrEmpty(familia.Nombre))
            {
                throw new ArgumentException("La familia no puede ser nula y debe tener un nombre válido.");
            }
            foreach (var fami in lista)
            {
                if (fam != null)
                {
                    if (fam.Id_Familia == fami.Id_Familia)
                    {
                        resultado = 0; // Familia existe
                    }
                }
                else
                {
                    resultado = -1; // Familia no existe
                }
            }
            return resultado;
        }

        /// <summary>
        /// Valida si un perfil ya existe en el sistema
        /// </summary>
        public int ValidarPerfil(Perfil perfil)
        {
            var perfiles = per.ObtenerPerfiles();
            var lista = Conversor.DataTableToList<Perfil>(perfiles);
            int res = 0;

            if (perfil == null || string.IsNullOrEmpty(perfil.Nombre))
            {
                throw new ArgumentException("El perfil no puede ser nulo y debe tener un nombre válido.");
            }

            foreach(var per in lista)
            {
                if(perfil.Id_Perfil == per.Id_Perfil)
                {
                    res= 0; // Perfil existe
                }
                else
                {
                    res = -1;
                }
            }

            return res;
        }

        /// <summary>
        /// Asigna un perfil específico a un usuario
        /// </summary>
        public int AsignarPerfilUsuario(int idusuario, int idperfil)
        {
            int res = 0;

            res = per.AsignarPerfilUsuario(idusuario, idperfil);

            return res;
        }

        /// <summary>
        /// Obtiene las familias asignadas a un perfil específico
        /// </summary>
        public DataTable ObtenerFamiliaPefil(int idperfil)
        {
            return per.ObtenerFamiliaPerfil(idperfil);
        }

        /// <summary>
        /// Obtiene el perfil asignado a un usuario específico
        /// </summary>
        public DataTable ObtenerPerfilAsignado(int idusuario)
        {
            return per.ObtenerPerfilUsuario(idusuario);
        }

        /// <summary>
        /// Asigna una familia específica a un perfil
        /// </summary>
        public int AgregarFamiliaPerfil(int idper,int fam)
        {
            int res = 0;
            var validacion = 0;

            res = per.AgregarFamiliaPerfil(fam, idper);

            if(res == 0)
            {
                return res;
            }
            else
            {
                return res;
            }
       }

        /// <summary>
        /// Elimina la asignación de familia a un perfil
        /// </summary>
        public int EliminarFamiliaPerfil(Familia familia, Perfil perfil)
        {
           var res = per.EliminarFamiliaPerfil(familia, perfil);

            return res;
        }

        /// <summary>
        /// Obtiene todos los perfiles disponibles en el sistema
        /// </summary>
        public List<Perfil> ObtenerPerfiles()
        {
            var dt = per.ObtenerPerfiles();
            var lista = Conversor.DataTableToList<Perfil>(dt);
            return lista;
        }

        /// <summary>
        /// Obtiene todos los permisos disponibles en el sistema
        /// </summary>
        public List<Permiso> ObtenerPermisos()
        {
            var dt = familiaDAL.ObtenerPermisos();
            var lista = Conversor.DataTableToList<Permiso>(dt);
            return lista;
        } 

        /// <summary>
        /// Obtiene todas las familias disponibles en el sistema
        /// </summary>
        public List<Familia> ObtenerFamilia()
        {
            var dt = familiaDAL.ObtenerFamilias();
            var lista = Conversor.DataTableToList<Familia>(dt);
            return lista;
        }

        /// <summary>
        /// Asigna múltiples permisos a una familia específica
        /// </summary>
        public int AgregarPermisosFamilia(int idfamilia,List<int> idpermiso)
        {
            int res = 0;
            try
            {
                foreach (var per in idpermiso)
                {
                    familiaDAL.AgregarPermisosAFamilia(per, idfamilia);
                    res++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return res;
        }

        /// <summary>
        /// Elimina todos los permisos asignados a una familia
        /// </summary>
        public int EliminarPermisosFamilia(int idfamilia)
        {
            int res = 0;
            try
            {
               var resultado =familiaDAL.EliminarPermisosAFamilia(idfamilia);

               if(resultado > 0)
               {
                    res = 1;
                   }   
            }
            catch (Exception ex)
            {
                res = -1;
                throw new Exception(ex.Message);
            }
            return res;
        }

        /// <summary>
        /// Obtiene los permisos asignados a una familia específica
        /// </summary>
        public List<Permiso> ObtenerPermisosPorFamilia(int idFamilia)
        {
            return familiaDAL.ObtenerPermisosXFamilia(idFamilia);
        }
    }
}
