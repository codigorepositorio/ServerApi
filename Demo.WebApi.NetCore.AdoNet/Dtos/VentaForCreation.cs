using Demo.WebApi.NetCore.AdoNet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.WebApi.NetCore.AdoNet.Dtos
{
   public class VentaForCreation
    {
        public int codigoVenta { get; set; }
        public string clienteVenta { get; set; }
        public decimal totalVenta { get; set; }
        public ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
