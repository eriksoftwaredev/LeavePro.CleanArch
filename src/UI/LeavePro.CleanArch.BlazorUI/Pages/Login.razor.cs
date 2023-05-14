using LeavePro.CleanArch.BlazorUI.Contracts;
using LeavePro.CleanArch.BlazorUI.Models;
using Microsoft.AspNetCore.Components;

namespace LeavePro.CleanArch.BlazorUI.Pages
{
    public partial class Login
    {
        public LoginVM Model { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IAuthenticationService AuthenticationService { get; set; }

        public string Message { get; set; }

        public Login()
        {

        }

        protected override void OnInitialized()
        {
            Model=new LoginVM();
        }

        protected async Task HandleLogin()
        {
            if(await AuthenticationService.AuthenticateAsync(Model.Email,Model.Password))
                NavigationManager.NavigateTo("/");

            Message = "username/password combination unknown";
        }
    }
}
