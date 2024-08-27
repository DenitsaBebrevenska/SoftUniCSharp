using ForumApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForumApp.Infrastructure.Data.Configuration;
public class PostConfiguration : IEntityTypeConfiguration<Post>
{
	private readonly Post[] _posts =
	{
		new () { Id = 1, Title = "First", Content = "My first post!" },
		new () { Id = 2, Title = "Second", Content = "My second post!" },
		new () { Id = 3, Title = "Third", Content = "My third post!" }
	};
	public void Configure(EntityTypeBuilder<Post> builder)
	{
		builder.HasData(_posts);
	}
}
