using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartCity.Application.Features.Pois.Queries;

namespace SmartCity.WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class PoiController(IMediator mediator) : ControllerBase {
    private readonly IMediator _mediator = mediator;

    [HttpGet(Name = "GetPoi")]
    public async Task<IActionResult> Get() {
        var request = new GetPoisNearLocationQuery() {
            Latitude = 21.0285,
            Longitude = 105.8542,
            Radius = 2000
        };
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}
