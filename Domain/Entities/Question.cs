using Domain.Commons;

namespace Domain.Entities;
public class Question : BaseEntity
{
    public Guid QuizId { get; set; }
    public required string Text { get; set;  }
    public int TimeLimitSeconds { get; set; } = 20; // default time limit
    public int Points { get; set; } = 10; // default points

    public Quiz? Quiz { get; set; }
    public required ICollection<Option> Options { get; set; }
}
