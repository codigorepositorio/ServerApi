using Demo.WebApi.NetCore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.WebApi.NetCore.Contracts
{
   public interface IVentaRepository
    {
        bool Create(Venta venta,DetalleVenta detalleventa);
    }
}
