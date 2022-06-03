using Aplicacion.Dominio.Entidades;
using Shouldly;

namespace Aplicacion.Unit.Tests.Dominio;

public class EstudianteTests
{
    [Fact]
    public void ObtenerEdad_RetornaEdadMesPosterior()
    {
        Estudiantes sut = new() { FechaNacimiento = new DateTime(1983, 8, 16) };

        var resultado = sut.Edad;

        resultado.ShouldBe(38);
    }

    [Fact]
    public void ObtenerEdad_RetornaEdadMesAnterior()
    {
        Estudiantes sut = new() { FechaNacimiento = new DateTime(1983, 5, 16) };

        var resultado = sut.Edad;

        resultado.ShouldBe(39);
    }

    [Fact]
    public void ObtenerEdad_FechaNula_RetornaCero()
    {
        Estudiantes sut = new();

        var resultado = sut.Edad;

        resultado.ShouldBe(-1);
    }

    [Fact]
    public void ObtenerNombres_RetornaNombres()
    {
        Estudiantes sut = new() { Nombres = "Freddy" };

        var resultado = sut.Nombres;

        Assert.Equal("Freddy", resultado);
    }

    [Fact]
    public void CambiarNombres_RetornaNombres()
    {
        Estudiantes sut = new()
        {
            Nombres = "Freddy"
        };

        Assert.Equal("Freddy", sut.Nombres);
    }

    [Fact]
    public void ObtenerApellidos_RetornaApellidos()
    {
        Estudiantes sut = new() { Apellidos = "Alarcón" };

        var resultado = sut.Apellidos;

        Assert.Equal("Alarcón", resultado);
    }

    [Fact]
    public void CambiarApellidos_RetornaApellidos()
    {
        Estudiantes sut = new()
        {
            Apellidos = "Alarcón"
        };

        Assert.Equal("Alarcón", sut.Apellidos);
    }

    [Fact]
    public void ObtenerNombreCompleto_RetornaNombreCompleto()
    {
        Estudiantes sut = new() { Nombres = "Freddy", Apellidos = "Alarcón" };

        var resultado = sut.NombreCompleto;

        Assert.Equal("Alarcón, Freddy", resultado);
    }

    [Fact]
    public void ObtenerNombreCompleto_SinApellido_RetornaNombres()
    {
        Estudiantes sut = new() { Nombres = "Freddy" };

        var resultado = sut.NombreCompleto;

        Assert.Equal("Freddy", resultado);
    }

    [Fact]
    public void ObtenerNombreCompleto_SinNombre_RetornaApellidos()
    {
        Estudiantes sut = new() { Apellidos = "Alarcón" };

        var resultado = sut.NombreCompleto;

        Assert.Equal("Alarcón", resultado);
    }

    [Fact]
    public void ObtenerNombreCompleto_SinNombreSinApellido_RetornaVacio()
    {
        Estudiantes sut = new();

        var resultado = sut.NombreCompleto;

        Assert.Equal(string.Empty, resultado);
    }

    [Fact]
    public void ObtenerId_RetornaId()
    {
        Estudiantes sut = new() { Id = 3 };

        var resultado = sut.Id;

        Assert.Equal(3, resultado);
    }
}