using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Commons;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence.Extensions
{
    public static class ServiceCollectionExtensions
	{
        public static void AddPersistenceProject(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EcommerceContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("SqlEcommerce"),
                builder => builder.MigrationsAssembly(typeof(EcommerceContext).Assembly.FullName)));
            services.AddScoped<IEcommerceContext>(provider => provider.GetService<EcommerceContext>());

            services.AddSingleton(new PruebaContext(configuration.GetConnectionString("SqlPrueba")));
            AddRepositories(services);
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IEmpleadoRepository, EmpleadoRepository>();
            services.AddTransient<IProductoRepository, ProductoRepository>();
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<ITipoProductoRepository, TipoProductoRepository>();
            services.AddTransient<IPaisRepository, PaisRepository>();
            services.AddTransient<IRolRepository, RolRepositorty>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}

