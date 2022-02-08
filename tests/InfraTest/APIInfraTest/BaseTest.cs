using APIInfra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace APIInfraTest
{
    public abstract class BaseTest
    {
        public BaseTest()
        {
        }
    }

    public class DbTest : IDisposable
    {
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; private set; }

        public DbTest()
        {
            var serviceCollection = new ServiceCollection();
            //Cria um banco de dados de teste
            serviceCollection.AddDbContext<APIDbContext>(options => options.UseSqlServer($"Server = (localdb)\\mssqllocaldb; Database = {dataBaseName}; Trusted_Connection = True;"), ServiceLifetime.Transient);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            using (var context = ServiceProvider.GetService<APIDbContext>())
            {
                //Certifica a criação do banco de dados
                context.Database.EnsureCreated();
            }
        }

        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<APIDbContext>())
            {
                //Deleta o banco de dados
                context.Database.EnsureDeleted();
            }
        }
    }
}
