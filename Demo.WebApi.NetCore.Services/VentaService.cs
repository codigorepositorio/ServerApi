using Demo.WebApi.NetCore.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.WebApi.NetCore.Contracts;

namespace Demo.WebApi.NetCore.Services
{
    public class VentaServices : IVentaServices
    {
        private readonly IVentaRepository _ventaRepository;
        public VentaServices(IVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;

        }
          
        public bool Create(Venta  venta,DetalleVenta detalleVenta)=> _ventaRepository.Create(venta, detalleVenta);
        

    }
}
