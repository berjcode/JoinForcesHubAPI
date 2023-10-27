using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.Messages;

public class Message : BaseEntity
{
    public string Content { get;  set; }
    public Guid UserId { get;  set; }
    public Guid RoomId { get;  set; }
    public bool IsMessageVisible { get;  set; }
}
