using Demo.Domain.Entities;
using Demo.Infrastructure.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;


using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using Demo.Infrastucture.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Rewrite;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace Demo.Service.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {       
        DepedencyInjectorConfig.ResolveDepenties(services);
        DatabaseConfig.ResolveDatabases(services, Configuration);
        new TokenConfig().ResolveToken(services, Configuration);
       services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore );
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        
        app.UseDeveloperExceptionPage();
        
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => endpoints.MapControllers());

        //Documentação Swagger
        app.UseSwagger();
        app.UseSwaggerUI(c => 
        { 
            c.SwaggerEndpoint("v1/swagger.json", "Demo"); 
        });
    
        var option = new RewriteOptions();
        option.AddRedirect("^$", "swagger");
        app.UseRewriter(option);
       
    }
    }
}
