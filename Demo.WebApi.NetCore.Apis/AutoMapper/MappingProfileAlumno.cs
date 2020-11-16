using AutoMapper;
using Demo.WebApi.NetCore.Dto.DataTransferObjects.Alumno;
using Demo.WebApi.NetCore.Entities.Models;
using System;

namespace Demo.WebApi.NetCore.Apis.AutoMapper
{
    public class MappingProfileAlumno : Profile
    {

        public MappingProfileAlumno()
        {
            //POST: CategoryForCreation                    
            CreateMap<AlumnoForCreation, Alumno>()
            .ForMember(a => a.Nombres, opt => opt.MapFrom(b => b.alumno))
            .ForMember(a => a.ExamenParcial, opt => opt.MapFrom(b => Math.Round(b.notaExamenParcial, 2)))
            .ForMember(a => a.ExamenTrabajo, opt => opt.MapFrom(b => Math.Round(b.notaTrabajos, 2)))
            .ForMember(a => a.ExamenFinal, opt => opt.MapFrom(b => Math.Round(b.notaExamenFinal, 2)))
            .ForMember(a => a.PromedioFinal, opt => opt.MapFrom(b => Math.Round(b.resultadoFinal, 2)));

        }


    }
}
