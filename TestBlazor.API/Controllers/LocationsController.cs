using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestBlazor.Application.Locations.Commands;
using TestBlazor.Contracts;

namespace TestBlazor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(LocationCreateDto dto)
        {
            var command = new CreateLocationCommand(dto.Name, dto.Latitude, dto.Longitude);
            await _mediator.Send(command);
            return Accepted();
        }
    }
}
