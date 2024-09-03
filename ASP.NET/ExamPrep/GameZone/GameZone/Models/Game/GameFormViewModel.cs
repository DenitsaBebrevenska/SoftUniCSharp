using GameZone.Attributes;
using GameZone.Models.Genre;
using System.ComponentModel.DataAnnotations;
using static GameZone.Common.Constants.GlobalConstants;
using static GameZone.Common.Constants.ModelConstants;

namespace GameZone.Models.Game;

/// <summary>
/// A view model for creation or editing a game.
/// This model includes validation rules for user input and is used in both the /Edit and /Add forms.
/// </summary>
public class GameFormViewModel
{
	/// <summary>
	/// The game`s unique identifier
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	/// The game`s title
	/// </summary>
	[Required(ErrorMessage = RequiredValidationErrorMessage)]
	[StringLength(
		GameTitleMaxLength,
		MinimumLength = GameTitleMinLength,
		ErrorMessage = StringLengthValidationErrorMessage)]
	public string Title { get; set; } = null!;

	/// <summary>
	/// The game`s image URL which can be null
	/// </summary>
	public string? ImageUrl { get; set; }

	/// <summary>
	/// The game`s description
	/// </summary>
	[Required(ErrorMessage = RequiredValidationErrorMessage)]
	[StringLength(
		GameDescriptionMaxLength,
		MinimumLength = GameDescriptionMinLength,
		ErrorMessage = StringLengthValidationErrorMessage)]
	public string Description { get; set; } = null!;

	/// <summary>
	/// The game`s date of release
	/// </summary>
	[Required]
	[IsCorrectDateFormat(DefaultDateTimeFormat)]
	public string ReleasedOn { get; set; } = null!;

	/// <summary>
	/// The identifier of the game`s genre
	/// </summary>
	public int GenreId { get; set; }

	/// <summary>
	/// A collection of available genres.
	/// This collection is used in the dropdown list in the form.
	/// </summary>
	public ICollection<GenreFormViewModel> Genres { get; set; } = new HashSet<GenreFormViewModel>();
}

