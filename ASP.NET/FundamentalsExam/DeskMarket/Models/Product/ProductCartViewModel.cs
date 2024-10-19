namespace DeskMarket.Models.Product;


/// <summary>
/// Represents the view model for a product in the shopping cart.
/// Contains basic details about the product such as its name, image, and price.
/// Not being validated as it doesn`t deal with user`s input.
/// </summary>
public class ProductCartViewModel
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
    /// Gets or sets the URL of the product's image.
    /// Non-mandatory field.
    /// </summary>
    public string? ImageUrl { get; set; }

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }
}
