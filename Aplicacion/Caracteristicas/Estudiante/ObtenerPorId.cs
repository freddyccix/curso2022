using Aplicacion.Dominio.Entidades;
using Aplicacion.Persistencia;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Caracteristicas.Estudiante;

public class ObtenerPorId
{
    public record Consulta(int Id) : IRequest<Respuesta>;

    public class Handler : IRequestHandler<Consulta, Respuesta>
    {
        private readonly CursoContext contexto;
        private readonly IMapper mapper;

        public Handler(CursoContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        public async Task<Respuesta> Handle(Consulta request, CancellationToken cancellationToken)
        {
            var estudianteBase = await contexto.Estudiantes
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            var estudiante2 =
                await contexto.Estudiantes.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            var estudiante3 = await contexto.Estudiantes.FindAsync(request.Id);
            return mapper.Map<Respuesta>(estudianteBase);
        }

        public class MapRespuesta : Profile
        {
            public MapRespuesta()
            {
                CreateMap<Estudiantes, Respuesta>();
            }
        }
    }

    public record Respuesta(string Id, string Nombres, string Apellidos, string Edad);
}