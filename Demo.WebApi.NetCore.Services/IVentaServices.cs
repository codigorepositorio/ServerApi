using Demo.WebApi.NetCore.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.WebApi.NetCore.Services
{
    public interface IVentaServices
    {
        bool Create(Venta venta,DetalleVenta detalleVenta);

    }
}
