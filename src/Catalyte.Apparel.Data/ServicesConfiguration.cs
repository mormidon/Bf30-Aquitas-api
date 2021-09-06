﻿using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalyte.Apparel.Data
{

    public static class ServicesConfiguration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<ApparelCtx>(options =>
                options.UseNpgsql(config.GetConnectionString("CatalyteApparel")));

            services.AddScoped<IApparelCtx>(provider => provider.GetService<ApparelCtx>());
            services.AddScoped<IProductRepository, IProductRepository>();

            return services;

        }

    }

}