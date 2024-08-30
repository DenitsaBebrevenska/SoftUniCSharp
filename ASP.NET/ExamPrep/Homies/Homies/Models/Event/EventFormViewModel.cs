using Homies.Models.Type;
using System.ComponentModel.DataAnnotations;
using static Homies.Common.Constants;
using static Homies.Data.Configuration.DataConstraints;

namespace Homies.Models.Event;

public class EventFormViewModel
{
    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    [StringLength(EventNameMaxLength,
        MinimumLength = EventNameMinLength,
        ErrorMessage = StringLengthErrorMessage)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    [StringLength(EventDescriptionMaxLength,
        MinimumLength = EventDescriptionMinLength,
        ErrorMessage = StringLengthErrorMessage)]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    public string Start { get; set; } = string.Empty;

    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    public string End { get; set; } = string.Empty;

    public int TypeId { get; set; }

    public IEnumerable<TypeFormViewModel> AvailableTypes { get; set; } = new List<TypeFormViewModel>();

}
