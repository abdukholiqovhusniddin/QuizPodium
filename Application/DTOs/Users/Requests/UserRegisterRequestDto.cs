using Domain.Enums;

namespace Application.DTOs.Users.Requests;
public class UserRegisterRequestDto
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required UserRole UserRole { get; set; } = UserRole.Teacher;

}
