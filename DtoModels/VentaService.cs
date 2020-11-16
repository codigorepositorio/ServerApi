using AutoMapper;
using Demo.WebApi.NetCore.Entities.Models;
using Demo.WebApi.NetCore.Dapper.Interfaz;
using Demo.WebApi.NetCore.Dto.DataTransferObjects.Category;
using System.Threading.Tasks;
using System.Collections.Generic;
using Demo.WebApi.NetCore.Dapper;
using Demo.WebApi.NetCore.Dto.DataTransferObjects.Venta;
using Demo.WebApi.NetCore.Services;

namespace Demo.WebApi.NetCore.Dto
{
    public class VentaService
    {
        private readonly IVentaServices _ventaServices;
        private readonly IMapper _mapper;
        

        public VentaService(IVentaServices ventaServices, IMapper mapper)
        {
            _ventaServices = ventaServices;
            _mapper = mapper;
        }



        public bool Create(VentaForCreation ventaForCreation, DetalleVentaForCreation detalleVenta)
        {
            var ventatEntity = _mapper.Map<Venta>(ventaForCreation);

            var detalleVentaEntity = _mapper.Map<DetalleVenta>(detalleVenta);

            var category =  _ventaServices.Create(ventatEntity, detalleVentaEntity);            

            return category;
        }

        
    }
}

