using FluentValidation;
using LeavePro.CleanArch.Application.Contracts.Persistence;
using LeavePro.CleanArch.Application.Features.LeaveType.Commands.CreateLeaveType;

namespace LeavePro.CleanArch.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(p => p.Id)
            .NotNull()
            .MustAsync(LeaveTypeMustExist);

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(255).WithMessage("{PropertyName} must be fewer than 255 characters");

        //RuleFor(q => q)
        //    .MustAsync(LeaveTypeNameUniqueForUpdate)
        //    .WithMessage("Leave type name already exist");

        RuleFor(p => p.DefaultDays)
            .LessThan(100).WithMessage("{PropertyName} cannot exceed 100")
            .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");
    }

    //private async Task<bool> LeaveTypeNameUniqueForUpdate(UpdateLeaveTypeCommand command, CancellationToken token)
    //{
    //    return await _leaveTypeRepository.IsLeaveTypeUniqueForUpdate();
    //}

    private async Task<bool> LeaveTypeMustExist(int id, CancellationToken token)
    {
        return await _leaveTypeRepository.IsExist(id);
    }
}