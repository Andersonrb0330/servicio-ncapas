using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence.Extensions
{
    public static class ServiceCollectionExtensions
	{
        public static void AddPersistenceProject(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EcommerceContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("SqlConnection"),
                builder => builder.MigrationsAssembly(typeof(EcommerceContext).Assembly.FullName)));
            services.AddScoped(provider => provider.GetService<EcommerceContext>());
        }
    }
}

