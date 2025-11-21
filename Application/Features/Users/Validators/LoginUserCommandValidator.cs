using Application.DTOs.Users.Requests;
using FluentValidation;

namespace Application.Features.Users.Validators;

public class LoginUserCommandValidator : AbstractValidator<UserLoginRequestDto>
{
    public LoginUserCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MinimumLength(3).WithMessage("Username must be at least 3 characters long.")
            .MaximumLength(20).WithMessage("Username must not exceed 20 characters.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
    }
}
