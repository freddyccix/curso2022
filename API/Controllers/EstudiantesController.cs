using Aplicacion.Caracteristicas.Estudiantes;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class EstudiantesController : ControllerBase
{
    private readonly ObtenerPorId.IObtenerPorId operacionObtenerPorId;
    private readonly ObtenerTodo.IObtenerTodo operacionObtenerTodo;

    public EstudiantesController(
        ObtenerTodo.IObtenerTodo operacionObtenerTodo,
        ObtenerPorId.IObtenerPorId operacionObtenerPorId)
    {
        this.operacionObtenerTodo = operacionObtenerTodo;
        this.operacionObtenerPorId = operacionObtenerPorId;
    }

    [HttpGet]
    public IEnumerable<ObtenerTodo.Respuesta> GetAll()
    {
        return operacionObtenerTodo.Ejecutar();
    }

    [HttpGet("{id:int}")]
    public ObtenerPorId.Respuesta GetById(int id)
    {
        return operacionObtenerPorId.Ejecutar(id);
    }
}