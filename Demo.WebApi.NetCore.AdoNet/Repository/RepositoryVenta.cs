using Demo.WebApi.NetCore.AdoNet.Interfaz;
using Demo.WebApi.NetCore.AdoNet.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
            List<DetalleVenta> lstDetalleVenta = new List<DetalleVenta>();
            List<SubDetalleVenta> lstSubDetalleVenta = new List<SubDetalleVenta>();
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
                    foreach (var item in venta.DetalleVenta)
                    {
                        item.ventaId = id;
                        var result = await CreateDetalle(item);
                        lstDetalleVenta.Add(result);
                    }

                    foreach (var item in venta.DetalleVenta.SelectMany(sub => sub.SubDetalleVenta))
                    {
                        item.DetalleVentaId = id;
                        var result = await CreateSubDetalle(item);
                        lstSubDetalleVenta.Add(result);
                    }
                    conn.Close();
                    venta.VentaId = id;
                    venta.DetalleVenta = lstDetalleVenta;
                    return venta;
                }
            }
        }


        private async Task<DetalleVenta> CreateDetalle(DetalleVenta detalleVenta)
        {

            using (SqlConnection conn = new SqlConnection(cnx))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("Usp_DetalleVenta", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@VentaId", detalleVenta.ventaId));
                    cmd.Parameters.Add(new SqlParameter("@Producto", detalleVenta.Producto));
                    cmd.Parameters.Add(new SqlParameter("@Precio", detalleVenta.Precio));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", detalleVenta.Cantidad));
                    cmd.Parameters.Add(new SqlParameter("@SubTotal", detalleVenta.SubTotal));
                    await cmd.ExecuteNonQueryAsync();
                }
                conn.Close();
                return detalleVenta;
            }
        }


        private async Task<SubDetalleVenta> CreateSubDetalle(SubDetalleVenta subDetalleVenta)
        {
            using (SqlConnection conn = new SqlConnection(cnx))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("Usp_SubDetalleVenta", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@DetalleVentaId", subDetalleVenta.DetalleVentaId));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", subDetalleVenta.Descripcion));
                    await cmd.ExecuteNonQueryAsync();
                }
                conn.Close();
                return subDetalleVenta;
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
