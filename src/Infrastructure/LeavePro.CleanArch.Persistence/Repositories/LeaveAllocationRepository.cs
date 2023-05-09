using LeavePro.CleanArch.Application.Contracts.Persistence;
using LeavePro.CleanArch.Domain;
using LeavePro.CleanArch.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace LeavePro.CleanArch.Persistence.Repositories;

public class LeaveAllocationRepository : Repository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(LmDbContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<LeaveAllocation>> GetAllLeaveAllocationsWithDetails()
    {
        return await Context.LeaveAllocations
            .Include(e => e.LeaveType)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        return await Context.LeaveAllocations
            .Include(e => e.LeaveType)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IReadOnlyList<LeaveAllocation>> GetEmployeeLeaveAllocationsWithDetails(string employeeId)
    {
        return await Context.LeaveAllocations.Where(e => e.EmployeeId == employeeId)
            .Include(e => e.LeaveType)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
    {
        return await Context.LeaveAllocations.AnyAsync(e => e.LeaveTypeId == leaveTypeId
                                                            && e.DayNumber == period
                                                            && e.EmployeeId == employeeId);
    }

    public async Task<IReadOnlyList<LeaveAllocation>> GetEmployeeAllocations(string employeeId, int leaveTypeId)
    {
        return await Context.LeaveAllocations.Where(e => e.EmployeeId == employeeId
                                                    && e.LeaveTypeId == leaveTypeId)
                                                    .AsNoTracking()
                                                    .ToListAsync();
    }
}