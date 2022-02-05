using APIDomain.Interfaces.Repositories;
using APIInfra.Data;
using APIInfra.Implementation;
using APIInfra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace APIInfraCrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();
        }
    }
}
