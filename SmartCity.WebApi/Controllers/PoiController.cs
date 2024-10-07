using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartCity.Application.Features.Pois;

namespace SmartCity.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PoiController(IMediator mediator) : ControllerBase {
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get(double lat = 105.852, double lon = 21.028, double distance = 2000) {
        var request = new GetPoisNearLocationQuery() {
            Latitude = lat,
            Longitude = lon,
            Distance = distance
        };
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}
