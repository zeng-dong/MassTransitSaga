using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace MassTransitSaga.Configuration
{
    public class SwaggerConfigurator
    {
        public static void AddToServices(IServiceCollection services, string description = "some api")
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "APIs",
                    Description = description,
                    Contact = new OpenApiContact
                    {
                        Name = "APIs",
                        Email = "someone@somewhere.net",
                        Url = new Uri("https://www.someone.org")
                    }
                });
            });
        }
    }
}
