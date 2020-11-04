using Demo.WebApi.NetCore.Dapper.Interfaz;
using Demo.WebApi.NetCore.Dapper.Repository;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Demo.WebApi.NetCore.Dapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {        
        private readonly IConfiguration _configuration;
        public RepositoryWrapper(IConfiguration configuration)
        {            
            _configuration = configuration;
        }

        private IAlumnoRepository _alumnoRepository;
        private ICategoryRepository _categoriaRepository;
        public IAlumnoRepository Alumno
        {
            get
            {
                if (_alumnoRepository == null)
                {
                    _alumnoRepository = new AlumnoRepository(_configuration);
                }
                return _alumnoRepository;
            }
        }


        public ICategoryRepository Category
        {
            get
            {
                if (_categoriaRepository == null)
                {
                    _categoriaRepository = new CategoryRepository(_configuration);
                }
                return _categoriaRepository;
            }
        }
    }
}
