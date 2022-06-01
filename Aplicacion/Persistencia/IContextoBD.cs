using Aplicacion.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Persistencia;

public interface IContextoBD
{
    public DbSet<Estudiantes> Estudiantes { get; set; }
}