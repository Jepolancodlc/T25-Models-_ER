using System.Collections.Generic;

public class Pelicula
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public int calificacionEdad { get; set; }
    public ICollection<Sala> salas { get; set; }
}
