using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DeskMarket.Data.Models;

/// <summary>
/// Represents the relationship between a product and a client who has purchased the product.
/// </summary>
[PrimaryKey(nameof(ProductId), nameof(ClientId))]
public class ProductClient
{
    /// <summary>
    /// Gets or sets the unique identifier for the product.
    /// </summary>
    [Comment("The product identifier")]
    public int ProductId { get; set; }

    /// <summary>
    /// Navigation property to the product associated with the client.
    /// </summary>
    public Product Product { get; set; } = null!;

    /// <summary>
    /// Gets or sets the unique identifier for the client (user) who purchased or added the product.
    /// </summary>
    [Comment("The user identifier that added the product")]
    public string ClientId { get; set; } = null!;

    /// <summary>
    /// Navigation property to the client (user) who purchased or added the product.
    /// </summary>
    public IdentityUser Client { get; set; } = null!;
}
