using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Entity_Layer;
using System.Data.SqlClient;

namespace Data_Access_Layer.Mappers
{
    public class LocalidadDAL
    {
        DataAccess dt = new DataAccess();
        
        /// <summary>
        /// Obtiene todas las localidades disponibles con sus costos de envío
        /// </summary>
        public List<Localidad> ObtenerLocalidades()
        {
            DataTable dtLocalidades = dt.Leer("SP_ObtenerLocalidades");
            List<Localidad> localidades = new List<Localidad>();
            foreach (DataRow row in dtLocalidades.Rows)
            {
                Localidad localidad = new Localidad
                {
                    IdLocalidad = Convert.ToInt32(row["Id_Localidad"]),
                    Nombre = row["Nombre"].ToString(),
                    CostoEnvio = Convert.ToDecimal(row["CostoEnvio"]),
                    MontoMinimoEnvio = Convert.ToDecimal(row["MontoMinimoEnvio"])

                };
                localidades.Add(localidad);
            }
            return localidades;
        }

        /// <summary>
        /// Obtiene una localidad específica por su ID
        /// </summary>
        public Localidad ObtenerPorId(int idLocalidad)
        {
            Localidad localidad = null;
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdLocalidad", idLocalidad)
            };
            DataTable tabla = dt.Leer("SP_ObtenerLocalidadPorId", parametros);

            if (tabla.Rows.Count > 0)
            {
                DataRow dr = tabla.Rows[0];
                localidad = new Localidad
                {
                    IdLocalidad = Convert.ToInt32(dr["Id_Localidad"]),
                    Nombre = dr["Nombre"].ToString(),
                    CostoEnvio = Convert.ToDecimal(dr["CostoEnvio"]),
                    MontoMinimoEnvio = Convert.ToDecimal(dr["MontoMinimoEnvio"])
                };
            }
            return localidad;
        }

        /// <summary>
        /// Simula la corrupción de datos de localidades para pruebas de recuperación
        /// </summary>
        public void Corromper()
        {
            dt.Escribir("SP_CorromperLocalidades", null);
        }

        /// <summary>
        /// Actualiza los datos de una localidad existente
        /// </summary>
        public void ActualizarLocalidad(Localidad localidad)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdLocalidad", localidad.IdLocalidad),
                new SqlParameter("@Nombre", localidad.Nombre),
                new SqlParameter("@CostoEnvio", localidad.CostoEnvio),
                new SqlParameter("@MontoMinimoEnvio", localidad.MontoMinimoEnvio)
            };
            dt.Escribir("SP_ActualizarLocalidad", parametros);
        }

        /// <summary>
        /// Inserta una nueva localidad en la base de datos
        /// </summary>
        public void InsertarLocalidad(Localidad localidad)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Nombre", localidad.Nombre),
                new SqlParameter("@CostoEnvio", localidad.CostoEnvio),
                new SqlParameter("@MontoMinimoEnvio", localidad.MontoMinimoEnvio)
            };
            dt.Escribir("SP_InsertarLocalidad", parametros);

        }

        /// <summary>
        /// Elimina todas las localidades de la base de datos
        /// </summary>
        public void EliminarTodos()
        {
            dt.Escribir("SP_EliminarTodasLasLocalidades", null);
        }


        /// <summary>
        /// Inserta una localidad especificando manualmente su ID
        /// </summary>
        public void InsertarLocalidadConId(Localidad localidad)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Id_Localidad", localidad.IdLocalidad),
                new SqlParameter("@Nombre", localidad.Nombre),
                new SqlParameter("@CostoEnvio", localidad.CostoEnvio),
                new SqlParameter("@MontoMinimoEnvio", localidad.MontoMinimoEnvio)
            };
            dt.Escribir("SP_InsertarLocalidadConId", parametros);

        }
    }
}
