using ForumApp.Infrastructure.Data.Models;

namespace ForumApp.Core.Contracts;
public interface IPostService
{
	Task<Post> GetByIdAsync(int id);

	Task<IEnumerable<Post>> GetAllAsync();

	Task AddAsync(Post model);

	Task UpdateAsync(Post model);

	Task DeleteAsync(int id);
}
