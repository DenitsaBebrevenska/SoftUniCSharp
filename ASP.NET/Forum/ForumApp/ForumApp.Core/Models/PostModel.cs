using ForumApp.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace ForumApp.Models;

public class PostModel
{
	public int Id { get; set; }

	[Required(ErrorMessage = "Field {0} is required.")]
	[StringLength(ValidationConstraints.PostTittleMaxLength,
		MinimumLength = ValidationConstraints.PostTittleMinLength,
		ErrorMessage = "{0} must be {2} and {1} symbols")]
	public string Title { get; set; } = string.Empty;

	[Required(ErrorMessage = "Field {0} is required.")]
	[StringLength(ValidationConstraints.PostContentMaxLength,
		MinimumLength = ValidationConstraints.PostContentMinLength,
		ErrorMessage = "{0} must be {2} and {1} symbols")]
	public string Content { get; set; } = string.Empty;
}
