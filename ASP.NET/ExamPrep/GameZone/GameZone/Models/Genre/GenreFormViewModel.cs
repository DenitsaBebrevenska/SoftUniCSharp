namespace GameZone.Models.Genre;

/// <summary>
/// View model representing genre.
/// This model is used to populate dropdowns or selection lists in event-related forms.
/// It does not include validation attributes as it does not deal with user input.
/// </summary>
public class GenreFormViewModel
{
	/// <summary>
	/// The genre`s unique identifier
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	/// The genre`s name
	/// </summary>
	public string Name { get; set; } = null!;
}
