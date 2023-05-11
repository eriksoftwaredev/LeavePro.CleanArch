using AutoMapper;
using LeavePro.CleanArch.Application.Contracts.Persistence;
using LeavePro.CleanArch.Application.Exceptions;
using MediatR;

namespace LeavePro.CleanArch.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public class GetLeaveAllocationWithDetailsQueryHandler : 
    IRequestHandler<GetLeaveAllocationWithDetailsQuery, LeaveAllocationDetailsDto>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public GetLeaveAllocationWithDetailsQueryHandler(ILeaveAllocationRepository leaveAllocationRepository,
        IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }

    public async Task<LeaveAllocationDetailsDto> Handle(GetLeaveAllocationWithDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocationDetails = 
            await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);

        if (leaveAllocationDetails == null)
            throw new NotFoundException(nameof(Domain.LeaveAllocation), request.Id);

        var result = _mapper.Map<LeaveAllocationDetailsDto>(leaveAllocationDetails);

        return result;
    }
}