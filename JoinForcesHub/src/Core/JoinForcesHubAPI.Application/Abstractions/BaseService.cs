using AutoMapper;

namespace JoinForcesHubAPI.Application.Abstractions;

public abstract class BaseService<T>
{
    protected readonly IMapper _mapper;

    protected BaseService(
        IMapper mapper)
    {
        _mapper = mapper;
    }

    public virtual bool IsDtoValid(T dto)
    {
        return dto != null;
    }
}
