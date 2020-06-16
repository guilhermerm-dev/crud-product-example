using crud_product_api.Presenters;
using crud_product_domain.Repositories;
using crud_product_domain.UseCases;
using crud_product_infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace crud_product_api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddTransient<ProductPresenter, ProductPresenter>();
            services.AddTransient<CreateProduct, CreateProduct>();
            services.AddTransient<DeleteProduct, DeleteProduct>();
            services.AddTransient<EditProduct, EditProduct>();
            services.AddTransient<GetAllProducts, GetAllProducts>();
            services.AddTransient<GetProductByCode, GetProductByCode>();
            services.AddTransient<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
