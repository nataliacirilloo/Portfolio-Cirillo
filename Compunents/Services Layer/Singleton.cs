using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer
{
    public class Singleton
    {


        private static SqlConnection instancia;

        private Singleton() { }

        public static SqlConnection ObtenerInstancia(string cadenaconexion)
        {
            if (instancia == null)
            {
                instancia = new SqlConnection(cadenaconexion);
            }

            return instancia;
        }

    }
}
