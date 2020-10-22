
namespace DtoModels.DataTransferObjects.Product
{
    public class ProductDto
    {
        public int Codigo { get; set; }
        public string Producto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; }
        public int IdCategoria { get; set; }
        
    }
}
