using Demo.WebApi.NetCore.Contracts;
using Demo.WebApi.NetCore.Entities;
using Demo.WebApi.NetCore.Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace Demo.WebApi.NetCore.Repository
{
    public class VentaRepository : IVentaRepository
    {
        private readonly ContextDatabase _contextDatabase;
        public VentaRepository(ContextDatabase contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }

        public bool Create(Venta venta,DetalleVenta detalleventa)
        {
            try
            {
                if (venta.ventaId == 0)                
                    _contextDatabase.Venta.Add(venta);                
                else               
                    _contextDatabase.Entry(venta).State = EntityState.Modified;
                
                foreach (var item in venta.DetalleVenta)
                {
                    if (item.DetalleVentaId == 0)                    
                       _contextDatabase.DetalleVenta.Add(item);                    
                    else
                        _contextDatabase.Entry(item).State = EntityState.Modified;                    
                }

                foreach (var item in detalleventa.SubDetalleVenta)
                {
                    if (item.DetalleVentaId == 0)
                        _contextDatabase.SubDetalleVenta.Add(item);
                    else
                        _contextDatabase.Entry(item).State = EntityState.Modified;
                }
                _contextDatabase.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }            
        }
    }
}
