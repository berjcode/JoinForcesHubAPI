using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.Advertisements;

public class Advertisement : BaseEntity
{
    public string Title { get; private set; }
    public string Content { get; private set; }
    public string Location { get; private set; }
    public string WorkingStyle { get; private set; }
    public string MetaTitle { get; private set; }
    public string MetaDescription { get; private set; }
    public string Keywords { get; private set; }
    public string AdverisementUrl { get; private set; }
    public string AdvertisementStatus { get; private set; }
}
