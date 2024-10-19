namespace DeskMarket.Common.Constants;

/// <summary>
/// Constants for both data and view model validations
/// </summary>
public static class ModelConstants
{
    /// <summary>
    /// The minimum string length of a product`s name
    /// </summary>
    public const int ProductNameMinLength = 2;

    /// <summary>
    /// The maximum string length of a product`s name
    /// </summary>
    public const int ProductNameMaxLength = 60;


    /// <summary>
    /// The minimum string length of a product`s description
    /// </summary>
    public const int ProductDescriptionMinLength = 10;

    /// <summary>
    /// The maximum string length of a product`s description
    /// </summary>
    public const int ProductDescriptionMaxLength = 250;

    /// <summary>
    /// The minimum price of a product
    /// </summary>
    public const decimal ProductPriceMinValue = 1m;

    /// <summary>
    /// The maximum price of a product
    /// </summary>
    public const decimal ProductPriceMaxValue = 3_000m;


    /// <summary>
    /// The minimum string length of a category`s name
    /// </summary>
    public const int CategoryNameMinLength = 3;

    /// <summary>
    /// The maximum string length of a category`s name
    /// </summary>
    public const int CategoryNameMaxLength = 20;
}
