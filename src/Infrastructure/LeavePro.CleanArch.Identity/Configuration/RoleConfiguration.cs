using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeavePro.CleanArch.Identity.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole()
            {
                Id = "02a58a1f-c315-4e74-b646-0bdd68ddb33a",
                Name = "Employee",
                NormalizedName = "EMPLOYEE"
            },
            new IdentityRole()
            {
                Id = "06a5b561-5375-4fed-8be4-00ab2c5f0082",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            });
    }
}