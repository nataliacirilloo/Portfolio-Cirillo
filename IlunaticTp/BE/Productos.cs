using System;

namespace BE
{
    public class Productos
    {
		private int idProducto;

		public int IdProducto
		{
			get { return idProducto; }
			set { idProducto = value; }
		}

		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		private int idCategoria;

		public int IdCategoria
		{
			get { return idCategoria; }
			set { idCategoria = value; }
		}

		private int stock;

		public int Stock
		{
			get { return stock; }
			set { stock = value; }
		}

		private float precio;

		public float Precio
		{
			get { return precio; }
			set { precio = value; }
		}

        private string esActivo;

        public string EsActivo
        {
            get { return esActivo; }
            set { esActivo = value; }
        }

        private DateTime fechaRegistro;

        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

    }
}