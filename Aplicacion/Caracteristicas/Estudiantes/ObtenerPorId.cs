﻿using Aplicacion.Dominio;
using Aplicacion.Infraestructura;
using AutoMapper;

namespace Aplicacion.Caracteristicas.Estudiantes;

public class ObtenerPorId
{
    public interface IObtenerPorId
    {
        Respuesta Ejecutar(int? id);
    }

    public class Handler : IObtenerPorId
    {
        private readonly IContextoBD contexto;
        private readonly IMapper mapper;

        public Handler(IContextoBD contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        public Respuesta? Ejecutar(int? id)
        {
            var estudianteBase = contexto.Estudiantes
                .FirstOrDefault(x => x.Id == id);
            return mapper.Map<Respuesta>(estudianteBase);
        }

        public class MapRespuesta : Profile
        {
            public MapRespuesta()
            {
                CreateMap<Estudiante, Respuesta>();
            }
        }
    }

    public record Respuesta(string Id, string Nombres, string Apellidos, string Edad);
}