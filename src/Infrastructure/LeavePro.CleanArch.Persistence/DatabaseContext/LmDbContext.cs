using LeavePro.CleanArch.Domain;
using LeavePro.CleanArch.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace LeavePro.CleanArch.Persistence.DatabaseContext;

public class LmDbContext : DbContext
{
    public LmDbContext(DbContextOptions<LmDbContext> options) : base(options)
    {

    }

    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LmDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entityEntry in base.ChangeTracker.Entries<BaseEntity>()
                     .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entityEntry.Entity.UpdatedDate = DateTime.Now;

            if (entityEntry.State == EntityState.Added)
                entityEntry.Entity.CreatedDate = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}