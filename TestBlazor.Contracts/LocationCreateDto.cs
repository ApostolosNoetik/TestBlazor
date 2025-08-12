// TestBlazor.Contracts/LocationCreateDto.cs
namespace TestBlazor.Contracts
{
    public class LocationCreateDto
    {
        public string Name { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
