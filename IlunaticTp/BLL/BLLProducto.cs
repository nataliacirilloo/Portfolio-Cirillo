using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLProducto
    {
        MPProducto mapper = new MPProducto();
        public List<Productos> ListarProducto()
        {
            return mapper.ListarProducto();
        }

        public int AgregarProducto(Productos producto)
        {
            return mapper.AltaProducto(producto);
        }
        public int ModificarProducto(Productos producto)
        {
            return mapper.ModificarProducto(producto);
        }
        public int EliminarProducto(Productos producto)
        {
            return mapper.EliminarProducto(producto);
        }
    }
}
