using System.Threading.Tasks;
using Demo.WebApi.NetCore.Dto;
using Demo.WebApi.NetCore.Dto.DataTransferObjects.Product;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebApi.NetCore.Apis.Controllers
{
    [Route("api/Products")]
    [ApiController]


    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{Id:int}")]
        public  async Task<IActionResult> GetProductById(int Id)
        {
            var productById = await _productService.GetProductById(Id);
            return Ok(productById);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductCreateDto productDto)
        {
            var productById = _productService.CreateProduct(productDto);
            if (productById)
                return Ok();
            return BadRequest();
        }

        [HttpPut("{Id:int}")]
        public async Task<IActionResult> UpdateProduct(int Id, [FromBody] ProductUpdateDto productDto)
        {
            var productById = await _productService.UpdateProduct(Id, productDto);
            if (productById.Equals("oK"))
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var productById = await _productService.DeleteProduct(id);
            if (productById)
                return Ok();
            return BadRequest();
        }
    }
}
