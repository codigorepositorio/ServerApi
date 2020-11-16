using System;
using System.Collections.Generic;
using System.Text;


namespace Demo.WebApi.NetCore.Dto.DataTransferObjects.Venta
{
    public class VentaForCreation
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public decimal ImporteTotal { get; set; }
        public ICollection<DetalleVentaForCreation> detalleVentas { get; set; } 
    }
}

