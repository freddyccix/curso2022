namespace Aplicacion.Dominio;

public class Estudiante
{
    public int Id { get; set; }
    public int Edad { get; set; }
    public string Nombres { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;

    public string NombreCompleto =>
        Nombres == string.Empty ? Apellidos :
        Apellidos == string.Empty ? Nombres :
        Nombres == string.Empty && Apellidos == string.Empty ? string.Empty : $"{Apellidos}, {Nombres}";
}