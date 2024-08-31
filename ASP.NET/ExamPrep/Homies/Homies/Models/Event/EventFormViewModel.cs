using Homies.Models.Type;
using System.ComponentModel.DataAnnotations;
using static Homies.Common.Constants;
using static Homies.Data.Configuration.DataConstraints;

namespace Homies.Models.Event;

/// <summary>
/// View model for /Edit and /Add form
/// Validates user input according to requirements
/// </summary>
public class EventFormViewModel
{
    /// <summary>
    /// Event name
    /// </summary>
    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    [StringLength(EventNameMaxLength,
        MinimumLength = EventNameMinLength,
        ErrorMessage = StringLengthErrorMessage)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Event description
    /// </summary>
    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    [StringLength(EventDescriptionMaxLength,
        MinimumLength = EventDescriptionMinLength,
        ErrorMessage = StringLengthErrorMessage)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Event start date and time
    /// </summary>
    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    public string Start { get; set; } = string.Empty;

    /// <summary>
    /// Event end date and time
    /// </summary>
    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    public string End { get; set; } = string.Empty;

    /// <summary>
    /// The identifier of event`s type
    /// </summary>
    public int TypeId { get; set; }

    /// <summary>
    /// A collection of type view models used for the select in the form
    /// </summary>
    public IEnumerable<TypeFormViewModel> AvailableTypes { get; set; } = new List<TypeFormViewModel>();

}
