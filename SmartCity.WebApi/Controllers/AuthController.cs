using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartCity.Application.Features.Auth;

namespace SmartCity.WebApi.Controllers;

[ApiController]
[Route("auth")]
public class AuthController(IMediator mediator) : ControllerBase {
    private readonly IMediator _mediator = mediator;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request) {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request) {
        await _mediator.Send(request);
        return Ok();
    }
}
