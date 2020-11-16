using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.WebApi.NetCore.Dto;
using Demo.WebApi.NetCore.Dto.DataTransferObjects.Venta;
using Microsoft.AspNetCore.Http;
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
        public IActionResult SaveVentas([FromBody] VentaForCreation ventaForCreation, DetalleVentaForCreation detalleVenta)
        {
            var result = _ventaService.Create(ventaForCreation, detalleVenta);
            return Ok(result);
        }
    }


  
}
