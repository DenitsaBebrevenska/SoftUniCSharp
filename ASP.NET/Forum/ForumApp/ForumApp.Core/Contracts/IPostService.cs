using ForumApp.Infrastructure.Models;

namespace ForumApp.Core.Contracts;
public interface IPostService
{
	Task<Post> GetById(int id);

	Task<IEnumerable<Post>> GetAll();

	Task Add(Post model);

	Task Update(Post model);

	Task Delete(int id);
}
