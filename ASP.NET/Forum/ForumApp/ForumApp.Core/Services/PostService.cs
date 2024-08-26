﻿using ForumApp.Core.Contracts;
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
	public async Task<Post> GetById(int id)
	{
		if (id < 1 || id > _context.Posts.Last().Id)
		{
			throw new ArgumentException("Invalid id");
		}

		return await _context.Posts
			.FindAsync(id);
	}

	public async Task<IEnumerable<Post>> GetAll()
	{
		return await _context.Posts
			.AsNoTracking()
			.ToArrayAsync();
	}

	public async Task Add(Post model)
	{
		if (model is null)
		{
			throw new ArgumentNullException(nameof(model), "Post cannot be null.");
		}
		await _context.AddAsync(model);
		await _context.SaveChangesAsync();
	}

	public async Task Update(Post model)
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

	public async Task Delete(int id)
	{
		var post = await _context
			.Posts
			.FindAsync(id);

		if (post == null)
		{
			throw new ArgumentException("Invalid id");
		}

		_context.Posts.Remove(post);
	}
}
