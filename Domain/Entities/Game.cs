using Domain.Commons;

namespace Domain.Entities;
public class Game : BaseEntity
{
    public Guid QuizId { get; set; }
    public Guid TeacherId { get; set; }
    public required string GameCode { get; set; }
    public DateTime StartedAt { get; set; }
    public bool IsActive { get; set; } = false;

    public required Quiz Quiz { get; set; }
    public required User Teacher { get; set; }
    public required ICollection<Participant> Participants { get; set; }
}
