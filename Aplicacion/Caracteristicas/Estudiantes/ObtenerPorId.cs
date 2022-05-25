using Aplicacion.Dominio;
using Aplicacion.Infraestructura;

namespace Aplicacion.Caracteristicas.Estudiantes;

public class ObtenerPorId
{
    private readonly IContextoBD contexto;

    public ObtenerPorId(IContextoBD contexto)
    {
        this.contexto = contexto;
    }

    public Estudiante? Ejecutar(int id)
    {
        return contexto.Estudiantes.FirstOrDefault(x => x.Id == id);
    }
}