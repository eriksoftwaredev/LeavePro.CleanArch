using LeavePro.CleanArch.BlazorUI.Services.Base;

namespace LeavePro.CleanArch.BlazorUI.Contracts;

public interface ILeaveAllocationService
{
    Task<Response<Guid>> CreateLeaveAllocations(int leaveTypeId);
}