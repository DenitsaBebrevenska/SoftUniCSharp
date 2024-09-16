using HouseRentingSystem.Infrastructure.Data.SeedDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Infrastructure.Data.Configuration;
public class UserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
{
	public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
	{
		var data = new SeedData();

		builder.HasData(data.AdminUserClaim, data.AgentUserClaim, data.GuestUserClaim);
	}
}
