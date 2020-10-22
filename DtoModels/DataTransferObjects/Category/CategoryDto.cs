using Demo.WebApi.NetCore.Dto.DataTransferObjects.Product;
using System.Collections.Generic;

namespace Demo.WebApi.NetCore.Dto.DataTransferObjects.Category
{
    public class CategoryDto
    {
        public int Codigo { get; set; }
        public string Categoria { get; set; }
        public bool Condicion { get; set; }
        public ICollection<ProductDto> product { get; set; }
    }
}
