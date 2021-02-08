namespace T24_Ejercici1.Modelos
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