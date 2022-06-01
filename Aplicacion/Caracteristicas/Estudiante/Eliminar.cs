using Aplicacion.Persistencia;
using MediatR;

namespace Aplicacion.Caracteristicas.Estudiante;

public class Eliminar
{
    public record Comando(int Id) : IRequest<int>;

    public class Handler : IRequestHandler<Comando, int>
    {
        private readonly CursoContext context;

        public Handler(CursoContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(Comando request, CancellationToken cancellationToken)
        {
            var estudiante = await context.Estudiantes.FindAsync(request.Id, cancellationToken);
            if (estudiante != null)
            {
                context.Estudiantes.Remove(estudiante);
                return await context.SaveChangesAsync(cancellationToken);
            }

            return 0;
        }
    }
}