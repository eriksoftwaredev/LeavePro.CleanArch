using MediatR;

namespace LeavePro.CleanArch.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public record GetLeaveAllocationWithDetailsQuery(int Id) : IRequest<LeaveAllocationDetailsDto>;