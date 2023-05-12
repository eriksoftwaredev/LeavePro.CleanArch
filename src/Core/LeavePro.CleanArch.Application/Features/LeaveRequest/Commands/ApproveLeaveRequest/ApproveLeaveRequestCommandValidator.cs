using FluentValidation;

namespace LeavePro.CleanArch.Application.Features.LeaveRequest.Commands.ApproveLeaveRequest;

public class ApproveLeaveRequestCommandValidator : AbstractValidator<ApproveLeaveRequestCommand>
{
    public ApproveLeaveRequestCommandValidator()
    {

    }
}