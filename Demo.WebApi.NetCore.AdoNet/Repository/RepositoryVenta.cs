using Demo.WebApi.NetCore.AdoNet.Interfaz;
using Demo.WebApi.NetCore.AdoNet.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Demo.WebApi.NetCore.AdoNet.Repository
{
    public class RepositoryVenta : IRepositoryVenta
    {
        private readonly string cnx;
        public RepositoryVenta(IConfiguration configuration)
        {
            cnx = configuration.GetConnectionString("adoNet");
        }
        public async Task<Venta> Create(Venta venta)
        {
            using (SqlConnection conn = new SqlConnection(cnx))
            {

                using (SqlCommand cmd = new SqlCommand("Usp_Venta", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Cliente", venta.Cliente));
                    cmd.Parameters.Add(new SqlParameter("@ImporteTotal", venta.ImporteTotal));
                    cmd.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@VentaId",
                        Value = venta.VentaId,
                        Direction = System.Data.ParameterDirection.Output
                    });

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    int id = (int)cmd.Parameters["@VentaId"].Value;
                    venta.VentaId = id;
                    return venta;

                }

            }
        }


        public async Task<List<DetalleVenta>> CreateDetalle(List<DetalleVenta> detalleVenta)
        {
            List<DetalleVenta> lstDetalleVenta = new List<DetalleVenta>();

            using (SqlConnection conn = new SqlConnection(cnx))
            {
                await conn.OpenAsync();

                foreach (DetalleVenta item in detalleVenta)
                {
                    using (SqlCommand cmd = new SqlCommand("Usp_DetalleVenta", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@VentaId", item.ventaId));
                        cmd.Parameters.Add(new SqlParameter("@Producto", item.Producto));
                        cmd.Parameters.Add(new SqlParameter("@Precio", item.Precio));
                        cmd.Parameters.Add(new SqlParameter("@Cantidad", item.Cantidad));
                        cmd.Parameters.Add(new SqlParameter("@SubTotal", item.SubTotal));
                        await cmd.ExecuteNonQueryAsync();
                    }

                    lstDetalleVenta.Add(item);
                }
                detalleVenta.Clear();
                conn.Close();
                return lstDetalleVenta;
            }
        }


    }
}
