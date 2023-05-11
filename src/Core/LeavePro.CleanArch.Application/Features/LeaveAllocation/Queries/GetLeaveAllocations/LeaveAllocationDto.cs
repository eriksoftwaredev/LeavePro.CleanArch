using LeavePro.CleanArch.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

namespace LeavePro.CleanArch.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

public class LeaveAllocationDto
{
    public int Id { get; init; }
    public int DayNumber { get; init; }
    public int Period { get; init; }
    public LeaveTypeDto LeaveType { get; init; }
    public int LeaveTypeId { get; init; }
}