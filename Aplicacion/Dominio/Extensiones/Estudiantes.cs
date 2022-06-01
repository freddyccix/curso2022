namespace Aplicacion.Dominio.Entidades;

public partial class Estudiantes
{
    public string NombreCompleto =>
        Nombres == string.Empty ? Apellidos :
        Apellidos == string.Empty ? Nombres :
        Nombres == string.Empty && Apellidos == string.Empty ? string.Empty : $"{Apellidos}, {Nombres}";

    public int Edad => DateTime.Today.AddTicks(-FechaNacimiento.Value.Ticks).Year - 1;
}