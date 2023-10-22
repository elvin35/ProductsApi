using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Profiles;

namespace ProductsApi;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductsApi.Repository;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IProductsRepository, ProductsRepository>();
        services.AddControllers();
        services.AddSwaggerGen();
        services.AddAutoMapper(typeof(ApplicationProfile));
        services.AddDbContext<ProductsApiDbContext>(options =>
        {
            options.UseNpgsql(Configuration.GetConnectionString("ProductsApiConnectionString"));
        });
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseRouting();
        app.UseEndpoints(endpoits => endpoits.MapControllers());
    }
    
}