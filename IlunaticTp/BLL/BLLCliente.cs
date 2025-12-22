using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCliente
    {
        MPCliente mapper = new MPCliente();

        public List<Cliente> ListarCliente()
        {
            return mapper.ListarCliente();
        }

        public int AgregarCliente(Cliente cliente)
        {
            return mapper.AltaCliente(cliente);
        }
        public int ModificarCliente(Cliente cliente)
        {
            return mapper.ModificarCliente(cliente);
        }
        public int EliminarCliente(Cliente cliente)
        {
            return mapper.EliminarCliente(cliente);
        }
        public Cliente ObtenerClientePorDNI(string nroDocumento)
        {
            return mapper.ObtenerCliente(nroDocumento);
        }
    }
}
