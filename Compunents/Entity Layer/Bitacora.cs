using System;

namespace Entity_Layer
{
    /// <summary>
    /// Representa un evento registrado en la bitácora del sistema para auditoría y seguimiento
    /// </summary>
    public class Bitacora
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private int id_user;

		public int Id_user
		{
			get { return id_user; }
			set { id_user = value; }
		}

		private string modulo;

		public string Modulo
		{
			get { return modulo; }
			set { modulo = value; }
		}

		private string evento;

		public string Evento
		{
			get { return evento; }
			set { evento = value; }
		}

		private int criticidad;

		public int Criticidad
		{
			get { return criticidad; }
			set { criticidad = value; }
		}

		private DateTime fecha;

		public DateTime Fecha
		{
			get { return fecha; }
			set { fecha = value; }
		}


	}
}
