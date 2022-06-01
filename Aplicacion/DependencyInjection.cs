using System.Reflection;
using Aplicacion.Caracteristicas.Estudiante;
using Aplicacion.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aplicacion;

public static class DependencyInjection
{
    public static IServiceCollection AddAplicacion(this IServiceCollection servicio, IConfiguration configuration)
    {
        servicio.AddAutoMapper(Assembly.GetExecutingAssembly());
        servicio.AddScoped<IContextoBD, CursoContext>();
        servicio.AddScoped<ObtenerPorId.IObtenerPorId, ObtenerPorId.Handler>();
        servicio.AddScoped<ObtenerTodo.IObtenerTodo, ObtenerTodo.Handler>();
        servicio.AddDbContext<CursoContext>(x =>
            x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return servicio;
    }
}