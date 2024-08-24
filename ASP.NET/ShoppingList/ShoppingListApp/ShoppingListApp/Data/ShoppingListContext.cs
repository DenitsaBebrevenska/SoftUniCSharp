using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Data.Models;

namespace ShoppingListApp.Data;

public class ShoppingListContext : DbContext
{
	public ShoppingListContext(DbContextOptions options)
	: base(options)
	{

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Product>()
			.HasData(
				new Product { Id = 1, Name = "Milk" },
				new Product { Id = 2, Name = "Bananas" });

		base.OnModelCreating(modelBuilder);
	}

	public DbSet<Product> Products { get; set; }

	public DbSet<ProductNote> ProductNotes { get; set; }
}
