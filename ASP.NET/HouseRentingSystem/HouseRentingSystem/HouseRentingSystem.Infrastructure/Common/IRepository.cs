namespace HouseRentingSystem.Infrastructure.Common;
public interface IRepository
{
    IQueryable<T> GetAll<T>() where T : class;

    IQueryable<T> GetAllReadOnly<T>() where T : class;

    Task AddAsync<T>(T entity) where T : class;
    Task<int> SaveChangesAsync();
}
