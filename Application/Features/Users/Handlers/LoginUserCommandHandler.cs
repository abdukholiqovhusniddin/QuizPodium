using Application.Commons;
using Application.Exceptions;
using Application.Features.Users.Commands;
using Application.JwtAuth;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Users.Handlers;

internal sealed class LoginUserCommandHandler(IUserRepository userRepository,
    JwtService jwtService) : IRequestHandler<LoginUserCommand, ApiResponse<string>>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<ApiResponse<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var loginDto = request.UserLoginDto;
        var user = await _userRepository.GetByUsernameAsync(loginDto.Username, cancellationToken)
            ?? throw new ApiException("Invalid username.");

        if(!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash)){
            throw new ApiException("Invalid password.");
        }

        string token = jwtService.GenerateToken(user);
        return new ApiResponse<string>(token);
    }
}
