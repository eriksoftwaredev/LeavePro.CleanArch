using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeavePro.CleanArch.Identity.Configuration;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "02a58a1f-c315-4e74-b646-0bdd68ddb33a",
                UserId = "0e4bc686-69f3-4461-b8b5-fbcca431091c"
            },
            new IdentityUserRole<string>
            {
                RoleId = "06a5b561-5375-4fed-8be4-00ab2c5f0082",
                UserId = "06bb72ca-f83f-44cb-9f23-7dc3a1c336ea"
            });
    }
}