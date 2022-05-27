namespace Aplicacion.Dominio;

public class FactoryDominio<T> where T : class, new()
{
    public static T CrearScoped()
    {
        return new T();
    }
}