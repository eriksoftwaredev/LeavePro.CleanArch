using Blazored.LocalStorage;
using LeavePro.CleanArch.BlazorUI.Contracts;
using LeavePro.CleanArch.BlazorUI.Providers;
using LeavePro.CleanArch.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace LeavePro.CleanArch.BlazorUI.Services;

public class AuthenticationService : BaseHttpService, IAuthenticationService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthenticationService(IClient client, ILocalStorageService localStorage,
        AuthenticationStateProvider authenticationStateProvider) 
        : base(client, localStorage)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        try
        {
            var request = new AuthRequest()
            {
                Email = email,
                Password = password
            };

            var authenticationResponse = await _client.LoginAsync(request);

            if (authenticationResponse.Token != null)
            {
                await _localStorage.SetItemAsync("token", authenticationResponse.Token);

                // Set claims in blazor and login state
                await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();

                return true;
            }

            return false;
        }
        catch (Exception)
        {
            return false;
        }

  
    }

    public async Task<bool> RegisterAsync(string firstName, string lastName,
        string userName, string email, string password)
    {
        var request = new RegistrationRequest
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            UserName = userName,
            Password = password,
        };

        var response = await _client.RegisterAsync(request);

        if (!string.IsNullOrEmpty(response.UseId))
        {
            return true;
        }

        return false;
    }

    public async Task Logout()
    {
        // Remove claims in Blazor and invalidate login state
        await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
    }
}