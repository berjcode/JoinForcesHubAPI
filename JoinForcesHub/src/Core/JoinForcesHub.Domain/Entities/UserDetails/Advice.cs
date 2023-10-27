using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.UserDetails;

public class Advice : BaseEntity
{
    public Guid SenderUserId { get; private set; }
    public Guid ReceiverUserId { get; private set; }
    public string Content { get; private set; }
    public string HowDoYouKnow { get; private set; }
}
