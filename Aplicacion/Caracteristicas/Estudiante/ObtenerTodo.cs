﻿using Aplicacion.Dominio.Entidades;
using Aplicacion.Persistencia;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Aplicacion.Caracteristicas.Estudiante;

public class ObtenerTodo
{
    public interface IObtenerTodo
    {
        IReadOnlyCollection<Respuesta> Ejecutar();
    }

    public class Handler : IObtenerTodo
    {
        private readonly IContextoBD contexto;
        private readonly IMapper mapper;

        public Handler(IContextoBD contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        public IReadOnlyCollection<Respuesta> Ejecutar()
        {
            return contexto.Estudiantes
                .ProjectTo<Respuesta>(mapper.ConfigurationProvider).ToList();
        }
    }

    public class MapRespuesta : Profile
    {
        public MapRespuesta()
        {
            CreateMap<Estudiantes, Respuesta>();
        }
    }

    public record Respuesta(string Id, string NombreCompleto);
}