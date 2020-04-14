using Demo.Aplication;
using Demo.Application.Contracts;
using Demo.Application.Services;
using Demo.Domain.Contracts.Repositories;
using Demo.Domain.Contracts.Services;
using Demo.Domain.Entities;
using Demo.Domain.Services;
using Demo.Infrastucture.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Infrastructure.Ioc
{
    public static class DepedencyInjectorConfig
    {
        public static void ResolveDepenties(IServiceCollection serviceCollection)
        {
            //Application
            serviceCollection.AddScoped(typeof(IBaseApp<,,>), typeof(BaseServiceApp<,,>));
            serviceCollection.AddScoped<IPhoneApp, PhoneApp>();
            serviceCollection.AddScoped<IUserApp, UserApp>();
            serviceCollection.AddScoped<IUserClaimsApp, UserClaimsApp>();
            serviceCollection.AddScoped<SigningConfig>();
            serviceCollection.AddScoped<TokenConfiguration>();

            //Domain
            serviceCollection.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IPhoneService, PhoneService>();
            serviceCollection.AddScoped<IUserClaimsService, UserClaimsService>();
            
            //Repository
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IUserClaimsRepository, UserClaimsRepository>();
            serviceCollection.AddScoped<IPhoneRepository, PhoneRepository>();

            //Swagger
             serviceCollection.AddSwaggerGen( c =>
             {
                 c.SwaggerDoc( "v1", new Microsoft.OpenApi.Models.OpenApiInfo {Title = "Demo", Version = "v1"} );
             });

            //AutoMapper
            var config = new AutoMapper.MapperConfiguration(cfg => cfg
            .AddProfile(new MappingEntity()))
            .CreateMapper();
        
            serviceCollection.AddSingleton(config);
            
        }
        
    }
}