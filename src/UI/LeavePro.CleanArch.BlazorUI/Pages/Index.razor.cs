using LeavePro.CleanArch.BlazorUI.Contracts;
using LeavePro.CleanArch.BlazorUI.Providers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace LeavePro.CleanArch.BlazorUI.Pages
{
    public partial class Index
    {
        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IAuthenticationService AuthenticationService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ((ApiAuthenticationStateProvider)AuthenticationStateProvider)
                .GetAuthenticationStateAsync();
        }

        protected void GoToLogin()
        {
            NavigationManager.NavigateTo("login");
        }

        protected void GoToRegister()
        {
            NavigationManager.NavigateTo("register");
        }

        protected async Task Logout()
        {
            await AuthenticationService.Logout();
        }
    }
}
