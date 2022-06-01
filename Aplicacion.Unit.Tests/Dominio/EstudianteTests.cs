using Aplicacion.Dominio;

namespace Aplicacion.Unit.Tests.Dominio;

public class EstudianteTests
{
    [Fact]
    public void ObtenerEdad_RetornaEdad()
    {
        EstudianteCurso sut = new() { Edad = 1 };

        var resultado = sut.Edad;

        Assert.Equal(1, resultado);
    }

    [Fact]
    public void CambiarEdad_RetornaEdad()
    {
        EstudianteCurso sut = new()
        {
            Edad = 5
        };

        Assert.Equal(5, sut.Edad);
    }

    [Fact]
    public void ObtenerNombres_RetornaNombres()
    {
        EstudianteCurso sut = new() { Nombres = "Freddy" };

        var resultado = sut.Nombres;

        Assert.Equal("Freddy", resultado);
    }

    [Fact]
    public void CambiarNombres_RetornaNombres()
    {
        EstudianteCurso sut = new()
        {
            Nombres = "Freddy"
        };

        Assert.Equal("Freddy", sut.Nombres);
    }

    [Fact]
    public void ObtenerApellidos_RetornaApellidos()
    {
        EstudianteCurso sut = new() { Apellidos = "Alarc�n" };

        var resultado = sut.Apellidos;

        Assert.Equal("Alarc�n", resultado);
    }

    [Fact]
    public void CambiarApellidos_RetornaApellidos()
    {
        EstudianteCurso sut = new()
        {
            Apellidos = "Alarc�n"
        };

        Assert.Equal("Alarc�n", sut.Apellidos);
    }

    [Fact]
    public void ObtenerNombreCompleto_RetornaNombreCompleto()
    {
        EstudianteCurso sut = new() { Nombres = "Freddy", Apellidos = "Alarc�n" };

        var resultado = sut.NombreCompleto;

        Assert.Equal("Alarc�n, Freddy", resultado);
    }

    [Fact]
    public void ObtenerNombreCompleto_SinApellido_RetornaNombres()
    {
        EstudianteCurso sut = new() { Nombres = "Freddy" };

        var resultado = sut.NombreCompleto;

        Assert.Equal("Freddy", resultado);
    }

    [Fact]
    public void ObtenerNombreCompleto_SinNombre_RetornaApellidos()
    {
        EstudianteCurso sut = new() { Apellidos = "Alarc�n" };

        var resultado = sut.NombreCompleto;

        Assert.Equal("Alarc�n", resultado);
    }

    [Fact]
    public void ObtenerNombreCompleto_SinNombreSinApellido_RetornaVacio()
    {
        EstudianteCurso sut = new();

        var resultado = sut.NombreCompleto;

        Assert.Equal(string.Empty, resultado);
    }
}