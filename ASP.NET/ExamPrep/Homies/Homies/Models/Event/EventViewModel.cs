using System.ComponentModel.DataAnnotations;
using static Homies.Common.Constants;
using static Homies.Data.Configuration.DataConstraints;

namespace Homies.Models.Event;

//TODO do i need the validations????
public class EventViewModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(EventNameMaxLength,
        MinimumLength = EventNameMinLength,
        ErrorMessage = StringLengthErrorMessage)]
    public string Name { get; set; } = null!;

    [Required]
    public string Start { get; set; } = null!;

    [Required]
    [StringLength(EventTypeNameMaxLength,
        MinimumLength = EventTypeNameMinLength,
        ErrorMessage = StringLengthErrorMessage)]
    public string Type { get; set; } = null!;

    [Required]
    public string Organiser { get; set; } = null!;
}
