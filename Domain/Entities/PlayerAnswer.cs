using Domain.Commons;

namespace Domain.Entities;
public class PlayerAnswer : BaseEntity
{
    public Guid ParticipantId { get; set; }
    public Guid QuestionId { get; set; }
    public Guid SelectedOptionId { get; set; }
    public DateTime AnsweredAt { get; set; } = DateTime.UtcNow;
    public int PointsEarned { get; set; } = 0;

    public Participant? Participant { get; set; }
    public Question? Question { get; set; }
    public Option? SelectedOption { get; set; }
}
