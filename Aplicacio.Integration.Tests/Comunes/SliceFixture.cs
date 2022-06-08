using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Respawn;

namespace Aplicacio.Integration.Tests.Comunes;

public partial class SliceFixture : IAsyncLifetime
{
    private readonly Checkpoint checkpoint;
    private readonly IConfiguration configuration;

    private readonly WebApplicationFactory<Program> factory;
    private readonly IServiceScopeFactory scopeFactory;

    public SliceFixture()
    {
        factory = new AplicacionFactory();

        configuration = factory.Services.GetRequiredService<IConfiguration>();
        scopeFactory = factory.Services.GetRequiredService<IServiceScopeFactory>();

        checkpoint = new Checkpoint();
    }

    public Task InitializeAsync()
    {
        return checkpoint.Reset(configuration.GetConnectionString("DefaultTestConnection"));
    }

    public Task DisposeAsync()
    {
        factory?.Dispose();
        return Task.CompletedTask;
    }

    public Task ResetCheckpoint()
    {
        return checkpoint.Reset(configuration.GetConnectionString("DefaultTestConnection"));
    }

    private class AplicacionFactory
        : WebApplicationFactory<Program>
    {
        private const string CONNECTION_STRING =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Curso2022;Integrated Security=True";

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((_, configBuilder) =>
            {
                configBuilder.AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "ConnectionStrings:DefaultTestConnection", CONNECTION_STRING }
                });
            });
        }
    }
}