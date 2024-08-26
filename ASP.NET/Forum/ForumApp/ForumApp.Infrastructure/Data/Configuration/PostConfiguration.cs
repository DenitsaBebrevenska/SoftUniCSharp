using ForumApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForumApp.Infrastructure.Data.Configuration;
public class PostConfiguration : IEntityTypeConfiguration<Post>
{
	private readonly Post[] _posts =
	{
		new Post() { Id = 1, Tittle = "First", Content = "My first post!" },
		new Post() { Id = 2, Tittle = "Second", Content = "My second post!" },
		new Post() { Id = 3, Tittle = "Third", Content = "My third post!" }
	};
	public void Configure(EntityTypeBuilder<Post> builder)
	{
		builder.HasData(_posts);
	}
}
