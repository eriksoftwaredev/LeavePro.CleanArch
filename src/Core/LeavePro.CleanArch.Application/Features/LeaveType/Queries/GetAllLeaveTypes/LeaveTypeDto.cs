using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeavePro.CleanArch.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class LeaveTypeDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int DefaultDays { get; init; }
}