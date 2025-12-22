using Data_Access_Layer.Mappers;
using Services_Layer;
using Services_Layer.Composite;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logical_Layer
{
    public class PerfilFamiliasBLL
    {
        PerfilDAL per = new PerfilDAL();
        FamiliaDAL familiaDAL = new FamiliaDAL();

        /// <summary>
        /// Agrega un nuevo perfil al sistema con validaciones de duplicados
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
        /// Agrega una nueva familia al sistema con validaciones de duplicados
        /// </summary>
        public int AgregarFamilia(Familia familia)
        {
            int resultado = 0;
            var validacion = ValidarFamilia(familia);
            if (familia == null || string.IsNullOrEmpty(familia.Nombre))
            {
                throw new ArgumentException("La familia no puede ser nula y debe tener un nombre válido.");
            }
            if (validacion == 0)
            {
                resultado = -1;
                throw new ArgumentException("La familia ya existe en la base de datos.");
            }
            else if (validacion == -1)
            {
                resultado = 0;
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
            var lista = Conversor.DataTableToList<Familia>(familias);
            if (familia == null || string.IsNullOrEmpty(familia.Nombre))
            {
                throw new ArgumentException("La familia no puede ser nula y debe tener un nombre válido.");
            }
            foreach (var fam in lista)
            {
                if (familia.Id == fam.Id)
                {
                    resultado = 0; // Familia existe
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
                if(perfil.Id == per.Id)
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
        /// Valida si una familia ya está asignada a un perfil específico
        /// </summary>
        public int ValidarFamiliaPerfil(Perfil perfil, Familia fam)
        {
            int valor = 0;
            var familias = per.ObtenerFamiliasPorPerfil(perfil.Id);
            var lista = Conversor.DataTableToList<Familia>(familias);


            foreach (var familia in lista)
            {
                if(fam.Id == fam.Id)
                {
                    valor = -1;
                }
                else
                {
                    valor = 0;
                }
            }
            return valor;
        }

        /// <summary>
        /// Asigna una familia a un perfil específico
        /// </summary>
       public int AgregarFamiliaPerfil(Perfil perfil,Familia fam)
        {
            int res = 0;
            var validacion  = ValidarFamiliaPerfil(perfil, fam);

            if (fam == null || string.IsNullOrEmpty(fam.Nombre))
            {
                throw new ArgumentException("La familia no puede ser nula y debe tener un nombre válido.");
            }
            if (validacion == 0)
            {
                res = -1; 
                throw new ArgumentException("La familia ya existe en el perfil.");
            }
            else if (validacion == -1)
            {
                res = per.AgregarFamiliaPerfil(fam, perfil);
            }

            return res;

       }

        /// <summary>
        /// Elimina la asignación de una familia a un perfil
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

    }
}
