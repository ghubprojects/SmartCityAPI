using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCity.Application.Features.Places;

namespace SmartCity.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("places")]
public class PlacesController(IMediator mediator) : ControllerBase {
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetPlaces([FromQuery] GetPlaceRequest request) {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("types")]
    public async Task<IActionResult> GetPlaceTypes() {
        var result = await _mediator.Send(new GetPlaceTypesRequest());
        return Ok(result);
    }
}
