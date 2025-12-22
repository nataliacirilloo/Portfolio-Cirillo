using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Composite
{
    public class Familia : IPermiso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<IPermiso> permisos { get; set; } = new List<IPermiso>();


    }
}
