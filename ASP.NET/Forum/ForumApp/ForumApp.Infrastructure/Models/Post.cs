using ForumApp.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace ForumApp.Infrastructure.Models;
public class Post
{
	public int Id { get; set; }

	[Required]
	[MaxLength(ModelsConstraints.PostTittleMaxLength)]
	public string Tittle { get; set; } = null!;

	[Required]
	[MaxLength(ModelsConstraints.PostContentMaxLength)]
	public string Content { get; set; } = null!;
}
