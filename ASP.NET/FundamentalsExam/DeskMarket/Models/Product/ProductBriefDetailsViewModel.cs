namespace DeskMarket.Models.Product;

/// <summary>
/// Represents a brief view model for displaying product details in listings.
/// Contains key information about the product, such as its name, price, image, and the user's relationship to it.
/// Not being validated as it doesn`t deal with user`s input.
/// </summary>
public class ProductBriefDetailsViewModel
{
    /// <summary>
    /// Gets or sets the product identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the URL of the product's image.
    /// Non-mandatory field.
    /// </summary>
    public string? ImageUrl { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string ProductName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the current user is the seller of the product.
    /// </summary>
    public bool IsSeller { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the current user posses this item in his cart.
    /// </summary>
    public bool HasBought { get; set; }
}
