﻿using Aplicacion.Caracteristicas.Estudiantes;
using Aplicacion.Dominio;
using Aplicacion.Infraestructura;
using Shouldly;

namespace Aplicacion.Unit.Tests.Caracteristicas.Estudiantes;

public class ObtenerTodoTests
{
    [Fact]
    public void ObtenerTodo_NoTraeNulo()
    {
        ObtenerTodo.Handler sut = new(new ContextoEscuela(new List<Estudiante>()));
        var listaResultado = sut.Ejecutar();

        listaResultado.ShouldNotBeNull();
        Assert.NotNull(listaResultado);
    }

    [Fact]
    public void ObtenerTodo_TraeTodo()
    {
        ContextoEscuela contexto = new(new List<Estudiante>());
        contexto.Estudiantes.Add(
            new Estudiante { Id = 1, Apellidos = "Alarcón", Nombres = "Freddy", Edad = 38 });

        ObtenerTodo.Handler sut = new(contexto);
        var listaResultado = sut.Ejecutar();

        listaResultado.ShouldNotBeEmpty();
    }

    [Fact]
    public void ObtenerTodo_ContarElementos()
    {
        ContextoEscuela contexto = new(new List<Estudiante>());
        contexto.Estudiantes.Add(
            new Estudiante { Id = 1, Apellidos = "Alarcón", Nombres = "Freddy", Edad = 38 }
        );
        contexto.Estudiantes.Add(
            new Estudiante { Id = 2, Apellidos = "Villamar", Nombres = "Xavier", Edad = 38 }
        );

        ObtenerTodo.Handler sut = new(contexto);
        var listaResultado = sut.Ejecutar();

        listaResultado.Count.ShouldBe(2);
    }
}