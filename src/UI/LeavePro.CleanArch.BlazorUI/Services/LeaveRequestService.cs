using Blazored.LocalStorage;
using LeavePro.CleanArch.BlazorUI.Contracts;
using LeavePro.CleanArch.BlazorUI.Services.Base;

namespace LeavePro.CleanArch.BlazorUI.Services;

public class LeaveRequestService : BaseHttpService, ILeaveRequestService
{
    public LeaveRequestService(IClient client, ILocalStorageService localStorageService)
        : base(client, localStorageService)
    {
    }
}