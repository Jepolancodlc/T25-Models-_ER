public class Sala
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public int? PeliculaID { get; set; }
    public Pelicula Peliculas { get; set; }
}