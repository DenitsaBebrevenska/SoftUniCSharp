using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DeskMarket.Common.Constants.ModelConstants;

namespace DeskMarket.Data.Models;

/// <summary>
/// Represents a product listed for sale.
/// </summary>
public class Product
{
    /// <summary>
    /// Gets or sets the unique identifier for the product.
    /// </summary>
    [Key]
    [Comment("Product identifier")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// The name is required and has a maximum length defined by <see cref="ProductNameMaxLength"/>.
    /// </summary>
    [Required]
    [MaxLength(ProductNameMaxLength)]
    [Comment("The name of the product")]
    public string ProductName { get; set; } = null!;

    /// <summary>
    /// Gets or sets a brief description of the product.
    /// The description is required and has a maximum length defined by <see cref="ProductDescriptionMaxLength"/>.
    /// </summary>
    [Required]
    [MaxLength(ProductDescriptionMaxLength)]
    [Comment("Brief product description")]
    public string Description { get; set; } = null!;

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    [Precision(18, 2)]
    [Comment("The price of the product")]
    public decimal Price { get; set; }


    /// <summary>
    /// Gets or sets the URL of the product's image. Non-mandatory.
    /// </summary>
    [Comment("Image url of the product")]
    public string? ImageUrl { get; set; }

    /// <summary>
    /// Gets or sets the seller's identifier who listed the product.
    /// </summary>

    [Comment("The product`s seller identifier")]
    public string SellerId { get; set; } = null!;

    /// <summary>
    /// Navigation property to the seller of the product.
    /// </summary>
    [ForeignKey(nameof(SellerId))]
    public IdentityUser Seller { get; set; } = null!;

    /// <summary>
    /// Gets or sets the date and time when the product was added to the system.
    /// </summary>
    [Required]
    [Comment("Date and time when the product was added")]
    public DateTime AddedOn { get; set; }

    /// <summary>
    /// Gets or sets the category identifier of the product.
    /// </summary>
    [Required]
    [Comment("The product`s category identifier")]
    public int CategoryId { get; set; }

    /// <summary>
    /// Navigation property to the product's category.
    /// </summary>
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = null!;

    /// <summary>
    /// Gets or sets a flag indicating whether the product is marked as deleted.
    /// </summary>
    [Required]
    [Comment("Flag for deletion")]
    public bool IsDeleted { get; set; } = default;

    /// <summary>
    /// Navigation property to the list of clients who have bought the product.
    /// </summary>
    public ICollection<ProductClient> ProductsClients { get; set; } = new List<ProductClient>();
}
