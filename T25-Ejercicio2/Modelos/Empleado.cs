namespace T24_Ejercici1.Modelos
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