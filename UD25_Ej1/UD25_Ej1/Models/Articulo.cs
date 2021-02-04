using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UD25_Ej1.Models
{
    public class Articulo
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }

        public int FabricanteID { get; set; }
        public Fabricante Fabricante { get; set; }
    }
}
