using Application.Commons;
using Application.Exceptions;
using Application.Features.Users.Commands;
using Application.Interfaces;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Users.Handlers;

internal sealed class RegisterUserCommandHandler(IUserRepository userRepository, IEmailService emailService)
    : IRequestHandler<RegisterUserCommand, ApiResponse<Unit>>
{
    private readonly IUserRepository _userRepository = userRepository;

    public static string GeneratePasswordForUser() =>
        PasswordHelper.PasswordGeneration();

    public async Task<ApiResponse<Unit>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var dto = request.UserRegisterDto;

        if (await _userRepository.ExistsAsync(dto.Username))   throw new ApiException("User already exists.");
        if (await _userRepository.ExistsAsync(dto.Email))      throw new ApiException("Email already exists.");

        string password = GeneratePasswordForUser();

        var user = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            Role = dto.UserRole,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
        };

        await _userRepository.CreateAsync(user, cancellationToken);
        await emailService.SendPasswordEmailGmailAsync(dto.Email, dto.Username, password);

        return new ApiResponse<Unit>
        {
            Data = Unit.Value,
            StatusCode = 201
        };
    }
}
