using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Rol
    {
        private int idRol;

        public int IdRol
        {
            get { return idRol; }
            set { idRol = value; }
        }

        public string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string esActivo;

        public string EsActivo
        {
            get { return esActivo; }
            set { esActivo = value; }
        }

        private string fechaRegistro;

        public string FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

    }
}
