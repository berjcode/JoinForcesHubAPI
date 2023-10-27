using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.Advertisements;

public class AdvertisementCategory : BaseEntity
{
    public Guid AdvertisementId { get; private set; }
    public Guid CategoryId { get; private set; }
}
