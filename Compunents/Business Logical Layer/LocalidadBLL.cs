using Data_Access_Layer;
using Data_Access_Layer.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logical_Layer
{
    public class LocalidadBLL
    {

        private LocalidadDAL mapper = new LocalidadDAL();

        /// <summary>
        /// Obtiene todas las localidades disponibles en el sistema
        /// </summary>
        public List<Localidad> ObtenerLocalidades()
        {
            return mapper.ObtenerLocalidades();
        }

        /// <summary>
        /// Obtiene una localidad específica por su ID
        /// </summary>
        public Localidad ObtenerPorId(int idLocalidad)
        {
            return mapper.ObtenerPorId(idLocalidad);
        }

        /// <summary>
        /// Actualiza los datos de una localidad existente con validaciones
        /// </summary>
        public void ActualizarLocalidad(Localidad localidad)
        {
            if (localidad == null)
            {
                throw new ArgumentNullException(nameof(localidad), "La localidad no puede ser nula.");
            }
            if (string.IsNullOrWhiteSpace(localidad.Nombre))
            {
                throw new ArgumentException("El nombre de la localidad no puede estar vacío.", nameof(localidad.Nombre));
            }
            if (localidad.CostoEnvio < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(localidad.CostoEnvio), "El costo de envío no puede ser negativo.");
            }
            if (localidad.MontoMinimoEnvio < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(localidad.MontoMinimoEnvio), "El monto mínimo de envío no puede ser negativo.");
            }

            mapper.ActualizarLocalidad(localidad);
        }

        /// <summary>
        /// Simula una corrupción de datos para pruebas de recuperación
        /// </summary>
        public void Corromper()
        {
            mapper.Corromper();
        }

        /// <summary>
        /// Inserta una nueva localidad en el sistema
        /// </summary>
        public void InsertarLocalidad(Localidad localidad)
        {
            mapper.InsertarLocalidad(localidad);
        }

        /// <summary>
        /// Inserta una nueva localidad especificando manualmente el ID
        /// </summary>
        public void InsertarLocalidadConId(Localidad localidad)
        {
            if (localidad == null)
            {
                throw new ArgumentNullException(nameof(localidad), "La localidad no puede ser nula.");
            }
            if (string.IsNullOrWhiteSpace(localidad.Nombre))
            {
                throw new ArgumentException("El nombre de la localidad no puede estar vacío.", nameof(localidad.Nombre));
            }
            if (localidad.CostoEnvio < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(localidad.CostoEnvio), "El costo de envío no puede ser negativo.");
            }
            if (localidad.MontoMinimoEnvio < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(localidad.MontoMinimoEnvio), "El monto mínimo de envío no puede ser negativo.");
            }

            mapper.InsertarLocalidadConId(localidad);
        }

        /// <summary>
        /// Elimina todas las localidades del sistema
        /// </summary>
        public void EliminarTodos()
        {
            mapper.EliminarTodos();
        }
    }
}
