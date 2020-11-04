using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Demo.WebApi.NetCore.Bussiness.Logic.Services;
using Demo.WebApi.NetCore.Dto;
using Demo.WebApi.NetCore.Dto.DataTransferObjects.Alumno;
using Demo.WebApi.NetCore.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebApi.NetCore.Apis.Controllers
{
    [Route("api/Alumnos")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServiceAlumnoBL _serviceAlumnoBL;
        private readonly AlumnoService _serviceAlumno;

        public AlumnosController(IMapper mapper, IServiceAlumnoBL serviceAlumnoBL, AlumnoService serviceAlumno)
        {
            _mapper = mapper;
            _serviceAlumnoBL = serviceAlumnoBL;
            _serviceAlumno = serviceAlumno;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] AlumnoForCreation alumnoForCreation)
        {

            _serviceAlumnoBL.CalculaPromedio(alumnoForCreation);
           var estado= _serviceAlumnoBL.ResultadoFinal(alumnoForCreation.alumno, alumnoForCreation.resultadoFinal);
            alumnoForCreation.estado = estado;
            var result = await _serviceAlumno.Create(alumnoForCreation);
           return Ok(result);
        }
    }
}
