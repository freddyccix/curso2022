using Aplicacio.Integration.Tests.Comunes;
using Aplicacion.Caracteristicas.Estudiante;
using Aplicacion.Dominio.Entidades;
using Bogus;
using Shouldly;

namespace Aplicacio.Integration.Tests.Caracteristicas.Estudiante;

[Collection(nameof(SliceFixture))]
public class ObtenerTodoTests
{
    private readonly SliceFixture fixture;

    public ObtenerTodoTests(SliceFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async void ObtenerTodosLosEstudiantes()
    {
        var numeroEstudiantes = 10;
        var estudiantes = FactoryEstudiantes.CrearEstudiantes(10);

        await fixture.InsertAsync(estudiantes); // grabar en la base

        var sut = await fixture.SendAsync(new ObtenerTodo.Consulta()); //igual  que el controlador

        //sut.ShouldBeOfType<IReadOnlyCollection<ObtenerTodo.Respuesta>>();

        sut.Count.ShouldBe(10);
    }
}

public static class FactoryEstudiantes
{
    public static List<Estudiantes> CrearEstudiantes(int numeroEstudiantes)
    {
        var listaRetorno = new List<Estudiantes>();
        for (var i = 0; i < numeroEstudiantes; i++) listaRetorno.Add(CrearEstudiante());

        return listaRetorno;
    }

    private static Estudiantes CrearEstudiante()
    {
        var estudiante = new Faker<Estudiantes>("es_MX")
            .RuleFor(x => x.Apellidos, y => y.Person.LastName)
            .RuleFor(x => x.Nombres, y => y.Person.FirstName)
            .RuleFor(x => x.Direccion, y => y.Person.Address.Street)
            .RuleFor(x => x.FechaNacimiento, y => y.Person.DateOfBirth);

        return estudiante.Generate();
    }
}