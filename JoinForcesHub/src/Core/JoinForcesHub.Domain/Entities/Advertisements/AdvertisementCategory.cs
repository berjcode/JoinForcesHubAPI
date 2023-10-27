using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.Advertisements;

public class AdvertisementCategory : BaseEntity
{
    public Guid AdvertisementId { get;  set; }
    public Guid CategoryId { get;  set; }
}
