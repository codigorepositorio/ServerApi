using Demo.WebApi.NetCore.AdoNet.Interfaz;
using Demo.WebApi.NetCore.AdoNet.Repository;
using Demo.WebApi.NetCore.AdoNet.Services;
using Demo.WebApi.NetCore.Dapper;
using Demo.WebApi.NetCore.Dapper.Interfaz;
using Demo.WebApi.NetCore.Dapper.Repository;
using Microsoft.Extensions.DependencyInjection;
namespace Demo.WebApi.NetCore.Apis.Extensions
{
    public static class ServiceExtensionsAdoNet
    {            
        public static void ConfigureAdoNet(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryVenta, RepositoryVenta>();
            services.AddScoped<ServiceVenta>();
        }
    }
}
