using Microsoft.Extensions.DependencyInjection;
using Repository.Interfaces;
using Repository.Repositories;

namespace Repository.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositoryProject(this IServiceCollection services)
        {
            // Aquì damos a entender que esa interfaz y esa clase, trabajen juntos
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        }
    }
}

