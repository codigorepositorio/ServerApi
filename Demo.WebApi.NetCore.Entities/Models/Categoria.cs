using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Demo.WebApi.NetCore.Entities.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}