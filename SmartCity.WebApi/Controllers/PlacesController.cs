using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCity.Application.Features.Places;

namespace SmartCity.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class PlacesController(IMediator mediator) : ControllerBase {
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetPlacesNearLocationQuery query) {
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
