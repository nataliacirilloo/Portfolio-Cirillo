using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Mappers
{
    public class BackupDAL
    {
        DataAccess dt = new DataAccess();

        /// <summary>
        /// Verifica si existen datos corruptos en productos y localidades
        /// </summary>
        public (bool productosCorruptos, bool localidadesCorruptas) VerificarCorrupcion()
        {
            DataTable tabla = dt.Leer("SP_VerificarCorrupcion", null);

            if (tabla.Rows.Count > 0)
            {
                DataRow fila = tabla.Rows[0];

                bool productosCorruptos = fila["ProductosCorruptos"] != DBNull.Value && Convert.ToBoolean(fila["ProductosCorruptos"]);
                bool localidadesCorruptas = fila["LocalidadesCorruptas"] != DBNull.Value && Convert.ToBoolean(fila["LocalidadesCorruptas"]);

                return (productosCorruptos, localidadesCorruptas);
            }

            return (false, false);
        }



    }
}
