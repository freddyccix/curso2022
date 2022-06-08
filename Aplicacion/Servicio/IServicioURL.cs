using Microsoft.Extensions.Configuration;
using Throw;

namespace Aplicacion.Servicio;

public interface IServicioUrl
{
    string ObtenerUrl(string token, string ubicacion, string param);
}

public class MiServicioUrl : IServicioUrl
{
    private readonly IConfiguration configuration;

    public MiServicioUrl(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public string ObtenerUrl(string token, string ubicacion, string param)
    {
        token.Throw().IfEmpty();
        ubicacion.Throw().IfEmpty();
        param.Throw().IfEmpty();

        var server = configuration.GetSection("ServerUrl").Value;

        if (string.IsNullOrEmpty(server)) throw new InvalidOperationException("Servidor no encontrado");

        if (server.Contains('/')) server = server.Remove(server.IndexOf('/'));

        return $"https://{server}/{ubicacion}?t={token}&{param}";
    }
}