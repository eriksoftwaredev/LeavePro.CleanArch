using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LeavePro.CleanArch.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

public record GetLeaveAllocationsQuery : IRequest<List<LeaveAllocationDto>>;