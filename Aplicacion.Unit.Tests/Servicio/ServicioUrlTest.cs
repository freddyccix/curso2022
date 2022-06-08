using Aplicacion.Servicio;
using Microsoft.Extensions.Configuration;
using Moq;
using Shouldly;

namespace Aplicacion.Unit.Tests.Servicio;

public class ServicioUrlTest
{
    [Fact]
    public void GenerarEnlace_DevuelveEnlace()
    {
        var mock = new Mock<IConfiguration>();

        mock.Setup(x => x.GetSection(It.IsAny<string>()).Value)
            .Returns("localhost");

        var sut = new MiServicioUrl(mock.Object);
        var url = sut.ObtenerUrl("token", "ubicacion", "parametros");

        url.ShouldBe("https://localhost/ubicacion?t=token&parametros");
    }

    [Fact]
    public void GenerarEnlace_DevuelveEnlaceSinSeparador()
    {
        var mock = new Mock<IConfiguration>();

        mock.Setup(x => x.GetSection(It.IsAny<string>()).Value)
            .Returns("localhost/");

        var sut = new MiServicioUrl(mock.Object);
        var url = sut.ObtenerUrl("token", "ubicacion", "parametros");

        url.ShouldBe("https://localhost/ubicacion?t=token&parametros");
    }

    [Fact]
    public void GenerarEnlace_Vacio_DevuelveExcepcion()
    {
        var mock = new Mock<IConfiguration>();

        mock.Setup(x => x.GetSection(It.IsAny<string>()).Value)
            .Returns(string.Empty);

        var sut = new MiServicioUrl(mock.Object);

        Should.Throw<InvalidOperationException>(() => sut.ObtenerUrl("token", "ubicacion", "parametros"));
    }

    [Fact]
    public void GenerarEnlace_TokenVacio_DevuelveExcepcion()
    {
        var mock = new Mock<IConfiguration>();

        var sut = new MiServicioUrl(mock.Object);

        Should.Throw<ArgumentException>(() => sut.ObtenerUrl(string.Empty, "ubicacion", "parametros"));
    }

    [Fact]
    public void GenerarEnlace_UbicacionVacia_DevuelveExcepcion()
    {
        var mock = new Mock<IConfiguration>();

        var sut = new MiServicioUrl(mock.Object);

        Should.Throw<ArgumentException>(() => sut.ObtenerUrl("token", string.Empty, "parametros"));
    }

    [Fact]
    public void GenerarEnlace_ParamVacio_DevuelveExcepcion()
    {
        var mock = new Mock<IConfiguration>();

        var sut = new MiServicioUrl(mock.Object);

        Should.Throw<ArgumentException>(() => sut.ObtenerUrl("token", "ubicacion", string.Empty));
    }
}