using AutoMapper;
using Demo.WebApi.NetCore.Dto.DataTransferObjects.Product;
using Demo.WebApi.NetCore.Dto.DataTransferObjects.Venta;
using Demo.WebApi.NetCore.Entities.Models;


namespace Demo.WebApi.NetCore.Apis.AutoMapper
{
    public class MappingProfileVenta : Profile
    {
        public MappingProfileVenta()
        {

            //GET: Products y ProductDto by ID
            // A     =====>     //B  
            //CreateMap<Venta, VentaForCreation>()
            //    .ForMember(b => b.Id, opt => opt.MapFrom(a => a))
            //    .ForMember(b => b.producto, opt => opt.MapFrom(a => a.Nombre))
            //    .ForMember(b => b.precioUnitario, opt => opt.MapFrom(a => a.Precio))
            //    .ForMember(b => b.stock, opt => opt.MapFrom(a => a.Stock))
            //    .ForMember(b => b.idCategoria, opt => opt.MapFrom(a => a.CategoryID))
            //    .ForMember(b => b.categoria, opt => opt.MapFrom(a => a.category.Nombre));

            // POST: ProductCreateDto => Products
            //                      B => A
            CreateMap<VentaForCreation, Venta>()
                .ForMember(a => a.ventaId, opt => opt.MapFrom(b => b.Id))
                .ForMember(a => a.Cliente, opt => opt.MapFrom(b => b.Cliente))
                .ForMember(a => a.ImporteTotal, opt => opt.MapFrom(b => b.ImporteTotal));               

            //PUT: ProductUpdateDto => Products
            //                    B => A

            CreateMap<DetalleVentaForCreation,  DetalleVenta> ()
               .ForMember(a => a.DetalleVentaId, opt => opt.MapFrom(b => b.detalleVentaId))               
               .ForMember(a => a.Producto, opt => opt.MapFrom(b => b.Producto))
               .ForMember(a => a.Precio, opt => opt.MapFrom(b => b.Precio))
               .ForMember(a => a.Cantidad, opt => opt.MapFrom(b => b.Cantidad));

            CreateMap<SubDetalleVentaForCreation, SubDetalleVenta>()
            .ForMember(a => a.SubDetalleVentaId, opt => opt.MapFrom(b => b.SubDetalleVentaId))
            .ForMember(a => a.DetalleVentaId, opt => opt.MapFrom(b => b.DetalleVentaId))
            .ForMember(a => a.Descripcion, opt => opt.MapFrom(b => b.Descripcion));           
        }

    }
}
