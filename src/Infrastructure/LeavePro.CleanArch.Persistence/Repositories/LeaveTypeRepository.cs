using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeavePro.CleanArch.Application.Contracts.Persistence;
using LeavePro.CleanArch.Domain;
using LeavePro.CleanArch.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace LeavePro.CleanArch.Persistence.Repositories;

public class LeaveTypeRepository : Repository<LeaveType>, ILeaveTypeRepository
{
    public LeaveTypeRepository(LmDbContext context) : base(context)
    {
    }

    public async Task<bool> IsLeaveTypeUnique(string name)
    {
        return await Context.LeaveTypes.AnyAsync(e => e.Name == name);
    }
}