using AutoMapper;
using LeavePro.CleanArch.Application.Contracts.Persistence;
using MediatR;

namespace LeavePro.CleanArch.Application.Features.LeaveRequest.Queries.GetGetLeaveRequestList;

public class GetLeaveRequestListQueryHandler : IRequestHandler<GetLeaveRequestListQuery, List<LeaveRequestListDto>>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;

    public GetLeaveRequestListQueryHandler(ILeaveRequestRepository leaveRequestRepository,
        IMapper mapper)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
    }

    public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListQuery request, CancellationToken cancellationToken)
    {
        var leaveRequests = await _leaveRequestRepository.GetAllLeaveRequestsWithDetails();
        var result = _mapper.Map<List<LeaveRequestListDto>>(leaveRequests);

        return result;
    }
}