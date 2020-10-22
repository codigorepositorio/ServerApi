using AutoMapper;
using Demo.WebApi.NetCore.Services;
using DtoModels.DataTransferObjects.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DtoModels
{
    public  class ProductService
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public ProductService(IProductServices productServices, IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProductAll()
        {
            var products = await _productServices.GetAllProduct();
            var articulosDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return articulosDto;
        }
    }
}
