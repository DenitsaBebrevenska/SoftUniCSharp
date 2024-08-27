using ForumApp.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ForumApp.Infrastructure.Data.Models;

[Comment("Post table")]
public class Post
{
	[Comment("Post identifier")]
	public int Id { get; set; }

	[Required]
	[MaxLength(ValidationConstraints.PostTittleMaxLength)]
	[Comment("Post title")]
	public string Title { get; set; } = null!;

	[Required]
	[MaxLength(ValidationConstraints.PostContentMaxLength)]
	[Comment("Post content")]
	public string Content { get; set; } = null!;
}
