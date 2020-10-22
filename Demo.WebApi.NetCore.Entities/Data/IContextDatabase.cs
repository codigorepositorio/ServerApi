using Demo.WebApi.NetCore.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.WebApi.NetCore.Entities
{
    public interface IContextDatabase 
    {        
        DbSet<Product> Product { get; set; }
        DbSet<Category> Category { get; set; }    

    }
}
