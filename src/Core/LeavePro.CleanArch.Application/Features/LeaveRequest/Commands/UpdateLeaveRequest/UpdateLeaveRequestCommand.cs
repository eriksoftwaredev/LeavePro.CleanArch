using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeavePro.CleanArch.Application.Features.LeaveRequest.Shared;
using MediatR;

namespace LeavePro.CleanArch.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommand : BaseLeaveRequest, IRequest<Unit>
{
    public int Id { get; init; }
    public string RequestComment { get; init; } = string.Empty;
    public bool Cancelled { get; init; }
}