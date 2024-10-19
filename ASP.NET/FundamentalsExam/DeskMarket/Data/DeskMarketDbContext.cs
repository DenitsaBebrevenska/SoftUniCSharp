using DeskMarket.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DeskMarket.Data
{
    /// <summary>
    /// Represents the database context for the DeskMarket application, providing access to the application's entities and configuration.
    /// Inherits from <see cref="IdentityDbContext"/> to support ASP.NET Core Identity for authentication and authorization.
    /// </summary>
    public class DeskMarketDbContext(DbContextOptions<DeskMarketDbContext> options) : IdentityDbContext(options)
    {
        /// <summary>
        /// Gets or sets the <see cref="DbSet{Product}"/> for the products in the application.
        /// </summary>
        public DbSet<Product> Products { get; set; } = null!;

        /// <summary>
        /// Gets or sets the <see cref="DbSet{Category}"/> for the categories in the application.
        /// </summary>
        public DbSet<Category> Categories { get; set; } = null!;

        /// <summary>
        /// Gets or sets the <see cref="DbSet{ProductClient}"/> for the relationships between products and clients (users).
        /// </summary>
        public DbSet<ProductClient> ProductsClients { get; set; } = null!;

        /// <summary>
        /// Configures the entity relationships, seed data, and soft delete filters using the <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="builder">The model builder used to configure entity mappings.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seeding initial data for categories
            builder
                .Entity<Category>()
                .HasData(
                    new Category { Id = 1, Name = "Laptops" },
                    new Category { Id = 2, Name = "Workstations" },
                    new Category { Id = 3, Name = "Accessories" },
                    new Category { Id = 4, Name = "Desktops" },
                    new Category { Id = 5, Name = "Monitors" });

            //Configuring delete behavior for the ProductClient relationship
            builder.Entity<ProductClient>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductsClients)
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            //Adding a query filter to exclude soft deleted products
            builder.Entity<Product>()
                .HasQueryFilter(p => !p.IsDeleted);

            //Adding explicit filter for the joined table to not get unexpected results if product is marked as deleted
            builder.Entity<ProductClient>()
                .HasQueryFilter(pc => !pc.Product.IsDeleted);
        }
    }
}
