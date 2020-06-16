using System.Collections.Generic;
using AutoMapper;
using crud_product_api.Dto;
using crud_product_domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace crud_product_api.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void CreateAutoMapperConfiguration(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
                config.CreateMap<List<Product>, List<ProductDto>>();
            });

            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
