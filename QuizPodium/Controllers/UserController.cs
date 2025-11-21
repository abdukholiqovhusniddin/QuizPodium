using Application.DTOs.Users.Requests;
using Application.Features.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IMediator mediator) : ApiControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("register")]
    public async Task<IActionResult> CreateUser([FromBody] UserRegisterRequestDto userRegisterDto)
    {
        var responseUserRegister = await _mediator.Send(new RegisterUserCommand(userRegisterDto));
        return StatusCode(responseUserRegister.StatusCode, responseUserRegister);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto userLoginDto)
    {
        var token = await _mediator.Send(new LoginUserCommand(userLoginDto));

        return StatusCode(token.StatusCode, token);
    }
}