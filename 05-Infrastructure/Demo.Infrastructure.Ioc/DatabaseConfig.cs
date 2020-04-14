
using Demo.Infrastucture.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Infrastructure.Ioc
{
    public static class DatabaseConfig
    {
        public static void ResolveDatabases(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString"), 
                b => b.MigrationsAssembly("Demo.Service.Api")));
        }
    }
}


