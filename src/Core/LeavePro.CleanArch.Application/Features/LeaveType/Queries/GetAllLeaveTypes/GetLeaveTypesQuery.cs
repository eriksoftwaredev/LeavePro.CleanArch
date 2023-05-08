using MediatR;

namespace LeavePro.CleanArch.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>;