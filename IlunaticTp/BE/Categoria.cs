using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Categoria
    {
		private int idCategoria;

		public int IdCategoria
		{
			get { return idCategoria; }
			set { idCategoria = value; }
		}

		private string descripcion;

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
