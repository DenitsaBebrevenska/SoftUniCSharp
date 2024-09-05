using HouseRentingSystem.Infrastructure.Data.Models;
using HouseRentingSystem.Infrastructure.Data.SeedDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Infrastructure.Data.Configuration;
public class AgentConfiguration : IEntityTypeConfiguration<Agent>
{
	public void Configure(EntityTypeBuilder<Agent> builder)
	{
		var data = new SeedData();
		builder.HasData(data.Agent);
	}
}
