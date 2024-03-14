using ExternalServices.ServicesClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Interfaces.ExternalServices;
using Shared.ServiceClient;

namespace ExternalServices.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddExternalServiceProject(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ServiceClientSetting>(configuration.GetSection("ServiceClientSetting"));
            services.AddTransient<IFakerApiService, FakerApiService>();
            services.AddTransient<IReqresApiService, ReqresApiService>();
        }
    }
}        

