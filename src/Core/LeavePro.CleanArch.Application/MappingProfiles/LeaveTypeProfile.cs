using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeavePro.CleanArch.Application.Features.LeaveType.Commands.CreateLeaveType;
using LeavePro.CleanArch.Application.Features.LeaveType.Commands.UpdateLeaveType;
using LeavePro.CleanArch.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using LeavePro.CleanArch.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using LeavePro.CleanArch.Domain;

namespace LeavePro.CleanArch.Application.MappingProfiles;

public class LeaveTypeProfile : Profile
{
    public LeaveTypeProfile()
    {
        CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
        CreateMap<LeaveType, LeaveTypeDetailsDto>();
        CreateMap<CreateLeaveTypeCommand, LeaveType>();
        CreateMap<UpdateLeaveTypeCommand, LeaveType>();
    }

}
