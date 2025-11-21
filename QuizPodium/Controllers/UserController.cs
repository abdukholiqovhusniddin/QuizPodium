using Application.Commons;
using Application.DTOs.Users.Requests;
using Application.DTOs.Users.Responses;
using Application.Features.Users.Commands;
using Application.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IMediator mediator) : ApiControllerBase
{
    private readonly IMediator _mediator = mediator; // DI- Dependency Injection   

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> CreateUser([FromForm] UserRegisterRequestDto userRegisterDto)
    {
        var responseUserRegister = await _mediator.Send(new RegisterUserCommand(userRegisterDto));
        return StatusCode(responseUserRegister.StatusCode, responseUserRegister);
    }


    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto userLoginDto)
    {
        var token = await _mediator.Send(new LoginUserCommand(userLoginDto));

        return StatusCode(token.StatusCode, token);
    }
}