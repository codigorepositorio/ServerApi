
using Demo.WebApi.NetCore.Dto.DataTransferObjects.Alumno;

namespace Demo.WebApi.NetCore.Bussiness.Logic.Services
{
  public  interface IServiceAlumnoBL
    {
        decimal CalculaPromedio(AlumnoForCreation alumno);
        string ResultadoFinal(string alumno, decimal promedio);

    }
}
