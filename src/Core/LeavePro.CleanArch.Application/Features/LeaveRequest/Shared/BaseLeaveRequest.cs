using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePro.CleanArch.Application.Features.LeaveRequest.Shared;

public class BaseLeaveRequest
{
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public int LeaveTypeId { get; init; }
}
