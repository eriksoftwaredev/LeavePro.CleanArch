using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeavePro.CleanArch.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeavePro.CleanArch.Identity.DbContext;

public class LmIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public LmIdentityDbContext(DbContextOptions<LmIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(LmIdentityDbContext).Assembly);
    }
}

