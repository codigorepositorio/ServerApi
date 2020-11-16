using AutoMapper;
using Demo.WebApi.NetCore.Entities.Models;
using Demo.WebApi.NetCore.Dapper.Interfaz;
using System.Threading.Tasks;
using Demo.WebApi.NetCore.Dto.DataTransferObjects.Alumno;
using Demo.WebApi.NetCore.Dapper;

namespace Demo.WebApi.NetCore.Dto
{
    public class AlumnoService
    {
    
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public AlumnoService(IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;         
        }


        public async Task<Alumno> Create(AlumnoForCreation alumnoForCreation)
        {         
           var alumnotEntity = _mapper.Map<Alumno>(alumnoForCreation);
           return  await _repositoryWrapper.Alumno.Create(alumnotEntity);
        }

    }
}
