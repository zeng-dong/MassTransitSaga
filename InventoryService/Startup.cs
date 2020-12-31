using InventoryService.Consumers;
using MassTransit;
using MassTransitSaga.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InventoryService
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
            services.AddControllers();

            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<PaymentCardNumberValidateConsumer>();

                cfg.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(RabbitMqConstants.HostString);

                    cfg.ReceiveEndpoint(RabbitMqConstants.OrderQueue, epc =>
                    {
                        epc.ConfigureConsumer<PaymentCardNumberValidateConsumer>(ctx);
                    });
                });
            });

            services.AddMassTransitHostedService();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
