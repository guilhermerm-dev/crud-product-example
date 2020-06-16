using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
namespace crud_product_api.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void CreateSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "crud-product-example", Version = "v1" });
            });
        }
    }
}
