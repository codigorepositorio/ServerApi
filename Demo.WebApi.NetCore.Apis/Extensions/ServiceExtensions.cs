using Demo.WebApi.NetCore.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.WebApi.NetCore.Apis.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader());
            });
        }

        public static IApplicationBuilder ConfigureCors(this IApplicationBuilder app)
        {
            app.UseCors(builder =>
             builder.WithOrigins("http://localhost:3000", "http://localhost:3001")
             .AllowAnyHeader()
              .AllowAnyMethod());
            return app;
        }

        public static void ConfigureSqlContext(this IServiceCollection services,IConfiguration configuration) =>
        services.AddDbContext<ContextDatabase>(opts =>
        opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b =>b.MigrationsAssembly("CompanyEmployees")));
    }
}
