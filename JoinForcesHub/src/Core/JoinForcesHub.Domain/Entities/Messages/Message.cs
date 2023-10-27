using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.Messages;

public class Message :BaseEntity
{
    public string Content { get; private set; }
    public Guid UserId { get; private set; }
    public Guid RoomId { get; private  set; }
    public bool IsMessageVisible { get; private set; }
}
