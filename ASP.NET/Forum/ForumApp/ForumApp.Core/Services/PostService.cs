using ForumApp.Core.Contracts;
using ForumApp.Infrastructure.Data;
using ForumApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Core.Services;
public class PostService : IPostService
{
	private readonly ForumAppDbContext _context;

	public PostService(ForumAppDbContext context)
	{
		_context = context;
	}
	public async Task<Post> GetByIdAsync(int id)
	{
		var lastAvailableId = _context.Posts
			.AsNoTracking()
			.OrderBy(p => p.Id)
			.Last()
			.Id;

		if (id < 1 || id > lastAvailableId)
		{
			throw new ArgumentException("Invalid id");
		}

		return await _context.Posts
			.FindAsync(id);
	}

	public async Task<IEnumerable<Post>> GetAllAsync()
	{
		return await _context.Posts
			.AsNoTracking()
			.ToArrayAsync();
	}

	public async Task AddAsync(Post model)
	{
		if (model is null)
		{
			throw new ArgumentNullException(nameof(model), "Post cannot be null.");
		}
		await _context.AddAsync(model);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Post model)
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

		post.Tittle = model.Tittle;
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
