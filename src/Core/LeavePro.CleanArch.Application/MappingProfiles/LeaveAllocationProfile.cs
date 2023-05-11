using AutoMapper;
using LeavePro.CleanArch.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using LeavePro.CleanArch.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using LeavePro.CleanArch.Domain;

namespace LeavePro.CleanArch.Application.MappingProfiles;

public class LeaveAllocationProfile : Profile
{
    public LeaveAllocationProfile()
    {
        CreateMap<LeaveAllocationDto, LeaveAllocation>().ReverseMap();
        CreateMap<LeaveAllocation, LeaveAllocationDetailsDto>();
    }
}