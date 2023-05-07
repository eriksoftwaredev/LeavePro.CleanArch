using LeavePro.CleanArch.Domain.Common;

namespace LeavePro.CleanArch.Domain;

public class LeaveAllocation : BaseEntity
{
    public int DayNumber { get; set; }
    public int Period { get; set; }

    public LeaveType? LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
}