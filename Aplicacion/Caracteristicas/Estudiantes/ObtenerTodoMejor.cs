using Aplicacion.Infraestructura;

namespace Aplicacion.Caracteristicas.Estudiantes;

public interface IObtenerTodoMejor
{
    IReadOnlyCollection<ObtenerTodoMejor.EstudianteMejorDTO> Ejecutar();
}

public class ObtenerTodoMejor : IObtenerTodoMejor
{
    private readonly IContextoBD contexto;

    public ObtenerTodoMejor(IContextoBD contexto)
    {
        this.contexto = contexto;
    }

    public IReadOnlyCollection<EstudianteMejorDTO> Ejecutar()
    {
        return contexto.Estudiantes
            .Select(x =>
                new EstudianteMejorDTO
                {
                    Id = x.Id.ToString(),
                    NombreEstudiante = x.NombreCompleto,
                    Edad = x.Edad.ToString()
                })
            .ToList()
            .OrderBy(x => x.NombreEstudiante)
            .ToList();
    }

    public class EstudianteMejorDTO
    {
        public string Id { get; set; }
        public string NombreEstudiante { get; set; }
        public string Edad { get; set; }
    }
}