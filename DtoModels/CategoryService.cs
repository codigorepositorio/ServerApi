using AutoMapper;
using Demo.WebApi.NetCore.Entities.Models;
using Demo.WebApi.NetCore.Dapper.Interfaz;
using Demo.WebApi.NetCore.Dto.DataTransferObjects.Category;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Demo.WebApi.NetCore.Dto
{
    public class CategoryService
    {
        private readonly IDapperCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IDapperCategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategory()
        {
            var categorytEntity = await _categoryRepository.GetAll();
            var categories = _mapper.Map<IEnumerable<CategoryDto>>(categorytEntity);            
            return categories;
        }

        public async Task<CategoryDto> GetCategoryById(int Id)
        {
            var categorytEntity = await _categoryRepository.GetById(Id);
            var categories = _mapper.Map<CategoryDto>(categorytEntity);
            return categories;
        }

        public async Task<CategoryDto> CreateCategory(CategoryForCreation categoryForCreation)
        {
            var categorytEntity = _mapper.Map<Category>(categoryForCreation);
            var category = await _categoryRepository.Create(categorytEntity);
            var categoryReturn = _mapper.Map<CategoryDto>(category);
            return categoryReturn;
        }

        public async Task UpdateCategory(int Id,CategoryForUpdate categoryForUpdate)
        {
            var categoria = await _categoryRepository.GetById(Id);
            if (categoria == null)
                return;
            var categorytEntity = _mapper.Map<Category>(categoryForUpdate);
            await _categoryRepository.Update(categorytEntity);            
        }


        public async Task DeleteCategory(int Id)
        {
            var categoria = await _categoryRepository.GetById(Id);
            if (categoria == null)
                return;
            await _categoryRepository.Delete(categoria.CategoryID);
        }

    }
}
