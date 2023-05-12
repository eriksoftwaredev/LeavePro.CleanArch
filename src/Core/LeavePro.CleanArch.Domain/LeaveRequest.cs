using LeavePro.CleanArch.Domain.Common;

namespace LeavePro.CleanArch.Domain;

public class LeaveRequest : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public LeaveType? LeaveType { get; set; }
    public int LeaveTypeId { get; set; }

    public DateTime RequestDate { get; set; }
    public string? RequestComment { get; set; }

    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }

    public string ApplicantEmployeeId { get; set; }= string.Empty;
}