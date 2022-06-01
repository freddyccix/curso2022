using Aplicacion.Dominio.Entidades;
using Aplicacion.Persistencia;
using AutoMapper;
using MediatR;

namespace Aplicacion.Caracteristicas.Estudiante;

public class Editar
{
    public record Comando
        (int Id, string Nombres, string Apellidos, DateTime FechaNacimiento, string Direccion) : IRequest<int>;

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
            var estudiante = await context.Estudiantes.FindAsync(request.Id, cancellationToken);

            if (estudiante != null)
            {
                context.Estudiantes.Update(mapper.Map(request, estudiante));
                return await context.SaveChangesAsync(cancellationToken);
            }

            return 0;
        }

        public class MapRespuesta : Profile
        {
            public MapRespuesta()
            {
                CreateMap<Estudiantes, Comando>().ReverseMap();
            }
        }
    }
}