using AutoMapper;
using Demo.WebApi.NetCore.Entities.Models;
using Demo.WebApi.NetCore.Dapper.Interfaz;
using Demo.WebApi.NetCore.Dto.DataTransferObjects.Category;
using System.Threading.Tasks;
using System.Collections.Generic;
using Demo.WebApi.NetCore.Dapper;

namespace Demo.WebApi.NetCore.Dto
{
    public class CategoryService
    {        
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CategoryService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {                        
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategory()
        {
            var categorytEntity = await _repositoryWrapper.Category.GetAll();
            var categories = _mapper.Map<IEnumerable<CategoryDto>>(categorytEntity);            
            return categories;
        }

        public async Task<CategoryDto> GetCategoryById(int Id)
        {
            var categorytEntity = await _repositoryWrapper.Category.GetById(Id);
            var categories = _mapper.Map<CategoryDto>(categorytEntity);
            return categories;
        }

        public async Task<CategoryDto> CreateCategory(CategoryForCreation categoryForCreation)
        {
            var categorytEntity = _mapper.Map<Category>(categoryForCreation);
            var category = await _repositoryWrapper.Category.Create(categorytEntity);
            var categoryReturn = _mapper.Map<CategoryDto>(category);
            return categoryReturn;
        }

        public async Task UpdateCategory(int Id,CategoryForUpdate categoryForUpdate)
        {
            var categoria = await _repositoryWrapper.Category.GetById(Id);
            if (categoria == null)
                return;
            var categorytEntity = _mapper.Map<Category>(categoryForUpdate);
            await _repositoryWrapper.Category.Update(categorytEntity);            
        }


        public async Task DeleteCategory(int Id)
        {
            var categoria = await _repositoryWrapper.Category.GetById(Id);
            if (categoria == null)
                return;
            await _repositoryWrapper.Category.Delete(categoria.CategoryID);
        }

    }
}
