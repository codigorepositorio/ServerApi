using System.Collections.Generic;
namespace Demo.WebApi.NetCore.AdoNet.Models
{
    public class Venta
    {
        public int VentaId { get; set; }
        public string Cliente { get; set; }
        public decimal ImporteTotal { get; set; }
        public  ICollection<DetalleVenta> DetalleVenta { get; set; } 
    }
}

