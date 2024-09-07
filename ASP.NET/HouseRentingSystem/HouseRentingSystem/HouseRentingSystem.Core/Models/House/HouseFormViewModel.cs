using HouseRentingSystem.Core.Models.Category;
using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Core.Constants.ValidationErrorMessages;
using static HouseRentingSystem.Infrastructure.Data.Constants.TableConstraints;

namespace HouseRentingSystem.Core.Models.House;

public class HouseFormViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = RequiredFieldMessage)]
    [StringLength(HouseTitleMaxLength,
        MinimumLength = HouseTitleMinLength,
        ErrorMessage = StringLengthMessage)]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldMessage)]
    [StringLength(HouseDescriptionMaxLength,
        MinimumLength = HouseDescriptionMinLength,
        ErrorMessage = StringLengthMessage)]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldMessage)]
    [StringLength(ImageUrlMaxLength,
        ErrorMessage = UrlMaxLengthMessage)]
    [Display(Name = "Image URL")]
    public string ImageUrl { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldMessage)]
    [StringLength(HouseAddressMaxLength,
        MinimumLength = HouseAddressMinLength,
        ErrorMessage = StringLengthMessage)]
    public string Address { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldMessage)]
    [Range(typeof(decimal),
        HousePricePerMonthMinimum,
        HousePricePerMonthMaximum,
        ErrorMessage = PricePerMonthMessage)]
    [Display(Name = "Price Per Month")]
    public decimal PricePerMonth { get; set; }

    public int CategoryId { get; set; }

    public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
}
