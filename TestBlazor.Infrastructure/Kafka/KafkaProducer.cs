// TestBlazor.Infrastructure/Kafka/KafkaProducer.cs
using Confluent.Kafka;
using Newtonsoft.Json;
using TestBlazor.Domain.Interfaces;

namespace TestBlazor.Infrastructure.Kafka
{
    public class KafkaProducer : IKafkaProducer, IDisposable
    {
        private readonly IProducer<Null, string> _producer;

        public KafkaProducer(string bootstrapServers)
        {
            var config = new ProducerConfig { BootstrapServers = bootstrapServers };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task ProduceAsync<T>(string topic, T message)
        {
            var json = JsonConvert.SerializeObject(message);
            await _producer.ProduceAsync(topic, new Message<Null, string> { Value = json });
        }

        public void Dispose()
        {
            _producer?.Dispose();
        }
    }
}
