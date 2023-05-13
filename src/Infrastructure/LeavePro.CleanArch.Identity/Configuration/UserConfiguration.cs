using LeavePro.CleanArch.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeavePro.CleanArch.Identity.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();

        builder.HasData(
            new ApplicationUser()
            {
                Id = "06bb72ca-f83f-44cb-9f23-7dc3a1c336ea",
                Email = "admin@localhost.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM",
                FirstName = "System",
                LastName = "Admin",
                UserName = "admin@localhost.com",
                NormalizedUserName = "ADMIN@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, "Pa$sword2023"),
                EmailConfirmed = true
            },
            new ApplicationUser()
            {
                Id = "0e4bc686-69f3-4461-b8b5-fbcca431091c",
                Email = "user@localhost.com",
                NormalizedEmail = "USER@LOCALHOST.COM",
                FirstName = "System",
                LastName = "User",
                UserName = "user@localhost.com",
                NormalizedUserName = "USER@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, "Pa$sword2023"),
                EmailConfirmed = true
            }
        );
    }
}