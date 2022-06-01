using Aplicacion.Caracteristicas.Estudiante;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class EstudiantesController : ControllerBase
{
    private readonly IMediator mediator;

    public EstudiantesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IReadOnlyCollection<ObtenerTodo.Respuesta>> GetAll()
    {
        return await mediator.Send(new ObtenerTodo.Consulta());
    }

    [HttpGet("{id:int}")]
    public async Task<ObtenerPorId.Respuesta> GetById(int id)
    {
        return await mediator.Send(new ObtenerPorId.Consulta(id));
    }

    [HttpDelete("{id:int}")]
    public async Task<int> RemoveById(int id)
    {
        return await mediator.Send(new Eliminar.Comando(id));
    }

    [HttpPut("comando")]
    public async Task<int> Add(Insertar.Comando comando)
    {
        return await mediator.Send(comando);
    }

    [HttpPut("comando")]
    public async Task<int> Add(Editar.Comando comando)
    {
        return await mediator.Send(comando);
    }
}