using LeavePro.CleanArch.Application.Contracts.Persistence;
using LeavePro.CleanArch.Domain;
using LeavePro.CleanArch.Persistence.DatabaseContext;

namespace LeavePro.CleanArch.Persistence.Repositories;

public class LeaveAllocationRepository : Repository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(LmDbContext context) : base(context)
    {
    }

}