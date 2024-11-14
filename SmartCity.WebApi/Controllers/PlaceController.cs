using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartCity.Application.Features.Places;

namespace SmartCity.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PlaceController(IMediator mediator) : ControllerBase {
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get(double lat = 21.028, double lon = 105.852, string type = "", double distance = 2000) {
        var request = new GetPlacesNearLocationQuery() {
            Latitude = lat,
            Longitude = lon,
            Type = type,
            Distance = distance
        };
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}
