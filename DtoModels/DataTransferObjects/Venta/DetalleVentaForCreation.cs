using System.Collections.Generic;
namespace Demo.WebApi.NetCore.Dto.DataTransferObjects.Venta
{
    public class DetalleVentaForCreation
    {
        public int detalleVentaId { get; set; }
        public int ventaId { get; set; }
        public string Producto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public ICollection<SubDetalleVentaForCreation> subDetalleVenta  { get; set; }

    }
}