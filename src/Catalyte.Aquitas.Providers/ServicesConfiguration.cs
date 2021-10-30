using Catalyte.Aquitas.Providers.Interfaces;
using Catalyte.Aquitas.Providers.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Catalyte.Aquitas.Providers
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddProviders(this IServiceCollection services)
        {
            services.AddScoped<IProductProvider, ProductProvider>();
            services.AddScoped<IPurchaseProvider, PurchaseProvider>();
            services.AddScoped<ICompanyProvider, CompanyProvider>();

            return services;
        }
    }
}
