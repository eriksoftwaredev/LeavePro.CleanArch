using AutoMapper;
using LeavePro.CleanArch.Application.Contracts.Persistence;
using LeavePro.CleanArch.Application.Exceptions;
using MediatR;

namespace LeavePro.CleanArch.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,
        ILeaveTypeRepository leaveTypeRepository,
        IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveAllocationCommandValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Leave Allocation request", validationResult);

        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.LeaveTypeId);

        // ToDo: ddd

        var leaveAllocationToCreate = _mapper.Map<Domain.LeaveAllocation>(request);
        await _leaveAllocationRepository.CreateAsync(leaveAllocationToCreate);

        return leaveAllocationToCreate.Id;
    }
}