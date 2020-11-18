using Demo.WebApi.NetCore.AdoNet.Dtos;
using Demo.WebApi.NetCore.AdoNet.Models;
using Demo.WebApi.NetCore.AdoNet.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.WebApi.NetCore.Apis.Controllers
{
    [Route("api/VentaAdoNet")]
    [ApiController]
    public class VentaAdoNetController : ControllerBase
    {
        private readonly ServiceVenta _serviceVenta;

        public VentaAdoNetController(ServiceVenta serviceVenta)
        {
           _serviceVenta = serviceVenta;
        }

        [HttpPost]
        public async Task<ActionResult> CreateVenta([FromBody]VentaForCreation ventaForCreation)
        {
            try
            {
                var result = await _serviceVenta.Create(ventaForCreation);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message.ToString());
            }
      
           
        }

        [HttpPost("detalle-venta")]
        public async Task<ActionResult> CreateDetalleVenta([FromBody] List<DetalleVenta> detalleVenta)
        {
            try
            {
                var result = await _serviceVenta.CreateDetalle(detalleVenta);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message.ToString());
            }


        }

    }
}
