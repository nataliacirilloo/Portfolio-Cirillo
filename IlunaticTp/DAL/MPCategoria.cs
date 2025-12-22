using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MPCategoria
    {
        Acceso acceso = new Acceso();

        public List<Categoria> ListarCategoria()
        {
            List<Categoria> Categorias = new List<Categoria>();
            DataTable dt = new DataTable();
            dt = acceso.Leer("ListarCategorias", null);
            foreach (DataRow dr in dt.Rows)
            {
                Categoria Categoria = new Categoria();
                Categoria.IdCategoria = Convert.ToInt32(dr["idCategoria"]);
                Categoria.Descripcion = dr["descripcion"].ToString();
                Categoria.EsActivo = dr["esActivo"].ToString();
                //Categoria.FechaRegistro= dr["fechaRegistro"].ToString();
                Categorias.Add(Categoria);

            }
            return Categorias;
        }

        public int AltaCategoria(Categoria Categoria)
        {
            int fa = 0;

            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@idCategoria", Categoria.IdCategoria),
                new SqlParameter("@descripcion", Categoria.Descripcion),
                new SqlParameter("@esActivo", Categoria.EsActivo)
            };
            fa = acceso.Escribir("AddCategoria", sp);
            return fa;
        }

        public int ModificarCategoria(Categoria Categoria)
        {
            int fa = 0;

            SqlParameter[] p = new SqlParameter[]
            {
            new SqlParameter("@idCategoria", Categoria.IdCategoria),
                new SqlParameter("@descripcion", Categoria.Descripcion),
                new SqlParameter("@esActivo", Categoria.EsActivo)
            };
            fa = acceso.Escribir("ModificarCategoria", p);
            return fa;
        }

        public int EliminarCategoria(Categoria Categoria)
        {
            int fa = 0;

            SqlParameter[] parameters = new SqlParameter[1]
            {
                new SqlParameter("idCategoria",Categoria.IdCategoria)
            };
            fa = acceso.Escribir("EliminarCategoria", parameters);
            return fa;
        }
    }
}
