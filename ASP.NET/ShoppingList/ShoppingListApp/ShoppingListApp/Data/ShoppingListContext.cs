using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Data.Models;

namespace ShoppingListApp.Data;

public class ShoppingListContext : DbContext
{
	public ShoppingListContext(DbContextOptions options)
	: base(options)
	{

	}

	public DbSet<Product> Products { get; set; }

	public DbSet<ProductNote> ProductNotes { get; set; }
}
