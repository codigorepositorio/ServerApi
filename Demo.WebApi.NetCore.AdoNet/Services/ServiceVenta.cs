using Demo.WebApi.NetCore.AdoNet.Dtos;
using Demo.WebApi.NetCore.AdoNet.Interfaz;
using Demo.WebApi.NetCore.AdoNet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.WebApi.NetCore.AdoNet.Services
{
    public class ServiceVenta
    {
        private readonly IRepositoryVenta _repositoryVenta;
        //_invoiceService.Pay(new Model.Invoice()
        //{
        //    IdInvoice = request.IdInvoice,
        //    Amount = entityInvoice.Amount,
        //    State = "PAGADO"
        //});
        public ServiceVenta(IRepositoryVenta repositoryVenta)
        {
            _repositoryVenta = repositoryVenta;
        }

        public async Task<VentaForCreation> Create(VentaForCreation ventaForCreation)
        {
            var entity = new Venta()
            {
                VentaId = ventaForCreation.codigoVenta,
                Cliente = ventaForCreation.clienteVenta,
                ImporteTotal = ventaForCreation.totalVenta
            };

            var resultEnity = await _repositoryVenta.Create(entity);   
            
            ventaForCreation.codigoVenta = resultEnity.VentaId;
            ventaForCreation.clienteVenta = resultEnity.Cliente; ;
            ventaForCreation.totalVenta =resultEnity.ImporteTotal;       
            
            return ventaForCreation;
        }

        public async Task<List<DetalleVenta>> CreateDetalle(List<DetalleVenta> detalleVentas)
        {
            return await _repositoryVenta.CreateDetalle(detalleVentas);
        }
    }
}
