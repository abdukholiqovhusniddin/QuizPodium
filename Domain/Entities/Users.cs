using Domain.Commons;
using Domain.Enums;

namespace Domain.Entities;
public class Users : BaseEntity
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public UserRole Role { get; set; }
    public required string PasswordHash { get; set; }

    public ICollection<Quiz>? Quizzes { get; set; }
    public ICollection<Game>? Games { get; set; }

}
