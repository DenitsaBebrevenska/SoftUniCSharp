using ForumApp.Infrastructure.Data.Configuration;
using ForumApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Infrastructure.Data;
public class ForumAppDbContext : DbContext
{
	public ForumAppDbContext(DbContextOptions options)
	: base(options)

	{

	}

	public DbSet<Post> Posts { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new PostConfiguration());
		base.OnModelCreating(modelBuilder);
	}
}
