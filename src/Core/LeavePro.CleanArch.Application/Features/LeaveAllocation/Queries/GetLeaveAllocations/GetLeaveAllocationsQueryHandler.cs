using AutoMapper;
using LeavePro.CleanArch.Application.Contracts.Logging;
using LeavePro.CleanArch.Application.Contracts.Persistence;
using MediatR;

namespace LeavePro.CleanArch.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

public class GetLeaveAllocationsQueryHandler : IRequestHandler<GetLeaveAllocationsQuery,
                                                List<LeaveAllocationDto>>
{
    private readonly ILeaveAllocationRepository _allocationRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<GetLeaveAllocationsQueryHandler> _logger;

    public GetLeaveAllocationsQueryHandler(ILeaveAllocationRepository allocationRepository,
        IMapper mapper,
        IAppLogger<GetLeaveAllocationsQueryHandler> logger)
    {
        _allocationRepository = allocationRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationsQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocations = await _allocationRepository.GetAllAsync();

        var result = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);

        _logger.LogInformation("Leave allocations were retrieved successfully");

        return result;
    }
}