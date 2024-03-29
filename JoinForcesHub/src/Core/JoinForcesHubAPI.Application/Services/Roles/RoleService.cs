﻿using AutoMapper;
using FluentValidation;
using JoinForcesHubAPI.Domain.Enums;
using JoinForcesHub.Domain.Entities.Roles;
using JoinForcesHubAPI.Application.Abstractions;
using JoinForcesHubAPI.Application.Contracts.Roles;
using JoinForcesHubAPI.Application.Utilities.Messages;
using JoinForcesHubWeb.Application.Utilities.Messages;
using JoinForcesHubAPI.Application.Common.Interfaces.Services;
using JoinForcesHubAPI.Application.Contracts.CustomResponseDto;
using JoinForcesHubAPI.Application.Common.Interfaces.Persistance.RoleRepositories;

namespace JoinForcesHubAPI.Application.Services.Roles;

public class RoleService : BaseService<Role>, IRoleService
{
    private readonly IValidator<Role> _validator;
    private readonly IRoleQueryRepository _queryRepository;
    private readonly IRoleCommandRepository _commandRepository;
    public RoleService(
        IMapper mapper,
        IValidator<Role> validator,
        IDbContextService dbContextService,
        IDateTimeProvider dateTimeProvider,
        IRoleQueryRepository queryRepository,
        IRoleCommandRepository commandRepository
        )
        : base(mapper, dateTimeProvider, dbContextService)
    {
        _validator = validator;
        _queryRepository = queryRepository;
        _commandRepository = commandRepository;
    }

    public async Task<ResponseDto<bool>> CreateRoleAsync(RoleCreateDto roleCreateDto, CancellationToken cancellationToken)
    {
        var role = _mapper.Map<Role>(roleCreateDto);

        var validationResult = _validator.Validate(role);
        if (!validationResult.IsValid)
            return ResponseDto<bool>.Fail(validationResult.Errors.Select(e => e.ErrorMessage).ToList(), (int)ApiStatusCode.BadRequest);

        if (await _queryRepository.AnyAsync((x => x.RoleName == roleCreateDto.RoleName && x.IsDeleted == false)))
            throw new Exception(ServiceExceptionMessages.RoleAlreadyRegistered);

        role.CreationDate = DateTime.UtcNow;
        role.CreatedByUserName = roleCreateDto.CreatedByUserName;

        await _commandRepository.AddAsync(role, cancellationToken);

        return ResponseDto<bool>.Success(true, (int)ApiStatusCode.Create, ApiMessages.RegisterSuccess);
    }

    public async Task<ResponseDto<int>> CountRoleAsync()
    {
        var result = await _queryRepository.CountAsync(x => x.IsDeleted == false && x.IsActive == true);

        return ResponseDto<int>.Success(result, (int)ApiStatusCode.Success);
    }

    public Task<ResponseDto<RoleListDto>> GetAllByDeletedAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<RoleListDto>> GetAllByNonDeletedActiveAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<RoleDto>> GetAsync(int roleId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<bool>> HardDeleteRole(Guid roleId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<bool>> SoftDeleteRole(RoleRemoveDto roleRemoveDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<RoleUpdateDto>> UpdateRole(RoleUpdateDto roleUpdateDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<RoleUpdateDto>> UpdateRoleAsync(RoleUpdateDto updateUpdateDto)
    {
        throw new NotImplementedException();
    }

    public async Task<Role> GetByRoleNameAsync(string roleName)
    {
        var result = await _queryRepository.GetFirstExpression(x => x.RoleName == roleName);
        if (result == null)
            return null;

        return result;
    }
}
