namespace DeskMarket.Models.Product;

/// <summary>
/// Represents the view model for detailed information about a product.
/// This class contains the product's attributes, including its name, price, description, and seller information.
/// Not being validated as it doesn`t deal with user`s input.
/// </summary>
public class ProductDetailsViewModel
{
    /// <summary>
    /// Gets or sets the product identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string ProductName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Gets or sets the URL of the product's image.
    /// Non-mandatory field.
    /// </summary>
    public string? ImageUrl { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the product was added.
    /// </summary>
    public string AddedOn { get; set; } = null!;

    /// <summary>
    /// Gets or sets the name of the category to which the product belongs.
    /// </summary>
    public string CategoryName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the name of the seller associated with the product.
    /// </summary>
    public string Seller { get; set; } = null!;

    /// <summary>
    /// Gets or sets a value indicating whether the current user has the product in his cart.
    /// </summary>
    public bool HasBought { get; set; }

}
