using LeavePro.CleanArch.Application.Contracts.Persistence;
using LeavePro.CleanArch.Domain;
using LeavePro.CleanArch.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace LeavePro.CleanArch.Persistence.Repositories;

public class LeaveRequestRepository : Repository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(LmDbContext context) : base(context)
    {
    }

    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        return await Context.LeaveRequests
            .Include(e => e.LeaveType)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IReadOnlyList<LeaveRequest>> GetAllLeaveRequestsWithDetails()
    {
        return await Context.LeaveRequests.AsNoTracking()
            .Include(e => e.LeaveType)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IReadOnlyList<LeaveRequest>> GetAllEmployeeLeaveRequestsWithDetails(string employeeId)
    {
        return await Context.LeaveRequests.AsNoTracking()
            .Where(e => e.ApplicantEmployeeId == employeeId)
            .Include(e => e.LeaveType)
            .AsNoTracking()
            .ToListAsync();
    }
}