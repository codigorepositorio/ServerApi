using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.WebApi.NetCore.Entities.Models
{
    [Table("SubDetalleVenta")]
    public class SubDetalleVenta
    {        
        [Key]
        public int SubDetalleVentaId { get; set; }

        [ForeignKey(nameof(DetalleVenta))]
        public int DetalleVentaId { get; set; }
        public string Descripcion { get; set; }

    }
}