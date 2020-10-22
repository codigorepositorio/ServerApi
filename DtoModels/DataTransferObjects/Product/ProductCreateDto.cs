namespace Demo.WebApi.NetCore.Dto.DataTransferObjects.Product
{
    public class ProductCreateDto
    {        
        public string producto { get; set; }
        public decimal precioUnitario { get; set; }
        public int stock { get; set; }
        public int idCategoria { get; set; }        
    }
}
