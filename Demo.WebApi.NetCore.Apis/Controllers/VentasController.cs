using Demo.WebApi.NetCore.Dto;
using Demo.WebApi.NetCore.Dto.DataTransferObjects.Venta;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebApi.NetCore.Apis.Controllers
{
    [Route("api/ventas")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly VentaService _ventaService;

        public VentasController(VentaService ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpPost]
        public IActionResult SaveVentas([FromBody] VentaForCreation ventaForCreation,  DetalleVentaForCreation detalleVentas)
        {
            var result = _ventaService.Create(ventaForCreation, detalleVentas);
            return Ok(result);
        }
    }


  
}
