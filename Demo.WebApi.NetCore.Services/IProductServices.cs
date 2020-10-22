using Demo.WebApi.NetCore.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.WebApi.NetCore.Services
{
    public interface IProductServices
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> GetProductById(int Id);
        bool Create(Product product);
        bool Update(Product product);
        bool Delete(Product product);
    }
}
