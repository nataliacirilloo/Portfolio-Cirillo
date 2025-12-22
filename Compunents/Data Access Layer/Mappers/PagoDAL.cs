using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class PagoDAL
    {

        DataAccess dataAccess = new DataAccess();

        /// <summary>
        /// Valida los datos de una tarjeta de crédito consultando la base de datos
        /// </summary>
        public bool ValidarTarjeta(string numero, string nombre, string vencimiento, string cvv)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@NumeroTarjeta", numero),
                new SqlParameter("@NombreTitular", nombre),
                new SqlParameter("@FechaVencimiento", vencimiento),
                new SqlParameter("@CodigoSeguridad", cvv)
            };

            DataTable resultadoTabla = dataAccess.Leer("SP_ValidarTarjeta", parametros);
            if (resultadoTabla != null && resultadoTabla.Rows.Count > 0)
            {
                int resultado = Convert.ToInt32(resultadoTabla.Rows[0][0]);
                return resultado == 1;
            }

            return false;
        }

    }
}
