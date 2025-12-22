using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Venta
    {
		private int idVenta;

		public int IdVenta
		{
			get { return idVenta; }
			set { idVenta = value; }
		}

		private string nroDocumento;

		public string NroDocumento
		{
			get { return nroDocumento; }
			set { nroDocumento = value; }
		}
		private string tipoPago;

		public string TipoPago
		{
			get { return tipoPago; }
			set { tipoPago = value; }
		}
		private float total;

		public float Total
		{
			get { return total; }
			set { total = value; }
		}


		private string fechaRegistro;

		public string FechaRegistro
		{
			get { return fechaRegistro; }
			set { fechaRegistro = value; }
		}

	}
}
