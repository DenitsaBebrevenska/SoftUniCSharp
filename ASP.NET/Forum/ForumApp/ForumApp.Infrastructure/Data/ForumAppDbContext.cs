using ForumApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Infrastructure.Data;
public class ForumAppDbContext : DbContext
{
	public ForumAppDbContext(DbContextOptions options)
	: base(options)

	{

	}

	public DbSet<Post> Posts { get; set; }
}
