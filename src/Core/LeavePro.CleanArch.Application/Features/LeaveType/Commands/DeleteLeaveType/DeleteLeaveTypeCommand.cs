using MediatR;

namespace LeavePro.CleanArch.Application.Features.LeaveType.Commands.DeleteLeaveType;

public record class DeleteLeaveTypeCommand(int Id) : IRequest<Unit>;