namespace Aplicacion.Dominio.Entidades;

public partial class Estudiantes
{
    public string NombreCompleto =>
        string.IsNullOrEmpty(Nombres) && string.IsNullOrEmpty(Apellidos) ? string.Empty
        : string.IsNullOrEmpty(Nombres) ? Apellidos
        : string.IsNullOrEmpty(Apellidos) ? Nombres
        : $"{Apellidos}, {Nombres}";

    public int Edad => FechaNacimiento is null ? -1 : DateTime.Today.AddTicks(-FechaNacimiento.Value.Ticks).Year - 1;
}