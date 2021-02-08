using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UD25_Ej4.Models
{
    public class Sala
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int PeliculaID { get; set; }
        public Pelicula Pelicula { get; set; }
    }
}
