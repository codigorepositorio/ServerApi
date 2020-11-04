using Demo.WebApi.NetCore.Dapper;
using Demo.WebApi.NetCore.Dapper.Interfaz;
using Demo.WebApi.NetCore.Dapper.Repository;
using Microsoft.Extensions.DependencyInjection;
namespace Demo.WebApi.NetCore.Apis.Extensions
{
    public static class ServiceExtensionsDapperSql
    {            
        public static void ConfigureDapperSql(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IAlumnoService, AlumnoService>();
        }
    }
}
