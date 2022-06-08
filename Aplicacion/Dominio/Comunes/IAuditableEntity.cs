namespace Aplicacion.Dominio.Comunes;

public interface IAuditableEntity
{
    public DateTime Creado { get; set; }
    public DateTime Modificado { get; set; }
    public string CreadoPor { get; set; }
    public string ModificadoPor { get; set; }
}