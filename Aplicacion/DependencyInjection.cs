using System.Reflection;
using Aplicacion.Caracteristicas.Estudiantes;
using Aplicacion.Dominio;
using Aplicacion.Infraestructura;
using Microsoft.Extensions.DependencyInjection;

namespace Aplicacion;

public static class DependencyInjection
{
    public static IServiceCollection AddAplicacion(this IServiceCollection servicio)
    {
        servicio.AddAutoMapper(Assembly.GetExecutingAssembly());
        servicio.AddScoped<IList<Estudiante>, List<Estudiante>>();
        servicio.AddScoped<IContextoBD, ContextoEscuela>();
        servicio.AddScoped<ObtenerPorId.IObtenerPorId, ObtenerPorId.Handler>();
        servicio.AddScoped<ObtenerTodo.IObtenerTodo, ObtenerTodo.Handler>();
        return servicio;
    }
}