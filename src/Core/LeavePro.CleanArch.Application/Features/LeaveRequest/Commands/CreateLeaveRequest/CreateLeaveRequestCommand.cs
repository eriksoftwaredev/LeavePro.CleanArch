using LeavePro.CleanArch.Application.Features.LeaveRequest.Shared;
using MediatR;

namespace LeavePro.CleanArch.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommand : BaseLeaveRequest, IRequest<int>
{
    public string RequestComment { get; init; } = string.Empty;
}