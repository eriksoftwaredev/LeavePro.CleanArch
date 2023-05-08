using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeavePro.CleanArch.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;

namespace LeavePro.CleanArch.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;

public record GetLeaveTypeDetailsQuery(int Id) : IRequest<LeaveTypeDetailsDto>;