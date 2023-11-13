using AutoMapper;
using JoinForcesHubAPI.Application.Common.Interfaces.Services;

namespace JoinForcesHubAPI.Application.Abstractions;

public abstract class BaseService<T>
{
    protected readonly IMapper _mapper;
    protected readonly IDbContextService _dbContextService;
    protected readonly IDateTimeProvider _dateTimeProvider;

    protected BaseService(
        IMapper mapper,
        IDateTimeProvider dateTimeProvider,
        IDbContextService dbContextService)
    {
        _mapper = mapper;
        _dateTimeProvider = dateTimeProvider;
        _dbContextService = dbContextService;
    }

    public virtual bool IsDtoValid(T dto)
    {
        return dto != null;
    }
}
