
using Demo.WebApi.NetCore.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.WebApi.NetCore.Dapper.Interfaz
{
    public interface IDapperCategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<Category> GetById(int Id);
        Task<Category> Create(Category category);
        Task Update(Category category);
        Task Delete(int Id);


    }
}
