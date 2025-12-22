using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCategoria
    {
        MPCategoria mapper = new MPCategoria();

        public List<Categoria> ListarCategoria()
        {
            return mapper.ListarCategoria();
        }

        public int AgregarCategoria(Categoria Categoria)
        {
            return mapper.AltaCategoria(Categoria);
        }
        public int ModificarCategoria(Categoria Categoria)
        {
            return mapper.ModificarCategoria(Categoria);
        }
        public int EliminarCategoria(Categoria Categoria)
        {
            return mapper.EliminarCategoria(Categoria);
        }
    }
}
