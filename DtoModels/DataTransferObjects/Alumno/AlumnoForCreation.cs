using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.WebApi.NetCore.Dto.DataTransferObjects.Alumno
{
 public   class AlumnoForCreation
    {
        public string alumno { get; set; }
        public decimal notaExamenFinal { get; set; }
        public decimal notaExamenParcial { get; set; }
        public decimal notaTrabajos { get; set; }
        public decimal resultadoFinal { get; set; }
       public string estado { get; set; }
    }
}
