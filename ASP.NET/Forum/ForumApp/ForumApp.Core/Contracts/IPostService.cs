using ForumApp.Core.Models;

namespace ForumApp.Core.Contracts;
public interface IPostService
{
	Task<PostModel> GetByIdAsync(int id);

	Task<IEnumerable<PostModel>> GetAllAsync();

	Task AddAsync(PostModel model);

	Task UpdateAsync(PostModel model);

	Task DeleteAsync(int id);
}
