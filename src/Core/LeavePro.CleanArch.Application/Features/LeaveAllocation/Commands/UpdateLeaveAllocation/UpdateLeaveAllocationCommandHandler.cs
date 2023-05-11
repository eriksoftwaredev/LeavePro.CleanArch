using AutoMapper;
using LeavePro.CleanArch.Application.Contracts.Persistence;
using LeavePro.CleanArch.Application.Exceptions;
using MediatR;

namespace LeavePro.CleanArch.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;

public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,
        ILeaveTypeRepository leaveTypeRepository,
        IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveAllocationCommandValidator(_leaveTypeRepository,
            _leaveAllocationRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Leave Allocation", validationResult);

        var leaveAllocationToUpdate = _mapper.Map<Domain.LeaveAllocation>(request);
        await _leaveAllocationRepository.UpdateAsync(leaveAllocationToUpdate);

        return Unit.Value;
    }
}