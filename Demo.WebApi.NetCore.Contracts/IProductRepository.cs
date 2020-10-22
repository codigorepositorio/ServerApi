using Demo.WebApi.NetCore.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.WebApi.NetCore.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> GetProductById(int Id);
        bool Create(Product product);
        bool Update(Product product);
        bool Delete(Product product);
    }
}

