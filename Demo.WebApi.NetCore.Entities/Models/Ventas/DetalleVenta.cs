using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.WebApi.NetCore.Entities.Models
{
    [Table("DetalleVenta")]
    public class DetalleVenta
    {        
        [Key]
        public int DetalleVentaId { get; set; }
        [ForeignKey(nameof(Venta))]
        public int ventaId { get; set; }

        public string Producto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public ICollection<SubDetalleVenta> SubDetalleVenta { get; set; }
    }
}