using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T24_Ejercici1.Modelos
{
    public class Articulo
    { 
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int FabricanteID { get; set; }

        public Fabricante Fabricantes { get; set; }

    }
}
