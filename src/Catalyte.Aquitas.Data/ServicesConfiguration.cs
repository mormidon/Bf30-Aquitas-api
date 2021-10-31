using Catalyte.Aquitas.Data.Context;
using Catalyte.Aquitas.Data.Interfaces;
using Catalyte.Aquitas.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalyte.Aquitas.Data
{

    public static class ServicesConfiguration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<ApparelCtx>(options =>
                options.UseNpgsql(config.GetConnectionString("CatalyteApparel")));

            services.AddScoped<IApparelCtx>(provider => provider.GetService<ApparelCtx>());
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;

        }

    }

}
