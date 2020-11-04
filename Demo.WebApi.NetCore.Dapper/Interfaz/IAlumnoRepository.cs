using Demo.WebApi.NetCore.Entities.Models;
using System.Threading.Tasks;

namespace Demo.WebApi.NetCore.Dapper.Interfaz
{
    public   interface IAlumnoRepository
    {
        Task<Alumno> Create(Alumno alumno);
    }
}
