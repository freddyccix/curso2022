using Aplicacion.Dominio;

namespace Aplicacion.Infraestructura;

public class ContextoEscuela : IContextoBD
{
    public ContextoEscuela(IList<Estudiante> listaEstudiantes)
    {
        Estudiantes = listaEstudiantes;
    }

    //ienumerable, ilist
    public IList<Estudiante>? Estudiantes { get; set; }
}