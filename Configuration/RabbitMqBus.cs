using MassTransit;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MassTransitSaga.Configuration
{
    public class RabbitMqBus
    {
        public static void AddToServices(IServiceCollection services)
        {
            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(RabbitMqConstants.HostString);
                });
            });

            services.AddMassTransitHostedService();
        }

        // configuration that can work with version 6
        public static IBusControl ConfigureBus(
            IServiceProvider provider,
            Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri(RabbitMqConstants.RabbitMqUri), hst =>
                {
                    hst.Username(RabbitMqConstants.UserName);
                    hst.Password(RabbitMqConstants.Password);
                });

                //cfg.ConfigureEndpoints(provider);

                //registrationAction?.Invoke(cfg, host);
            });
        }
    }
}
