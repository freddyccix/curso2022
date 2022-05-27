using Aplicacion.Infraestructura;

namespace Aplicacion.Caracteristicas.Estudiantes;

public class ObtenerTodo
{
    public interface IObtenerTodo
    {
        IReadOnlyCollection<EstudianteDTO> Ejecutar();
    }

    public class Handler : IObtenerTodo
    {
        private readonly IContextoBD contexto;

        public Handler(IContextoBD contexto)
        {
            this.contexto = contexto;
        }

        public IReadOnlyCollection<EstudianteDTO> Ejecutar()
        {
            return contexto.Estudiantes
                .Select(x =>
                    new EstudianteDTO
                    {
                        Id = x.Id.ToString(),
                        NombreEstudiante = x.NombreCompleto
                    })
                .ToList();
        }
    }

    public class EstudianteDTO
    {
        public string Id { get; set; }
        public string NombreEstudiante { get; set; }
    }
}