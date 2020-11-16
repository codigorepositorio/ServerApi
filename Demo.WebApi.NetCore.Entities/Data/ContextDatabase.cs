using Demo.WebApi.NetCore.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.WebApi.NetCore.Entities
{
    public class ContextDatabase : DbContext
    {
        public ContextDatabase(DbContextOptions options) : base(options) { }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category{ get; set; }

        public DbSet<Product> Alumno { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<DetalleVenta> DetalleVenta { get; set; }
        public DbSet<SubDetalleVenta>SubDetalleVenta { get; set; }

    }
}
