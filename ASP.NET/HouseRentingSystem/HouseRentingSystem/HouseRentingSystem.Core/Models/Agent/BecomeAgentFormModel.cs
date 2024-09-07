using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Core.Constants.ValidationErrorMessages;
using static HouseRentingSystem.Infrastructure.Data.Constants.TableConstraints;
namespace HouseRentingSystem.Core.Models.Agent;

public class BecomeAgentFormModel
{
    [Required(ErrorMessage = RequiredFieldMessage)]
    [StringLength(AgentPhoneNumberMaxLength,
        MinimumLength = AgentPhoneNumberMinLength,
        ErrorMessage = StringLengthMessage)]
    [Display(Name = "Phone number")]
    [Phone]
    public string PhoneNumber { get; init; } = null!;
}
