using System.ComponentModel.DataAnnotations;

namespace TextSplitterApp.Models;

public class TextViewModel
{
	[Required]
	[StringLength(30, MinimumLength = 2)]
	public string Text { get; set; } = string.Empty;

	public string WordsOfText { get; set; } = string.Empty;
}
