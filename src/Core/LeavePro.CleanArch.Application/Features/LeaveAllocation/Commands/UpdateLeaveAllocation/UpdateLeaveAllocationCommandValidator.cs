using FluentValidation;
using LeavePro.CleanArch.Application.Contracts.Persistence;

namespace LeavePro.CleanArch.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;

public class UpdateLeaveAllocationCommandValidator : AbstractValidator<UpdateLeaveAllocationCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public UpdateLeaveAllocationCommandValidator(ILeaveTypeRepository leaveTypeRepository,
        ILeaveAllocationRepository leaveAllocationRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _leaveAllocationRepository = leaveAllocationRepository;

        RuleFor(p => p.DayNumber)
            .GreaterThan(0).WithMessage("{PropertyName} must greater than {ComparisonValue}");

        RuleFor(p => p.Period)
            .GreaterThanOrEqualTo(DateTime.UtcNow.Year).WithMessage("{PropertyName} must be after {ComparisonValue}");

        RuleFor(p => p.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(LeaveTypeIsExists)
            .WithMessage("{PropertyName} does not exist.");

        RuleFor(p => p.Id)
            .NotNull()
            .MustAsync(LeaveAllocationExists)
            .WithMessage("{PropertyName} must be present");
    }

    private async Task<bool> LeaveAllocationExists(int id, CancellationToken token)
    {
        return await _leaveAllocationRepository.Exists(id);
    }

    private async Task<bool> LeaveTypeIsExists(int id, CancellationToken token)
    {
        return await _leaveTypeRepository.Exists(id);
    }
}