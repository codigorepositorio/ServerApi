
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.WebApi.NetCore.Entities.Models
{
    [Table("Product")]
  public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Nombre { get; set; }

        [Column(TypeName = "decimal(11,2)")]
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }
        public Category category { get; set; }
    }
}
