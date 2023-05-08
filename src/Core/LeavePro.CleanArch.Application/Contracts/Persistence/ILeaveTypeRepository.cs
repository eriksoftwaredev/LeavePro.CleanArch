using LeavePro.CleanArch.Domain;

namespace LeavePro.CleanArch.Application.Contracts.Persistence;

public interface ILeaveTypeRepository : IRepository<LeaveType>
{
    Task<bool> IsLeaveTypeUnique(string name);
}