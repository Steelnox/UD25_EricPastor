using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UD25_Ej3.Models
{
    public class Caja
    {
        public string NumReferencia { get; set; }
        public string Contenido { get; set; }
        public int Valor { get; set; }
        public int AlmacenID { get; set; }
        public Almacen Almacen { get; set; }
    }
}
