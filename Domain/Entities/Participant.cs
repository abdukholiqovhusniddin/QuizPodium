using Domain.Commons;

namespace Domain.Entities;
public class Participant : BaseEntity
{
    public required string Username { get; set; }
    public Guid GameId { get; set; }
    public DateTime JoinedAt { get; set; }

    public required Game Game { get; set; }
    public ICollection<PlayerAnswer>? Answers { get; set; }
}
