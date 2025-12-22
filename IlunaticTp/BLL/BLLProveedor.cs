using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLProveedor
    {
        MPProveedor mapper = new MPProveedor();

        public List<Proveedor> Listarproveedor()
        {
            return mapper.ListarProveedor();
        }

        public int Agregarproveedor(Proveedor proveedor)
        {
            return mapper.AltaProveedor(proveedor);
        }
        public int Modificarproveedor(Proveedor proveedor)
        {
            return mapper.ModificarProveedor(proveedor);
        }
        public int Eliminarproveedor(Proveedor proveedor)
        {
            return mapper.EliminarProveedor(proveedor);
        }
    }
}
