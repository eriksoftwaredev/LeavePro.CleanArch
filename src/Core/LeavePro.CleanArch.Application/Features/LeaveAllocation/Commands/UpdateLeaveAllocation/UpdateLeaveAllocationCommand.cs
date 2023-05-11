using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeavePro.CleanArch.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;

namespace LeavePro.CleanArch.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;

public class UpdateLeaveAllocationCommand : IRequest<Unit>
{
    public int Id { get; init; }
    public int DayNumber { get; init; }
    public int Period { get; init; }
    public int LeaveTypeId { get; init; }
}