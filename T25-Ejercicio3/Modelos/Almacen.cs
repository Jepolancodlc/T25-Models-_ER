using System.Collections.Generic;
namespace T24_Ejercici1.Modelos
{
    public class Almacen
    {
        public int Codigo { get; set; }
        public string lugar { get; set; }
        public int capacidad { get; set; }
        public ICollection<Caja> Cajas { get; set; }
    }
}