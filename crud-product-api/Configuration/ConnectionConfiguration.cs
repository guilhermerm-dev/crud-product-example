﻿using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace crud_product_api.Configuration
{
    public static class ConnectionConfiguration
    {
        public static void CreateConnectionConfiguration(this IServiceCollection services, IConfiguration appConfiguration)
        {
            var configuration = new crud_product_shared.Configuration()
            {
                ConnectionString = $"{appConfiguration["ConnectionString"]}",
                DataBaseType = (crud_product_shared.Enums.DataBase)Enum.Parse(typeof(crud_product_shared.Enums.DataBase),
                $"{appConfiguration["DataBaseType"]}")
            };

            services.AddSingleton(configuration);
        }

    }
}
