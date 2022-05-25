using Aplicacion.Dominio;
using Aplicacion.Infraestructura;

namespace Aplicacion.Caracteristicas.Estudiantes;

public class ObtenerTodo
{
    private readonly ContextoEscuela contexto; //esta es mi dependencia

    public ObtenerTodo(ContextoEscuela contexto)
    {
        this.contexto = contexto;
    }

    public List<Estudiante> Ejecutar()
    {
        return contexto.Estudiantes;
    }
}