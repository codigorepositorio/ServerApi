using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.WebApi.NetCore.Dto.DataTransferObjects.Venta
{
    public class SubDetalleVentaForCreation
    {
        public int SubDetalleVentaId { get; set; }
        public int DetalleVentaId { get; set; }
        public string Descripcion { get; set; }

    }
}
