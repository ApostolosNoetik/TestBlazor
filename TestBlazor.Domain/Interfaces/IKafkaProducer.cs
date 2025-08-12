// TestBlazor.Domain/Interfaces/IKafkaProducer.cs
namespace TestBlazor.Domain.Interfaces
{
    public interface IKafkaProducer
    {
        Task ProduceAsync<T>(string topic, T message);
    }
}
