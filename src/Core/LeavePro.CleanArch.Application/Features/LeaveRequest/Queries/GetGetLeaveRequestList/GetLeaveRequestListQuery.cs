using MediatR;

namespace LeavePro.CleanArch.Application.Features.LeaveRequest.Queries.GetGetLeaveRequestList;

public record GetLeaveRequestListQuery : IRequest<List<LeaveRequestListDto>>;