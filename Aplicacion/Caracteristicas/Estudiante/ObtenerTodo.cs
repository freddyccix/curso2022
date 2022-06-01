using Aplicacion.Dominio.Entidades;
using Aplicacion.Persistencia;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Caracteristicas.Estudiante;

public class ObtenerTodo
{
    public record Consulta : IRequest<IReadOnlyCollection<Respuesta>>;

    public class Handler : IRequestHandler<Consulta, IReadOnlyCollection<Respuesta>>
    {
        private readonly CursoContext contexto;
        private readonly IMapper mapper;

        public Handler(CursoContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyCollection<Respuesta>> Handle(Consulta request, CancellationToken cancellationToken)
        {
            return await contexto.Estudiantes
                .ProjectTo<Respuesta>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

    public class MapRespuesta : Profile
    {
        public MapRespuesta()
        {
            CreateMap<Estudiantes, Respuesta>();
        }
    }

    public record Respuesta(string Id, string NombreCompleto);
}