using MediatR;

namespace LeavePro.CleanArch.Application.Features.LeaveRequest.Commands.ApproveLeaveRequest;

public record ApproveLeaveRequestCommand(int Id) : IRequest<Unit>;
