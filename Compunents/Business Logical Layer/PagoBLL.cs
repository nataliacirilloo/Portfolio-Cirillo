using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business_Logical_Layer
{
    public class PagoBLL
    {
        private readonly PagoDAL pagoDAL = new PagoDAL();

        /// <summary>
        /// Valida los datos de una tarjeta de crédito antes del procesamiento del pago
        /// </summary>
        public bool ValidarTarjeta(string numero, string nombre, string vencimiento, string cvv)
        {
            if (string.IsNullOrWhiteSpace(numero) || string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(vencimiento) || string.IsNullOrWhiteSpace(cvv))
            {
                return false; 
            }

            if (!Regex.IsMatch(vencimiento, @"^(0[1-9]|1[0-2])\/\d{2}$"))
            {
                return false;
            }

            try
            {
                return pagoDAL.ValidarTarjeta(numero, nombre, vencimiento, cvv);
            }
            catch
            {
               return false;
            }
        }
    }


}

