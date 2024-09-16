using HouseRentingSystem.Infrastructure.Data.Configuration;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Infrastructure.Data;
public class HomeRentingDbContext : IdentityDbContext<ApplicationUser>
{
	public DbSet<House> Houses { get; set; } = null!;

	public DbSet<Agent> Agents { get; set; } = null!;

	public DbSet<Category> Categories { get; set; } = null!;

	public HomeRentingDbContext(DbContextOptions<HomeRentingDbContext> options)
		: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.ApplyConfiguration(new UserConfiguration());
		builder.ApplyConfiguration(new AgentConfiguration());
		builder.ApplyConfiguration(new CategoryConfiguration());
		builder.ApplyConfiguration(new HouseConfiguration());
		builder.ApplyConfiguration(new UserClaimConfiguration());

		base.OnModelCreating(builder);
	}
}
