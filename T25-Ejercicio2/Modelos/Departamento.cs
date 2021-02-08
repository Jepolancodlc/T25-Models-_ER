using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T24_Ejercici1.Modelos
{
    public class Departamento
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Presupuesto { get; set; }
        public ICollection<Empleado> Empleados { get; set; }
    }
}
