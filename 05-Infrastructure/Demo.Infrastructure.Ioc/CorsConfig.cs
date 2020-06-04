
using Demo.Infrastucture.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Infrastructure.Ioc
{
    public static class CorsConfig
    {
        public static void ResolveCors(IServiceCollection serviceCollection)
        {
             serviceCollection.AddCors(options =>
        {
            options.AddDefaultPolicy(
                builder =>
                {
                  builder
                  .WithOrigins("http://localhost:4200", "http://www.contoso.com")
                  .AllowAnyHeader()
                  .WithMethods("POST", "PUT", "DELETE", "GET");                   
                });
        });
        }
    }
}


