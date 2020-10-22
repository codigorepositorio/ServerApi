using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.WebApi.NetCore.Dto;
using Demo.WebApi.NetCore.Dto.DataTransferObjects.Category;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebApi.NetCore.Apis.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCategory()
        {
            return Ok(await _categoryService.GetAllCategory());
        }

        [HttpGet("{Id:int}", Name = "categoriaId")]
        public async Task<ActionResult> GetCategoryById(int Id)
        {
            return Ok(await _categoryService.GetCategoryById(Id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryForCreation categoryCreationDto)
        {
            var result = await _categoryService.CreateCategory(categoryCreationDto);
            return CreatedAtRoute("categoriaId", new { Id = result.Codigo }, result);
        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult> UpdateCategory(int Id, [FromBody] CategoryForUpdate categoryForUpdate)        {
            await _categoryService.UpdateCategory(Id, categoryForUpdate);
            return NoContent();
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> DeleteCategory(int Id)
        {
            await _categoryService.DeleteCategory(Id);
            return NoContent();
        }

        [Route("{contador}/While")]
        [HttpGet]
        public ActionResult<string> ContadoresWhile(int contador)
        {
            var x = 1;

            List<string> cadenas = new List<string>();
            string[] weekDays = new string[contador];
    
            while (x < contador)
            {

                x++;
                
                if (x % 2 == 0)
                {
                    
                    if (x.ToString()!= null)
                    {
                        cadenas.Add(x.ToString());
                    }
                }
            }

            return Ok(cadenas);
        }
    }
}
