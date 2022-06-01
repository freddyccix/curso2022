using System.Reflection;
using Aplicacion.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aplicacion;

public static class DependencyInjection
{
    public static IServiceCollection AddAplicacion(this IServiceCollection servicio, IConfiguration configuration)
    {
        servicio.AddAutoMapper(Assembly.GetExecutingAssembly());
        servicio.AddMediatR(Assembly.GetExecutingAssembly());
        servicio.AddDbContext<CursoContext>(x =>
            x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return servicio;
    }
}