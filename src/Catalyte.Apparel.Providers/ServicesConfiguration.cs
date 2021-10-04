﻿using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Providers.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Catalyte.Apparel.Providers
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddProviders(this IServiceCollection services)
        {
            services.AddScoped<IProductProvider, ProductProvider>();
            services.AddScoped<IPurchaseProvider, PurchaseProvider>();

            return services;
        }
    }
}
