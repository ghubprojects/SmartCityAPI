using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartCity.Application.Features.Auth;

namespace SmartCity.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IMediator mediator) : ControllerBase {
    private readonly IMediator _mediator = mediator;

    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginQuery query) {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand command) {
        await _mediator.Send(command);
        return Ok();
    }
}
