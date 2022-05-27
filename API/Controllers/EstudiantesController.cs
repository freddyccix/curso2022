using Aplicacion.Caracteristicas.Estudiantes;
using Aplicacion.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class EstudiantesController : ControllerBase
{
    private readonly IObtenerPorId operacionObtenerPorId;
    private readonly ObtenerTodo.IObtenerTodo operacionObtenerTodo;

    public EstudiantesController(ObtenerTodo.IObtenerTodo operacionObtenerTodo, IObtenerPorId operacionObtenerPorId)
    {
        this.operacionObtenerTodo = operacionObtenerTodo;
        this.operacionObtenerPorId = operacionObtenerPorId;
    }

    [HttpGet]
    public IEnumerable<ObtenerTodo.EstudianteDTO> GetAll()
    {
        return operacionObtenerTodo.Ejecutar();
    }

    [HttpGet("{id:int}")]
    public Estudiante GetById(int id)
    {
        return operacionObtenerPorId.Ejecutar(id);
    }
}