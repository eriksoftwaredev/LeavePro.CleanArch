namespace LeavePro.CleanArch.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public class LeaveTypeDetailsDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int DefaultDays { get; init; }
    public DateTime? CreatedDate { get; init; }
    public DateTime? UpdatedDate { get; init; }
}