using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UD25_Ej2.Models
{
    public class Empleado
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int DepartamentoID { get; set; }
        public Departamento Departamento { get; set; }

    }
}
