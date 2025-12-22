using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario
    {
		private int idUsuario;

		public int IdUsuario
		{
			get { return idUsuario; }
			set { idUsuario = value; }
		}

		private string dni;

		public string DNI
		{
			get { return dni; }
			set { dni = value; }
		}

		private string nombreApellidos;

		public string NombreApellidos
		{
			get { return nombreApellidos; }
			set { nombreApellidos = value; }
		}

		private string correo;

		public string Correo
		{
			get { return correo; }
			set { correo = value; }
		}

		private int idRol;

		public int IdRol
		{
			get { return idRol; }
			set { idRol = value; }
		}

		private string clave;

		public string Clave
		{
			get { return clave; }
			set { clave = value; }
		}

		private string esActivo;

		public string EsActivo
		{
			get { return esActivo; }
			set { esActivo = value; }
		}

	}
}
