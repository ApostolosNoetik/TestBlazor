// TestBlazor.Infrastructure/DependencyInjection.cs
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
            services.AddSingleton<IKafkaProducer>(sp =>
                new KafkaProducer(config.GetValue<string>("Kafka:BootstrapServers")));

            // other registrations
            return services;
        }
    }
}
