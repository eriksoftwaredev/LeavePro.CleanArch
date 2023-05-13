using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeavePro.CleanArch.Domain;
using LeavePro.CleanArch.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace LeavePro.CleanArch.IntegrationTests;

public class LmDbContextTests
{
    private readonly LmDbContext _lmDbContext;

    public LmDbContextTests()
    {
        var dbOptions = new DbContextOptionsBuilder<LmDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _lmDbContext = new LmDbContext(dbOptions);
    }

    [Fact]
    public async Task Save_SetUpdatedDateValue()
    {
        var leaveType = new LeaveType
        {
            Id = 1,
            DefaultDays = 7,
            Name = "Vacation"
        };

        await _lmDbContext.AddAsync(leaveType);
        await _lmDbContext.SaveChangesAsync();

        leaveType.UpdatedDate.ShouldNotBeNull();
    }

    [Fact]
    public async Task Save_SetCreatedDateValue()
    {
        var leaveType = new LeaveType
        {
            Id = 1,
            DefaultDays = 7,
            Name = "Vacation"
        };

        await _lmDbContext.AddAsync(leaveType);
        await _lmDbContext.SaveChangesAsync();

        leaveType.CreatedDate.ShouldNotBeNull();
    }
}

