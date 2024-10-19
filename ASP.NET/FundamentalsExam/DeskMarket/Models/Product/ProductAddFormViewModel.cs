using DeskMarket.Attributes;
using DeskMarket.Models.Category;
using System.ComponentModel.DataAnnotations;
using static DeskMarket.Common.Constants.GlobalConstants;
using static DeskMarket.Common.Constants.ModelConstants;

namespace DeskMarket.Models.Product;

/// <summary>
/// Represents the view model used to add a new product.
/// Used to transfer product data between the view and the controller when creating a new product.
/// Deals with user`s input therefore is being validated.
/// </summary>
public class ProductAddFormViewModel
{
    /// <summary>
    /// Gets or sets the name of the product.
    /// Must be between the specified minimum and maximum length.
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(
        ProductNameMaxLength,
        MinimumLength = ProductNameMinLength,
        ErrorMessage = StringLengthValidationErrorMessage)]
    public string ProductName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the price of the product.
    /// Must be within the specified range.
    /// </summary>
    [Range((double)ProductPriceMinValue, (double)ProductPriceMaxValue)]
    public double Price { get; set; }

    /// <summary>
    /// Gets or sets the description of the product.
    /// Must be between the specified minimum and maximum length.
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(
        ProductDescriptionMaxLength,
        MinimumLength = ProductDescriptionMinLength,
        ErrorMessage = StringLengthValidationErrorMessage)]
    public string Description { get; set; } = null!;

    /// <summary>
    /// Gets or sets the URL of the product's image.
    /// Non-mandatory field.
    /// </summary>
    public string? ImageUrl { get; set; }

    /// <summary>
    /// Gets or sets the date when the product was added.
    /// Must be in the correct date format defined in the constants.
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [IsCorrectDateFormat(DefaultDateTimeFormat)]
    public string AddedOn { get; set; } = null!;

    /// <summary>
    /// Gets or sets the identifier for the product's category.
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the list of available categories for the product.
    /// Used to populate category options in the form.
    /// </summary>
    public ICollection<CategoryFormViewModel> Categories { get; set; } = new List<CategoryFormViewModel>();
}
