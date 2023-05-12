using AutoMapper;
using LeavePro.CleanArch.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using LeavePro.CleanArch.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using LeavePro.CleanArch.Application.Features.LeaveRequest.Queries.GetGetLeaveRequestList;
using LeavePro.CleanArch.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail;
using LeavePro.CleanArch.Domain;

namespace LeavePro.CleanArch.Application.MappingProfiles;

    public class LeaveRequestProfile : Profile
    {
        public LeaveRequestProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestListDto>();
            CreateMap<LeaveRequest, LeaveRequestDetailDto>();
            CreateMap<CreateLeaveRequestCommand, LeaveRequest>();
            CreateMap<UpdateLeaveRequestCommand, LeaveRequest>();
    }
    }
