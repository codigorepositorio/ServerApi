using Demo.WebApi.NetCore.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.WebApi.NetCore.Contracts;

namespace Demo.WebApi.NetCore.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;
        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
          
        public Task<IEnumerable<Product>> GetAllProduct() =>_productRepository.GetAllProduct();
        public Task<Product> GetProductById(int Id) =>_productRepository.GetProductById(Id);
        public bool Create(Product product)=> _productRepository.Create(product);
        public bool Update(Product product) => _productRepository.Update(product);
        public bool Delete(Product product) => _productRepository.Delete(product);

    }
}
