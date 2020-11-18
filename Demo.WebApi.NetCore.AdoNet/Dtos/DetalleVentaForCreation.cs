using System.Collections.Generic;

namespace Demo.WebApi.NetCore.AdoNet.Dtos
{    
    public class DetalleVentaForCreation
    {                
        public int DetalleVentaId { get; set; }        
        public int ventaId { get; set; }
        public string Producto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        
    }
}