using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeavePro.CleanArch.Application.Contracts.Persistence;
using LeavePro.CleanArch.Application.Exceptions;
using MediatR;

namespace LeavePro.CleanArch.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;

public record DeleteLeaveAllocationCommand(int Id) : IRequest<Unit>;

public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,
        IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var leaveAllocationToDelete = await _leaveAllocationRepository.GetByIdAsync(request.Id);
        if (leaveAllocationToDelete is null)
            throw new NotFoundException(nameof(Domain.LeaveAllocation), request.Id);

        await _leaveAllocationRepository.DeleteAsync(leaveAllocationToDelete);

        return Unit.Value;
    }
}