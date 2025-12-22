using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Proveedor
    {

		private int idProveedor;

		public int IdProveedor
		{
			get { return idProveedor; }
			set { idProveedor = value; }
		}

		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		private string nroDocumento;

		public string NroDocumento
		{
			get { return nroDocumento; }
			set { nroDocumento = value; }
		}

		private string razonSocial;

		public string RazonSocial
		{
			get { return razonSocial; }
			set { razonSocial = value; }
		}

		private string correo;

		public string Correo
		{
			get { return correo; }
			set { correo = value; }
		}

		private string telefono;

		public string Telefono
		{
			get { return telefono; }
			set { telefono = value; }
		}

		private string estado;

		public string Estado
		{
			get { return estado; }
			set { estado = value; }
		}

        private string fechaRegistro;

        public string FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

    }
}
