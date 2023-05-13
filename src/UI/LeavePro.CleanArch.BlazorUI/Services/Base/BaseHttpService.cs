namespace LeavePro.CleanArch.BlazorUI.Services.Base;

public class BaseHttpService
{
    protected IClient _client;

    public BaseHttpService(IClient client)
    {
        _client = client;
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
}