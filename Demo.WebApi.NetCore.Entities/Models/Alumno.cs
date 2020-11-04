using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.WebApi.NetCore.Entities.Models
{
    [Table("Alumno")]
    public class Alumno
    {
        [Key]
        public int AlumnoID { get; set; }
        public string Nombres { get; set; }
        [Column("decimal(2,2)")]
        public decimal ExamenParcial { get; set; }
        [Column("decimal(2,2)")]
        public decimal ExamenTrabajo { get; set; }
        [Column("decimal(2,2)")]
        public decimal ExamenFinal { get; set; }
        [Column("decimal(2,2)")]
        public decimal PromedioFinal { get; set; }
    }
}
