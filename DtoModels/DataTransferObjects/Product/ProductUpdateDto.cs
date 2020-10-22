using System.ComponentModel.DataAnnotations;

namespace Demo.WebApi.NetCore.Dto.DataTransferObjects.Product
{
    public class ProductUpdateDto
    {
        [Required(ErrorMessage = "Codigo is requerid")]        
        public int codigo { get; set; }

        [Required(ErrorMessage = "Codigo is requerid")]
        public string producto { get; set; }

        [Required(ErrorMessage = "precioUnitario is requerid")]
        public decimal precioUnitario { get; set; }

        [Required(ErrorMessage = "stock is requerid")]
        public int stock { get; set; }

        [Required(ErrorMessage = "idCategoria is requerid")]
        public int idCategoria { get; set; }        
    }
}
