using Demo.WebApi.NetCore.Entities.Models;
using System.Collections.Generic;

namespace Demo.WebApi.NetCore.Dapper.Interfaz
{
    public interface IAlumnoService
    {
        Product Save(Product product);
        List<Product> Gets();
        Product Get(int productId);
        string Delete(int productId);
    }
}
