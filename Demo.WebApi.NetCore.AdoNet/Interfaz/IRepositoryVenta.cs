using Demo.WebApi.NetCore.AdoNet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.WebApi.NetCore.AdoNet.Interfaz
{
   public interface IRepositoryVenta
    {
         Task<Venta> Create(Venta venta);

        Task<List<DetalleVenta>> CreateDetalle(List<DetalleVenta> detalleVenta);
    }
}
