using Aplicacion.Caracteristicas.Estudiantes;
using Aplicacion.Dominio;
using Aplicacion.Infraestructura;
using Shouldly;

namespace Aplicacion.Unit.Tests.Caracteristicas.Estudiantes;

public class ObteneePorIdTests
{
    [Fact]
    public void ObtenerPorId_TraeUnValor()
    {
        var contexto = new ContextoEscuela(new List<Estudiante>());
        contexto.Estudiantes.Add(
            new Estudiante { Id = 1, Apellidos = "Alarcón", Nombres = "Freddy", Edad = 38 }
        );
        contexto.Estudiantes.Add(
            new Estudiante { Id = 2, Apellidos = "Villamar", Nombres = "Xavier", Edad = 38 }
        );
        ObtenerPorId sut = new(contexto);

        var resultado = sut.Ejecutar(2);

        resultado.ShouldNotBeNull();
        resultado.Apellidos.ShouldBe("Villamar");
    }

    [Fact]
    public void ObtenerId_EstudianteNoExiste_DevuelveNulo()
    {
        var contexto = new ContextoEscuela(new List<Estudiante>());
        contexto.Estudiantes.Add(
            new Estudiante { Id = 1, Apellidos = "Alarcón", Nombres = "Freddy", Edad = 38 }
        );
        contexto.Estudiantes.Add(
            new Estudiante { Id = 2, Apellidos = "Villamar", Nombres = "Xavier", Edad = 38 }
        );
        ObtenerPorId sut = new(contexto);

        var resultado = sut.Ejecutar(3);

        resultado.ShouldBeNull();
    }
}