using Aplicacion.Caracteristicas.Estudiantes;
using Aplicacion.Dominio;
using Aplicacion.Infraestructura;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddAplicacion();

builder.Services.AddScoped<IList<Estudiante>, List<Estudiante>>();
builder.Services.AddScoped<IContextoBD, ContextoEscuela>();
builder.Services.AddScoped<IObtenerPorId, ObtenerPorId>();
builder.Services.AddScoped<ObtenerTodo.IObtenerTodo, ObtenerTodo.Handler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();