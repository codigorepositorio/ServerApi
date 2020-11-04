using AutoMapper;
using Demo.WebApi.NetCore.Dto.DataTransferObjects.Product;
using Demo.WebApi.NetCore.Entities.Models;
using Demo.WebApi.NetCore.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Demo.WebApi.NetCore.Dto
{
    public class ProductService
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public ProductService(IProductServices productServices, IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var productEntity = await _productServices.GetAllProduct();
            if (productEntity == null)
                return null;
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productEntity);
            return productsDto;
        }

        public async Task<ProductDto> GetProductById(int Id)
        {
            var productIdEntity = await _productServices.GetProductById(Id);
            if (productIdEntity == null)
                return null;
            var productsDto = _mapper.Map<ProductDto>(productIdEntity);
            return productsDto;
        }


        public bool CreateProduct(ProductCreateDto productDto)
        {
            if (productDto == null)
                return false;
            var productEntity = _mapper.Map<Product>(productDto);
            _productServices.Create(productEntity);
            return true;
        }
        public async Task<IActionResult> UpdateProduct(int Id,ProductUpdateDto productDto)
        {            
            var product = await _productServices.GetProductById(Id);

            if (product == null)
                return new BadRequestObjectResult ($"Producto No existe: {Id}");

            if (productDto == null)
              return  new UnprocessableEntityObjectResult(productDto);

            var productEntity = _mapper.Map<Product>(productDto);
            _productServices.Update(productEntity);
            return new OkObjectResult("Ok");
        }


        public async Task<bool> DeleteProduct(int Id)
        {
            var productEntity = await _productServices.GetProductById(Id);
            if (productEntity == null)
                return false;
            _productServices.Delete(productEntity);
            return true;
        }

    }
}
