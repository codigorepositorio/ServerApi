using Demo.WebApi.NetCore.Dto.DataTransferObjects.Alumno;
using System;

namespace Demo.WebApi.NetCore.Bussiness.Logic.Services
{
    public class ServiceAlumnoBL : IServiceAlumnoBL
    {
        public decimal CalculaPromedio(AlumnoForCreation alumno)
        {
            var calculaProm = (alumno.notaExamenFinal + alumno.notaExamenParcial + alumno.notaTrabajos) / 3;
            var n1 = alumno.notaExamenFinal = ((calculaProm * 45) / 100);
            var n2 = alumno.notaExamenParcial = (calculaProm * 35) / 100;
            var n3 = alumno.notaTrabajos = (calculaProm * 20) / 100;
            var pf = n1 + n2 + n3;
            alumno.resultadoFinal = pf;
            return alumno.resultadoFinal;
        }

        public string ResultadoFinal(string alumno, decimal promedio)
        {
            string mensaje = RedondearPromedio(promedio) < 7 ? alumno + ": " + "Desaprobado : " + RedondearPromedio(promedio).ToString() :
                alumno + ": " + "Aprobado : " + RedondearPromedio(promedio).ToString();
            
            return mensaje;
        }

        private decimal RedondearPromedio(decimal promedio) =>  Math.Round(promedio, 2);

        private (bool IsValid, string ErrorMessage) TuplasRedondearPromedio(DateTime? DateOfEvaluation)
        {
            if (!DateOfEvaluation.HasValue)
                return (IsValid: false, ErrorMessage: "Debe de ingresar un valor");

            if ((DateOfEvaluation.Value.DayOfWeek == DayOfWeek.Saturday) || (DateOfEvaluation.Value.DayOfWeek == DayOfWeek.Sunday))
                return (false, "No se pueden realizar operaciones los fines de semana");            

            return (true, string.Empty);
        }

    }
}
