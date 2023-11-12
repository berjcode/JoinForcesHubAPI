using JoinForcesHubAPI.Application.Common.Interfaces.Services;

namespace JoinForcesHubAPI.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime NowTime => DateTime.Now;
}
