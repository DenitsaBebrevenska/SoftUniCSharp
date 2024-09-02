using GameZone.Attributes;
using GameZone.Models.Genre;
using System.ComponentModel.DataAnnotations;
using static GameZone.Common.Constants.GlobalConstants;
using static GameZone.Common.Constants.ModelConstants;

namespace GameZone.Models.Game;

public class GameFormViewModel
{
	public int Id { get; set; }

	[Required(ErrorMessage = RequiredValidationErrorMessage)]
	[StringLength(
		GameTitleMaxLength,
		MinimumLength = GameTitleMinLength,
		ErrorMessage = StringLengthValidationErrorMessage)]
	public string Title { get; set; } = null!;

	public string? ImageUrl { get; set; }

	[Required(ErrorMessage = RequiredValidationErrorMessage)]
	[StringLength(
		GameDescriptionMaxLength,
		MinimumLength = GameDescriptionMinLength,
		ErrorMessage = StringLengthValidationErrorMessage)]
	public string Description { get; set; } = null!;

	[Required]
	[IsCorrectDateFormat(DefaultDateTimeFormat)]
	public string ReleasedOn { get; set; } = null!;

	public int GenreId { get; set; }

	public ICollection<GenreFormViewModel> Genres { get; set; } = new HashSet<GenreFormViewModel>();
}

