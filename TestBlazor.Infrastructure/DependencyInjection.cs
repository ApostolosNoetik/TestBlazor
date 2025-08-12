using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestBlazor.Domain.Interfaces;
using TestBlazor.Infrastructure.Kafka;

namespace TestBlazor.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var bootstrapServers = config.GetValue<string>("Kafka:BootstrapServers");

            services.AddSingleton<IKafkaProducer>(sp =>
                new KafkaProducer(bootstrapServers));

            // other registrations
            return services;
        }
    }
}
