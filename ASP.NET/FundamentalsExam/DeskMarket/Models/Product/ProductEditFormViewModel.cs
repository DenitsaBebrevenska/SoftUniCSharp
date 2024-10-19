using DeskMarket.Attributes;
using DeskMarket.Models.Category;
using System.ComponentModel.DataAnnotations;
using static DeskMarket.Common.Constants.GlobalConstants;
using static DeskMarket.Common.Constants.ModelConstants;

namespace DeskMarket.Models.Product;

/// <summary>
/// Represents the view model for editing product details.
/// This class contains properties required to update a product's information,
/// including validation attributes for data integrity.
/// Deals with user`s input therefore is being validated.
/// </summary>
public class ProductEditFormViewModel
{
    /// <summary>
    /// Gets or sets the product identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// This property is required and has validation for maximum and minimum length.
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(
        ProductNameMaxLength,
        MinimumLength = ProductNameMinLength,
        ErrorMessage = StringLengthValidationErrorMessage)]
    public string ProductName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the price of the product.
    /// This property must be within the specified range.
    /// </summary>
    [Range((double)ProductPriceMinValue, (double)ProductPriceMaxValue)]
    public double Price { get; set; }

    /// <summary>
    /// Gets or sets the description of the product.
    /// This property is required and has validation for maximum and minimum length.
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(
        ProductDescriptionMaxLength,
        MinimumLength = ProductDescriptionMinLength,
        ErrorMessage = StringLengthValidationErrorMessage)]
    public string Description { get; set; } = null!;

    /// <summary>
    /// Gets or sets the URL of the product's image. Non-mandatory field.
    /// </summary>
    public string? ImageUrl { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the product was added.
    /// This property is required and must adhere to the correct date format.
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [IsCorrectDateFormat(DefaultDateTimeFormat)]
    public string AddedOn { get; set; } = null!;

    /// <summary>
    /// Gets or sets the identifier of the category to which the product belongs.
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the seller associated with the product.
    /// This property is required.
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    public string SellerId { get; set; } = null!;

    /// <summary>
    /// Gets or sets the collection of categories available for the product.
    /// </summary>
    public ICollection<CategoryFormViewModel> Categories { get; set; } = new List<CategoryFormViewModel>();
}
