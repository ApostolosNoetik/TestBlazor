//TestBlazor.Application/Locations/Commands/CreateLocationCommand.cs
using MediatR;
using TestBlazor.Domain.Interfaces;

namespace TestBlazor.Application.Locations.Commands
{
    public record CreateLocationCommand(string Name, double Latitude, double Longitude) : IRequest<Unit>;

    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Unit>
    {
        private readonly IKafkaProducer _kafkaProducer;

        public CreateLocationCommandHandler(IKafkaProducer kafkaProducer)
        {
            _kafkaProducer = kafkaProducer;
        }

        public async Task<Unit> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var locationEvent = new
            {
                Name = request.Name,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                CreatedAt = DateTime.UtcNow
            };

            await _kafkaProducer.ProduceAsync("location-updates", locationEvent);

            return Unit.Value;
        }
    }
}
