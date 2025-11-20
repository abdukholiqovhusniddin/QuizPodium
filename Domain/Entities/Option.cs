using Domain.Commons;

namespace Domain.Entities;
public class Option : BaseEntity
{
    public Guid QuestionId { get; set; }
    public required string Text { get; set; }
    public bool IsCorrect { get; set; } = false;

    public Question? Question { get; set; }
}
