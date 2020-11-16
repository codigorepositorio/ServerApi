using Demo.WebApi.NetCore.Contracts;
using Demo.WebApi.NetCore.Entities;
using System.Threading.Tasks;

namespace Demo.WebApi.NetCore.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private ContextDatabase _repositoryContext;
        private IProductRepository _productRepository;

        private IVentaRepository _ventaRepository;
        public RepositoryManager(ContextDatabase repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IProductRepository Product
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_repositoryContext);
                }
                return _productRepository;
            }
        }

        public IVentaRepository Venta
        {
            get
            {
                if (_ventaRepository == null)
                {
                    _ventaRepository = new VentaRepository(_repositoryContext);
                }
                return _ventaRepository;
            }
        }

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

      
    }
}
