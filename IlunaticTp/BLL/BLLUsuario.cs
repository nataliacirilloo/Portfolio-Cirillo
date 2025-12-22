using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLUsuario
    {
        MPUsuario mapper = new MPUsuario();

        public List<Usuario> ListarUsuario()
        {
            return mapper.ListarUsuario ();
        }

        public int AgregarUsuario(Usuario usuario)
        {
            return mapper.AltaUsuario(usuario);
        }
        public int ModificarUsuario(Usuario usuario)
        {
            return mapper.AltaUsuario(usuario);
        }
        public int EliminarUsuario(Usuario usuario)
        {
            return mapper.AltaUsuario(usuario);
        }
    }
}
