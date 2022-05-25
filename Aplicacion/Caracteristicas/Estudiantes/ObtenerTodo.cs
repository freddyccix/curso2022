using Aplicacion.Dominio;
using Aplicacion.Infraestructura;

namespace Aplicacion.Caracteristicas.Estudiantes;

public class ObtenerTodo
{
    private readonly IContextoBD contexto; //esta es mi dependencia

    public ObtenerTodo(IContextoBD contexto)
    {
        this.contexto = contexto;
    }

    public IReadOnlyCollection<Estudiante> Ejecutar()
    {
        return contexto.Estudiantes.ToList();
    }
}