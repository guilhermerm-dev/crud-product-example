using crud_product_api.Configuration;
using crud_product_api.Presenters;
using crud_product_domain.Repositories;
using crud_product_domain.UseCases;
using crud_product_infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace crud_product_api
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<ProductPresenter, ProductPresenter>();
            services.AddTransient<CreateProduct, CreateProduct>();
            services.AddTransient<DeleteProduct, DeleteProduct>();
            services.AddTransient<EditProduct, EditProduct>();
            services.AddTransient<GetAllProducts, GetAllProducts>();
            services.AddTransient<GetProductByCode, GetProductByCode>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            AutoMapperConfiguration.CreateConfiguration(services);
            SwaggerConfiguration.CreateConfiguration(services);
            ConnectionConfiguration.CreateConfiguration(services, Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "crud-product-example - V1");
            });

        }
    }
}
