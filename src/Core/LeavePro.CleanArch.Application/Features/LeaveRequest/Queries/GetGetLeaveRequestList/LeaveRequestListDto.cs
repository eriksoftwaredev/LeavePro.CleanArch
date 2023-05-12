using LeavePro.CleanArch.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

namespace LeavePro.CleanArch.Application.Features.LeaveRequest.Queries.GetGetLeaveRequestList;

public class LeaveRequestListDto
{
    public int Id { get; init; }
    //public Employee Employee { get; init; }
    public string ApplicantEmployeeId { get; init; }
    public DateTime RequestDate { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public LeaveTypeDto LeaveType { get; init; }
    public bool? Approved { get; init; }
    public bool? Cancelled { get; init; }

}