using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Cliente
    {
        private int idCliente;

        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        private string documento;

        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        private string nombreCompleto;

        public string NombreCompletp
        {
            get { return nombreCompleto; }
            set { nombreCompleto = value; }
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
