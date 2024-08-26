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
		modelBuilder.Entity<Post>()
			.HasData(
				new Post() { Id = 1, Tittle = "First", Content = "My first post!" },
				new Post() { Id = 2, Tittle = "Second", Content = "My second post!" },
				new Post() { Id = 3, Tittle = "Third", Content = "My third post!" }
				);
		base.OnModelCreating(modelBuilder);
	}
}
