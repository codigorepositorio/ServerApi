using Demo.WebApi.NetCore.Contracts;
using Demo.WebApi.NetCore.Entities;
using Demo.WebApi.NetCore.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace Demo.WebApi.NetCore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ContextDatabase _contextDatabase;
        public ProductRepository(ContextDatabase contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }
        public async Task<IEnumerable<Product>> GetAllProduct() =>
            await _contextDatabase.Product
            .Include(c => c.category)
            .AsNoTracking()
            .ToListAsync();
        public async Task<Product> GetProductById(int Id) =>
        await _contextDatabase.Product
              .Include(c => c.category)
             .Where(p => p.ProductID.Equals(Id))
              .AsNoTracking()
             .SingleOrDefaultAsync();

        public bool Create(Product product)
        {
            _contextDatabase.Product.Add(product);            
            return true;
        }
        public bool Update(Product product)
        {
            _contextDatabase.Product.Update(product);            
            return true;
        }

        public bool Delete(Product product)
        {
            _contextDatabase.Product.Remove(product);            
            return true;
        }

    }
}
