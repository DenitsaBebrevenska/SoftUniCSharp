namespace DeskMarket.Models.Product;

/// <summary>
/// Represents the view model for deleting a product.
/// Contains information about the product to be deleted, including its name and the seller details.
/// Not being validated as it doesn`t deal with user`s input.
/// </summary>
public class ProductDeleteViewModel
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
    /// Gets or sets the name of the seller associated with the product.
    /// </summary>
    public string Seller { get; set; } = null!;

    /// <summary>
    /// Gets or sets the identifier of the seller associated with the product.
    /// </summary>
    public string SellerId { get; set; } = null!;
}
