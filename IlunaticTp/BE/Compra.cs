using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Compra
    {
		private int idCompra;

		public int IdCompra
		{
			get { return idCompra; }
			set { idCompra = value; }
		}

		private Usuario idUsuario;

		public Usuario IdUsuario
		{
			get { return idUsuario; }
			set { idUsuario = value; }
		}

		private Proveedor idProveedor;

		public Proveedor IdProveedor
		{
			get { return idProveedor; }
			set { idProveedor = value; }
		}

		private string tipoDocumento;

		public string TipoDocumento
		{
			get { return tipoDocumento; }
			set { tipoDocumento = value; }
		}

		private string nroDocumento;

		public string NroDocumento
		{
			get { return nroDocumento; }
			set { nroDocumento = value; }
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
