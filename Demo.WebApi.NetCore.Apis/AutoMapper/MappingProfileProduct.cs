using AutoMapper;
using Demo.WebApi.NetCore.Dto.DataTransferObjects.Product;
using Demo.WebApi.NetCore.Entities.Models;


namespace Demo.WebApi.NetCore.Apis.AutoMapper
{
    public class MappingProfileProduct : Profile
    {
        public MappingProfileProduct()
        {

            //GET: Products y ProductDto by ID
                    // A     =====>     //B  
            CreateMap<Product, ProductDto>()
                .ForMember(b => b.codigo, opt => opt.MapFrom(a => a.ProductID))
                .ForMember(b => b.producto, opt => opt.MapFrom(a => a.Nombre))
                .ForMember(b => b.precioUnitario, opt => opt.MapFrom(a => a.Precio))
                .ForMember(b => b.stock, opt => opt.MapFrom(a => a.Stock))
                .ForMember(b => b.idCategoria, opt => opt.MapFrom(a => a.CategoryID))
                .ForMember(b => b.categoria, opt => opt.MapFrom(a => a.category.Nombre));

            // POST: ProductCreateDto => Products
            //                      B => A
            CreateMap<ProductCreateDto, Product>()
                .ForMember(a => a.Nombre, opt => opt.MapFrom(b => b.producto))
                .ForMember(a => a.Precio, opt => opt.MapFrom(b => b.precioUnitario))
                .ForMember(a => a.Stock, opt => opt.MapFrom(b => b.stock))
                .ForMember(a => a.CategoryID, opt => opt.MapFrom(b => b.idCategoria));

            //PUT: ProductUpdateDto => Products
            //                    B => A

            CreateMap<ProductUpdateDto, Product>()
               .ForMember(a => a.ProductID, opt => opt.MapFrom(b => b.codigo))
               .ForMember(a => a.Nombre, opt => opt.MapFrom(b => b.producto))
               .ForMember(a => a.Precio, opt => opt.MapFrom(b => b.precioUnitario))
               .ForMember(a => a.Stock, opt => opt.MapFrom(b => b.stock))
               .ForMember(a => a.CategoryID, opt => opt.MapFrom(b => b.idCategoria));
        }

    }
}
