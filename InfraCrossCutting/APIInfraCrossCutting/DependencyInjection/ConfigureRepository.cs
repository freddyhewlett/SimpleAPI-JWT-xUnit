using APIDomain.Interfaces.Repositories;
using APIInfra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace APIInfraCrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
