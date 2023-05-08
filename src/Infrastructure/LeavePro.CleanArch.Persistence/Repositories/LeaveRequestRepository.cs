using LeavePro.CleanArch.Application.Contracts.Persistence;
using LeavePro.CleanArch.Domain;
using LeavePro.CleanArch.Persistence.DatabaseContext;

namespace LeavePro.CleanArch.Persistence.Repositories;

public class LeaveRequestRepository : Repository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(LmDbContext context) : base(context)
    {
    }

}