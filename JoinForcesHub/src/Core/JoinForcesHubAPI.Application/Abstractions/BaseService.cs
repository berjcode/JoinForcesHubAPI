using AutoMapper;
using JoinForcesHubAPI.Application.Common.Interfaces.Services;

namespace JoinForcesHubAPI.Application.Abstractions;

public abstract class BaseService<T>
{
    protected readonly IMapper _mapper;
    protected readonly IDateTimeProvider _dateTimeProvider;

    protected BaseService(
        IMapper mapper,
        IDateTimeProvider dateTimeProvider)
    {
        _mapper = mapper;
        _dateTimeProvider = dateTimeProvider;
    }

    public virtual bool IsDtoValid(T dto)
    {
        return dto != null;
    }
}
