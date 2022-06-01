using Aplicacion.Dominio.Entidades;
using Aplicacion.Persistencia;
using AutoMapper;
using MediatR;

namespace Aplicacion.Caracteristicas.Estudiante;

public class Insertar
{
    public record Comando(string Nombres, string Apellidos, DateTime FechaNacimiento, string Direccion) : IRequest<int>;

    public class Handler : IRequestHandler<Comando, int>
    {
        private readonly CursoContext context;
        private readonly IMapper mapper;

        public Handler(CursoContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> Handle(Comando request, CancellationToken cancellationToken)
        {
            await context.Estudiantes.AddAsync(mapper.Map<Estudiantes>(request), cancellationToken);
            return await context.SaveChangesAsync(cancellationToken);
        }

        public class MapRespuesta : Profile
        {
            public MapRespuesta()
            {
                CreateMap<Comando, Estudiantes>();
            }
        }
    }
}