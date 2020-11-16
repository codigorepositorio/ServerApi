using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.WebApi.NetCore.Entities.Models
{
    [Table("Venta")]
    public class Venta
    {

        [Key]
        public int ventaId { get; set; }
        public string Cliente { get; set; }
        public decimal ImporteTotal { get; set; }
        public  ICollection<DetalleVenta> DetalleVenta { get; set; } 
    }
}

