using Aplicacion.Dominio;

namespace Aplicacion.Infraestructura;

public class ContextoEscuela
{
    public List<Estudiante> Estudiantes { get; set; } = new();
}