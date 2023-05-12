using LeavePro.CleanArch.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

namespace LeavePro.CleanArch.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail;

public class LeaveRequestDetailDto
{
    public int Id { get; init; }
    //public Employee Employee { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public string ApplicantEmployeeId { get; init; }
    public LeaveTypeDto LeaveType { get; init; }
    public int LeaveTypeId { get; init; }
    public DateTime RequestDate { get; init; }
    public string RequestComment { get; init; }
    public DateTime? DateActioned { get; init; }
    public bool? Approved { get; init; }
    public bool Cancelled { get; init; }
}