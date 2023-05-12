using LeavePro.CleanArch.Domain;

namespace LeavePro.CleanArch.Application.Contracts.Persistence;

public interface ILeaveRequestRepository : IRepository<LeaveRequest>
{
    Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
    Task<IReadOnlyList<LeaveRequest>> GetAllLeaveRequestsWithDetails();
    Task<IReadOnlyList<LeaveRequest>> GetAllEmployeeLeaveRequestsWithDetails(string employeeId);
    Task Cancel(LeaveRequest leaveRequest);
    Task Approve(LeaveRequest leaveRequest);
}