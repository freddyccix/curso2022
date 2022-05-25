using Aplicacion.Dominio;

namespace Aplicacion.Infraestructura;

public interface IContextoBD
{
    public IList<Estudiante> Estudiantes { get; set; }
}