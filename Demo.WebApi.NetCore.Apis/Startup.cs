using AutoMapper;
using Demo.WebApi.NetCore.Contracts;
using Demo.WebApi.NetCore.Dto;
using Demo.WebApi.NetCore.Entities;
using Demo.WebApi.NetCore.Repository;
using Demo.WebApi.NetCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Demo.WebApi.NetCore.Bussiness.Logic.Services;
using Demo.WebApi.NetCore.Apis.Extensions;
using Demo.WebApi.NetCore.Dapper.Common;
using Demo.WebApi.NetCore.AdoNet.Interfaz;
using Demo.WebApi.NetCore.AdoNet.Repository;
using Demo.WebApi.NetCore.AdoNet.Services;

namespace Demo.WebApi.NetCore.Apis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ContextDatabase>(
                opt => { opt.UseSqlServer(Configuration["sqlserver:cn"]); });

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductServices, ProductServices>();

            services.AddScoped<IVentaRepository, VentaRepository>();
            services.AddScoped<IVentaServices, VentaServices>();

            services.AddScoped<ProductService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<AlumnoService>();
            services.AddScoped<VentaService>();
            services.AddScoped<IServiceAlumnoBL, ServiceAlumnoBL>();

            //Dapper 

            services.AddSingleton<IConfiguration>(Configuration);
            Global.ConnectionString = Configuration.GetConnectionString("dapper");
            services.ConfigureDapperSql();

            //Ado.Net
            services.ConfigureAdoNet();
         

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(typeof(Startup));
            services.ConfigureSqlContext(Configuration);

            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {                    
                    options.SuppressInferBindingSourcesForParameters = true;
        
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.ConfigureCors();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
