using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Core.Constants.ValidationErrorMessages;
using static HouseRentingSystem.Infrastructure.Data.Constants.TableConstraints;

namespace HouseRentingSystem.Core.Models.House;

public class HouseViewModel
{
    public int Id { get; init; }

    [Required(ErrorMessage = RequiredFieldMessage)]
    [StringLength(HouseTitleMaxLength,
        MinimumLength = HouseTitleMinLength,
        ErrorMessage = StringLengthMessage)]
    public string Title { get; init; } = null!;

    [Required(ErrorMessage = RequiredFieldMessage)]
    [StringLength(HouseAddressMaxLength,
        MinimumLength = HouseAddressMinLength,
        ErrorMessage = StringLengthMessage)]
    public string Address { get; init; } = null!;

    [Required(ErrorMessage = RequiredFieldMessage)]
    [StringLength(ImageUrlMaxLength,
        ErrorMessage = UrlMaxLengthMessage)]
    [DisplayName("Image URL")]
    public string ImageUrl { get; init; } = null!;

    [Required(ErrorMessage = RequiredFieldMessage)]
    [Range(typeof(decimal),
        HousePricePerMonthMinimum,
        HousePricePerMonthMaximum,
        ErrorMessage = PricePerMonthMessage)]
    [DisplayName("Price Per Month")]
    public decimal PricePerMonth { get; init; }

    [DisplayName("Is Rented")]
    public bool IsRented { get; init; }
}
