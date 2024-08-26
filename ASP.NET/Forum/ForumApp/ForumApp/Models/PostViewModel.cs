using ForumApp.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace ForumApp.Models;

public class PostViewModel
{
	public int Id { get; set; }

	[Required]
	[StringLength(ModelsConstraints.PostTittleMaxLength,
		MinimumLength = ModelsConstraints.PostTittleMaxLength,
		ErrorMessage = "{0} must be {2} and {1} symbols")]
	public string Title { get; set; } = string.Empty;

	[Required]
	[StringLength(ModelsConstraints.PostContentMaxLength,
		MinimumLength = ModelsConstraints.PostContentMaxLength,
		ErrorMessage = "{0} must be {2} and {1} symbols")]
	public string Content { get; set; } = string.Empty;
}
