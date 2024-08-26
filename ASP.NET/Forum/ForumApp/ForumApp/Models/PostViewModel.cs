using ForumApp.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace ForumApp.Models;

public class PostViewModel
{
	public int Id { get; set; }

	[Required(ErrorMessage = "Field {0} is required.")]
	[StringLength(ModelsConstraints.PostTittleMaxLength,
		MinimumLength = ModelsConstraints.PostTittleMinLength,
		ErrorMessage = "{0} must be {2} and {1} symbols")]
	public string Title { get; set; } = string.Empty;

	[Required(ErrorMessage = "Field {0} is required.")]
	[StringLength(ModelsConstraints.PostContentMaxLength,
		MinimumLength = ModelsConstraints.PostContentMinLength,
		ErrorMessage = "{0} must be {2} and {1} symbols")]
	public string Content { get; set; } = string.Empty;
}
