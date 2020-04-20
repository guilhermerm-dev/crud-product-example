using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
namespace crud_product_api.Configuration
{
    public class SwaggerConfiguration
    {
        public static void CreateConfiguration(IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "crud-product-example", Version = "v1" });
            });
        }
    }
}
