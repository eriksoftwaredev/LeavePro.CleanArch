using FluentValidation;
using LeavePro.CleanArch.Application.Contracts.Persistence;

namespace LeavePro.CleanArch.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;

public class CreateLeaveAllocationCommandValidator : AbstractValidator<CreateLeaveAllocationCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveAllocationCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(p => p.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(LeaveTypeExists)
            .WithMessage("{PropertyName} does not exist.");
    }

    private async Task<bool> LeaveTypeExists(int leaveTypeId, CancellationToken token)
    {
        return await _leaveTypeRepository.Exists(leaveTypeId);
    }
}