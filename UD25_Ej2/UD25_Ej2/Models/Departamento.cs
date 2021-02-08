using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UD25_Ej2.Models
{
    public class Departamento
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Presupuesto { get; set; }
        public ICollection<Empleado> Empleados { get; set; }
    }
}
