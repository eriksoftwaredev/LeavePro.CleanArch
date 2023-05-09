using LeavePro.CleanArch.Domain;

namespace LeavePro.CleanArch.Application.Contracts.Persistence;

public interface ILeaveAllocationRepository : IRepository<LeaveAllocation>
{
    Task<IReadOnlyList<LeaveAllocation>> GetAllLeaveAllocationsWithDetails();
    Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
    Task<IReadOnlyList<LeaveAllocation>> GetEmployeeLeaveAllocationsWithDetails(string employeeId);
    Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period);
    Task<IReadOnlyList<LeaveAllocation>> GetEmployeeAllocations(string employeeId, int leaveTypeId);

}