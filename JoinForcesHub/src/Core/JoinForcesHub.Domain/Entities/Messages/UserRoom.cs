using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.Messages;

public class UserRoom : BaseEntity
{
    public Guid UserId { get; private set; }
    public Guid RoomId { get; private set; }
}
