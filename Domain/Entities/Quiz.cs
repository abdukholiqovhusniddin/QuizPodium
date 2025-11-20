using Domain.Commons;

namespace Domain.Entities;
public class Quiz : BaseEntity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public Guid CreatedById {  get; set; } // Teacher

    public required Users CreatedBy { get; set; }
    public ICollection<Question> Questions { get; set; }
    public ICollection<Game> Games { get; set; }
}
