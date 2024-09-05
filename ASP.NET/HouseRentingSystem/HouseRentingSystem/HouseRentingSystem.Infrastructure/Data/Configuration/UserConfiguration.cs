using HouseRentingSystem.Infrastructure.Data.SeedDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Infrastructure.Data.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
{
	public void Configure(EntityTypeBuilder<IdentityUser> builder)
	{
		var data = new SeedData();

		builder.HasData(data.AgentUser, data.GuestUser);
	}
}
