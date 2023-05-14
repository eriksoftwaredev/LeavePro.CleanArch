using AutoMapper;
using Blazored.LocalStorage;
using LeavePro.CleanArch.BlazorUI.Contracts;
using LeavePro.CleanArch.BlazorUI.Models.LeaveTypes;
using LeavePro.CleanArch.BlazorUI.Services.Base;

namespace LeavePro.CleanArch.BlazorUI.Services;

public class LeaveTypeService : BaseHttpService, ILeaveTypeService
{
    private readonly IMapper _mapper;

    public LeaveTypeService(IClient client, IMapper mapper, ILocalStorageService localStorageService) 
        : base(client, localStorageService)
    {
        _mapper = mapper;
    }

    public async Task<List<LeaveTypeVM>> GetAllLeaveTypes()
    {
        await AddBearerToken();

        var leaveTypes = await _client.LeaveTypesAllAsync();

        return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);
    }

    public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
    {
        await AddBearerToken();

        var leaveType = await _client.LeaveTypesGETAsync(id);

        return _mapper.Map<LeaveTypeVM>(leaveType);
    }

    public async Task<Response<Guid>> CreateLeaveType(LeaveTypeVM leaveType)
    {
        try
        {
            await AddBearerToken();

            var createLeaveTypeCommand = _mapper.Map<CreateLeaveTypeCommand>(leaveType);

            await _client.LeaveTypesPOSTAsync(createLeaveTypeCommand);

            return new Response<Guid>()
            {
                Success = true,
            };
        }
        catch (ApiException ex)
        {
            Console.WriteLine($"ssss: {ex.Message} innere: {ex.InnerException?.Message}");
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypeVM leaveType)
    {
        try
        {
            await AddBearerToken();

            var updateLeaveTypeCommand = _mapper.Map<UpdateLeaveTypeCommand>(leaveType);

            await _client.LeaveTypesPUTAsync(id, updateLeaveTypeCommand);

            return new Response<Guid>()
            {
                Success = true,
            };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> DeleteLeaveType(int id)
    {
        try
        {
            await AddBearerToken();

            await _client.LeaveTypesDELETEAsync(id);

            return new Response<Guid>()
            {
                Success = true,
            };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}