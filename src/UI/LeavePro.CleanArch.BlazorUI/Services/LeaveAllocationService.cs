using Blazored.LocalStorage;
using LeavePro.CleanArch.BlazorUI.Contracts;
using LeavePro.CleanArch.BlazorUI.Services.Base;

namespace LeavePro.CleanArch.BlazorUI.Services;

public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService
{
    public LeaveAllocationService(IClient client, ILocalStorageService localStorageService)
        : base(client, localStorageService)
    {
    }

    public Task<Response<Guid>> CreateLeaveAllocations(int leaveTypeId)
    {
        throw new NotImplementedException();
    }
}