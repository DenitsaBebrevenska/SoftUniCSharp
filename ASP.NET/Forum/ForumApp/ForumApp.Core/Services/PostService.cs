using ForumApp.Core.Contracts;
using ForumApp.Core.Models;
using ForumApp.Infrastructure.Data;
using ForumApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Core.Services;
public class PostService : IPostService
{
	private readonly ForumAppDbContext _context;

	public PostService(ForumAppDbContext context)
	{
		_context = context;
	}

	public async Task<PostModel> GetByIdAsync(int id)
	{
		var post = await _context.Posts
					.FindAsync(id);

		if (post == null)
		{
			throw new ArgumentException("Invalid id");
		}

		return new PostModel()
		{
			Id = post.Id,
			Title = post.Title,
			Content = post.Content
		};
	}

	public async Task<IEnumerable<PostModel>> GetAllAsync()
	{
		var products = await _context.Posts
			.AsNoTracking()
			.Select(p => new PostModel()
			{
				Id = p.Id,
				Title = p.Title,
				Content = p.Content
			})
			.ToArrayAsync();

		return products;
	}

	public async Task AddAsync(PostModel model)
	{
		if (model is null)
		{
			throw new ArgumentNullException(nameof(model), "Post cannot be null.");
		}

		var post = new Post()
		{
			Title = model.Title,
			Content = model.Content
		};

		await _context.AddAsync(post);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(PostModel model)
	{
		if (model is null)
		{
			throw new ArgumentNullException(nameof(model), "Post cannot be null.");
		}

		var post = await _context.Posts
			.FindAsync(model.Id);

		if (post == null)
		{
			throw new ArgumentException("Invalid product");
		}

		post.Title = model.Title;
		post.Content = model.Content;

		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var post = await _context
			.Posts
			.FindAsync(id);

		if (post == null)
		{
			throw new ArgumentException("Invalid id");
		}

		_context.Posts.Remove(post);
		await _context.SaveChangesAsync();
	}
}
