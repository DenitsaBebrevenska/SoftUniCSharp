using Homies.Models.Type;
using System.ComponentModel.DataAnnotations;
using static Homies.Common.Constants;
using static Homies.Data.Configuration.DataConstraints;

namespace Homies.Models.Event;

/// <summary>
/// View model used for creating or editing events.
/// This model includes validation rules for user input and is used in both the /Edit and /Add forms.
/// </summary>
public class EventFormViewModel
{
    /// <summary>
    /// The event name
    /// This property is required and must be between <see cref="EventNameMinLength"/> and <see cref="EventNameMaxLength"/> characters long.
    /// </summary>
    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    [StringLength(EventNameMaxLength,
        MinimumLength = EventNameMinLength,
        ErrorMessage = StringLengthErrorMessage)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Event description
    /// This property is required and must be between <see cref="EventDescriptionMinLength"/> and <see cref="EventDescriptionMaxLength"/> characters long.
    /// </summary>
    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    [StringLength(EventDescriptionMaxLength,
        MinimumLength = EventDescriptionMinLength,
        ErrorMessage = StringLengthErrorMessage)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The event start date and time
    /// This property is required and should be provided in a valid date-time format
    /// </summary>
    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    public string Start { get; set; } = string.Empty;

    /// <summary>
    /// The event end date and time
    /// This property is required and should be provided in a valid date-time format
    /// </summary>
    [Required(ErrorMessage = RequiredFieldErrorMessage)]
    public string End { get; set; } = string.Empty;

    /// <summary>
    /// The identifier of event`s type
    /// This property is used to associate the event with a specific type.
    /// </summary>
    public int TypeId { get; set; }

    /// <summary>
    /// A collection of available event types.
    /// This collection is used to populate the type dropdown list in the form.
    /// </summary>
    public IEnumerable<TypeFormViewModel> AvailableTypes { get; set; } = new List<TypeFormViewModel>();

}
