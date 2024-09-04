using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Infrastructure.Data;
public class HomeRentingDbContext : IdentityDbContext
{
	public HomeRentingDbContext(DbContextOptions<HomeRentingDbContext> options)
		: base(options)
	{
	}
}
