using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LeavePro.CleanArch.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;

public record CreateLeaveAllocationCommand(int LeaveTypeId) : IRequest<int>;