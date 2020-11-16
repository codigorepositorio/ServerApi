using Demo.WebApi.NetCore.Dapper.Interfaz;

namespace Demo.WebApi.NetCore.Dapper
{
    public interface IRepositoryWrapper
    {
        IAlumnoRepository Alumno { get; }
        ICategoryRepository Category { get; }


    }
}
