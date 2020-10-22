using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.WebApi.NetCore.Dto.DataTransferObjects.Product
{
    public class ProductDto
    {
        public int codigo { get; set; }
        public string producto { get; set; }
        public decimal precioUnitario { get; set; }
        public int stock { get; set; }
        public int idCategoria { get; set; }
        public string categoria { get; set; }

    }
}
