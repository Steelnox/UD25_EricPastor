using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UD25_Ej1.Models
{
    public class Fabricante
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public ICollection<Articulo> Articulos { get; set; } 
    }
}
