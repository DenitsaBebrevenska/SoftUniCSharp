namespace HouseRentingSystem.Infrastructure.Common;
public interface IRepository
{
    IQueryable<T> GetAll<T>() where T : class;

    IQueryable<T> GetAllReadOnly<T>() where T : class;

    int SaveChanges();
}
