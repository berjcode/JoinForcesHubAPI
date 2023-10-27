using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.UserDetails;

public class Advice : BaseEntity
{
    public Guid SenderUserId { get; set; } 
    public Guid ReceiverUserId { get; set; } 
    public string Content { get; set; }
    public string HowDoYouKnow { get; set; }
}
