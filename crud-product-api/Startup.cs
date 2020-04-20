using crud_product_api.Configuration;
using crud_product_domain.UseCases;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //DependencyInjection
            services.AddTransient<CreateProduct, CreateProduct>();
            services.AddTransient<DeleteProduct, DeleteProduct>();
            services.AddTransient<EditProduct, EditProduct>();
            services.AddTransient<GetAllProducts, GetAllProducts>();
            services.AddTransient<GetProductByCode, GetProductByCode>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            AutoMapperConfiguration.CreateAutoMapperConfiguration(services);
            SwaggerConfiguration.CreateConfiguration(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
