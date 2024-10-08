using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartCity.Application.Features.Pois;

namespace SmartCity.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PoiController(IMediator mediator) : ControllerBase {
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get(double lat = 21.028, double lon = 105.852, string type = "", double distance = 2000) {
        var request = new GetPoisNearLocationQuery() {
            Latitude = lat,
            Longitude = lon,
            Type = type,
            Distance = distance
        };
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}
