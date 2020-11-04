using Dapper;
using Demo.WebApi.NetCore.Dapper.Common;
using Demo.WebApi.NetCore.Dapper.Interfaz;
using Demo.WebApi.NetCore.Entities.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.WebApi.NetCore.Dapper.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbConnection dbConection;

        public CategoryRepository(IConfiguration configuration)
        {

            dbConection = new SqlConnection(configuration.GetConnectionString("cn-dapper"));
        }

        public async Task<List<Category>> GetAll()
        {
            var categories = await dbConection.QueryAsync<Category>("Select * from Category");
            return categories.ToList();

        }

        public async Task<Category> GetById(int categoryID)
        {
            var category = await dbConection
                .QuerySingleOrDefaultAsync<Category>("Select * from Category where categoryID = @categoryID", new { categoryID = categoryID });
            return category;
        }
        public async Task<Category> Create(Category category)
        {
            var sql = $"Insert into Category (Nombre,Estado) values(@Nombre,@Estado);" +
            "Select CAST(SCOPE_IDENTITY() AS INT)";

            var queryResult = await dbConection.QueryAsync<int>(sql, category);

            category.CategoryID = queryResult.FirstOrDefault();

            return category;
        }

        public async Task Delete(int categoryID)
        {
            
             dbConection.Open();
            await dbConection
                .ExecuteAsync("DELETE FROM Category WHERE categoryID = @categoryID", new { categoryID = categoryID });
        }


        public async Task Update(Category category)
        {
            var sql = $"UPDATE Category SET Nombre = @Nombre,Estado = @Estado WHERE CategoryID = @CategoryID";
            await dbConection.ExecuteAsync(sql, category);
        }
    }
}
