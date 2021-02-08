using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UD25_Ej4.Models
{
    public class Pelicula
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string CalificacionEdad { get; set; }
        public ICollection<Sala> Salas { get; set; }
    }
}
