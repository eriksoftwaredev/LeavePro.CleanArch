using System.Net.Http.Headers;
using Blazored.LocalStorage;

namespace LeavePro.CleanArch.BlazorUI.Services.Base;

public class BaseHttpService
{
    protected IClient _client;
    protected readonly ILocalStorageService _localStorage;

    public BaseHttpService(IClient client, ILocalStorageService localStorage)
    {
        _client = client;
        _localStorage = localStorage;
    }

    public Response<TGuid> ConvertApiExceptions<TGuid>(ApiException ex)
    {
        switch (ex.StatusCode)
        {
            case 400:
                return new Response<TGuid>()
                {
                    Message = "Invalid data was submitted.",
                    Success = false,
                };
            case 404:
                return new Response<TGuid>()
                {
                    Message = "The record was not found.",
                    Success = false,
                };
            default:
                return new Response<TGuid>()
                {
                    Message = "Something went wrong, please try againlater.",
                    Success = false,
                };
        }
    }

    protected async Task AddBearerToken()
    {
        if (await _localStorage.ContainKeyAsync("token"))
        {
            _client.HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer",
                    await _localStorage.GetItemAsync<string>("token"));
        }
    }
}