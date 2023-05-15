using Blazored.Toast.Services;
using LeavePro.CleanArch.BlazorUI.Contracts;
using LeavePro.CleanArch.BlazorUI.Models.LeaveTypes;
using LeavePro.CleanArch.BlazorUI.Services;
using Microsoft.AspNetCore.Components;

namespace LeavePro.CleanArch.BlazorUI.Pages.LeaveTypes
{
    public partial class Index
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public ILeaveTypeService LeaveTypeService { get; set; }
        [Inject] public ILeaveAllocationService LeaveAllocationService { get; set; }
        [Inject] IToastService toastService { get; set; }
        public List<LeaveTypeVM> LeaveTypes { get; private set; }
        public string Message { get; set; } = String.Empty;

        protected void CreateLeaveType()
        {
            NavigationManager.NavigateTo("/LeaveTypes/Create/");
        }

        protected void AllocateLeaveType(int id)
        {
            LeaveAllocationService.CreateLeaveAllocations(id);
        }

        protected void EditLeaveType(int id)
        {
            NavigationManager.NavigateTo($"/LeaveTypes/Edit/{id}");
        }

        protected void LeaveTypeDetails(int id)
        {
            NavigationManager.NavigateTo($"/LeaveTypes/details/{id}");
        }

        protected async Task DeleteLeaveType(int id)
        {
            var response = await LeaveTypeService.DeleteLeaveType(id);
            if (response.Success)
            {
                toastService.ShowSuccess("Leave Type deleted Successfully");
                await OnInitializedAsync();
            }
            else
            {
                Message = response.Message;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            LeaveTypes = await LeaveTypeService.GetAllLeaveTypes();
        }
    }
}
