using AutoMapper;
using LeavePro.CleanArch.BlazorUI.Models.LeaveTypes;
using LeavePro.CleanArch.BlazorUI.Services.Base;

namespace LeavePro.CleanArch.BlazorUI.MappingProfiles;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
        CreateMap<LeaveTypeVM, CreateLeaveTypeCommand>();
        CreateMap<LeaveTypeVM, UpdateLeaveTypeCommand>();
    }
}
