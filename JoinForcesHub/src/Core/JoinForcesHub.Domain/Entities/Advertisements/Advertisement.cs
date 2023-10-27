using JoinForcesHub.Domain.Abstract;

namespace JoinForcesHub.Domain.Entities.Advertisements;

public class Advertisement : BaseEntity
{
    public string Title { get;  set; }
    public string Content { get;  set; }
    public string Location { get;  set; }
    public string WorkingStyle { get;  set; }
    public string MetaTitle { get;  set; }
    public string MetaDescription { get;  set; }
    public string Keywords { get;  set; }
    public string AdverisementUrl { get;  set; }
    public string AdvertisementStatus { get;  set; }
}
