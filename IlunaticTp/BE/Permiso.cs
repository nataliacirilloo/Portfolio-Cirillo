using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Permiso
    {
		private int idPermiso;

		public int IdPermiso
		{
			get { return idPermiso; }
			set { idPermiso = value; }
		}

		private int idRol;

		public int IdRol
		{
			get { return idRol; }
			set { idRol = value; }
		}

		private string nombreMenu;

		public string NombreMenu
		{
			get { return nombreMenu; }
			set { nombreMenu = value; }
		}

		private string fechaRegistro;

		public string FechaRegistro
		{
			get { return fechaRegistro; }
			set { fechaRegistro = value; }
		}

	}
}
