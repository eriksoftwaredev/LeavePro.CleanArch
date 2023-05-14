using LeavePro.CleanArch.BlazorUI.Contracts;
using LeavePro.CleanArch.BlazorUI.Models.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace LeavePro.CleanArch.BlazorUI.Pages.LeaveTypes
{
    public partial class Details
    {
        [Inject]
        ILeaveTypeService _client { get; set; }

        [Parameter]
        public int id { get; set; }

        LeaveTypeVM leaveType = new LeaveTypeVM();

        protected override async Task OnParametersSetAsync()
        {
            leaveType = await _client.GetLeaveTypeDetails(id);
        }
    }
}