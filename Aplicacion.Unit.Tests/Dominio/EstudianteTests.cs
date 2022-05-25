using Aplicacion.Dominio;

namespace Aplicacion.Unit.Tests.Dominio;

public class EstudianteTests
{
    [Fact]
    public void ObtenerEdad_RetornaEdad()
    {
        Estudiante sut = new() { Edad = 1 };

        var resultado = sut.Edad;

        Assert.Equal(1, resultado);
    }

    [Fact]
    public void CambiarEdad_RetornaEdad()
    {
        Estudiante sut = new()
        {
            Edad = 5
        };

        Assert.Equal(5, sut.Edad);
    }

    [Fact]
    public void ObtenerNombres_RetornaNombres()
    {
        Estudiante sut = new() { Nombres = "Freddy" };

        var resultado = sut.Nombres;

        Assert.Equal("Freddy", resultado);
    }

    [Fact]
    public void CambiarNombres_RetornaNombres()
    {
        Estudiante sut = new()
        {
            Nombres = "Freddy"
        };

        Assert.Equal("Freddy", sut.Nombres);
    }

    [Fact]
    public void ObtenerApellidos_RetornaApellidos()
    {
        Estudiante sut = new() { Apellidos = "Alarcón" };

        var resultado = sut.Apellidos;

        Assert.Equal("Alarcón", resultado);
    }

    [Fact]
    public void CambiarApellidos_RetornaApellidos()
    {
        Estudiante sut = new()
        {
            Apellidos = "Alarcón"
        };

        Assert.Equal("Alarcón", sut.Apellidos);
    }

    [Fact]
    public void ObtenerNombreCompleto_RetornaNombreCompleto()
    {
        Estudiante sut = new() { Nombres = "Freddy", Apellidos = "Alarcón" };

        var resultado = sut.NombreCompleto;

        Assert.Equal("Alarcón, Freddy", resultado);
    }

    [Fact]
    public void ObtenerNombreCompleto_SinApellido_RetornaNombres()
    {
        Estudiante sut = new() { Nombres = "Freddy" };

        var resultado = sut.NombreCompleto;

        Assert.Equal("Freddy", resultado);
    }

    [Fact]
    public void ObtenerNombreCompleto_SinNombre_RetornaApellidos()
    {
        Estudiante sut = new() { Apellidos = "Alarcón" };

        var resultado = sut.NombreCompleto;

        Assert.Equal("Alarcón", resultado);
    }

    [Fact]
    public void ObtenerNombreCompleto_SinNombreSinApellido_RetornaVacio()
    {
        Estudiante sut = new();

        var resultado = sut.NombreCompleto;

        Assert.Equal(string.Empty, resultado);
    }
}