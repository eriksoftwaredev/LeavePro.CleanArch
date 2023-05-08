﻿using AutoMapper;
using LeavePro.CleanArch.Application.Contracts.Persistence;
using MediatR;

namespace LeavePro.CleanArch.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public GetLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        var leaveTypes = await _leaveTypeRepository.GetAllAsync();

       var result= _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

       return result;
    }
}