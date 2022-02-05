using APIDomain.Interfaces.Services;
using APIDomain.Interfaces.Services.User;
using APIServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace APIInfraCrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
            serviceCollection.AddScoped<INotifierService, NotifierService>();
        }
    }
}
