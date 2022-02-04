using APIDomain.Interfaces.Services;
using APIDomain.Interfaces.Services.User;
using APIDomain.Services;
using APIServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace APIInfraCrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<INotifierService, NotifierService>();
        }
    }
}
