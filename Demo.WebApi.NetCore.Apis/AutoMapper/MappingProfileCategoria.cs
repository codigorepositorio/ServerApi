using AutoMapper;
using Demo.WebApi.NetCore.Dto.DataTransferObjects.Category;
using Demo.WebApi.NetCore.Entities.Models;

namespace Demo.WebApi.NetCore.Apis.AutoMapper
{
    public class MappingProfileCategoria : Profile
    {
        public MappingProfileCategoria()
        {
            //GET: Category y Category by ID
            //A      //B  
            CreateMap<Category, CategoryDto>()
                .ForMember(b => b.Codigo, opt => opt.MapFrom(a => a.CategoryID))
                .ForMember(b => b.Categoria, opt => opt.MapFrom(a => a.Nombre))
                .ForMember(b => b.Condicion, opt => opt.MapFrom(a => a.Estado))
                .ForMember(b => b.product, opt => opt.MapFrom(a => a.Products));

            //POST: CategoryForCreation                    
            CreateMap<CategoryForCreation, Category>()
                .ForMember(a => a.Nombre, opt => opt.MapFrom(b => b.Categoria))
                .ForMember(a => a.Estado, opt => opt.MapFrom(b => b.Condicion));

            //PUT: CategoryForUpdate                    
            CreateMap<CategoryForUpdate, Category>()
                .ForMember(a => a.CategoryID, opt => opt.MapFrom(b => b.Codigo))
                .ForMember(a => a.Nombre, opt => opt.MapFrom(b => b.Categoria))
                .ForMember(a => a.Estado, opt => opt.MapFrom(b => b.Condicion));
        }
    }
}
