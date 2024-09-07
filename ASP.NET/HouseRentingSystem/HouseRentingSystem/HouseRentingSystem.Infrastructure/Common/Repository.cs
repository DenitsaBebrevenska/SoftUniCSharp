using HouseRentingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Infrastructure.Common;
public class Repository : IRepository
{
    private readonly HomeRentingDbContext _context;

    public Repository(HomeRentingDbContext context)
    {
        _context = context;
    }

    private DbSet<T> GetDbSet<T>() where T : class
        => _context.Set<T>();

    public IQueryable<T> GetAll<T>() where T : class
        => GetDbSet<T>();

    public IQueryable<T> GetAllReadOnly<T>() where T : class
        => GetDbSet<T>()
            .AsNoTracking();

    public async Task AddAsync<T>(T entity) where T : class
        => await GetDbSet<T>()
            .AddAsync(entity);

    public async Task<int> SaveChangesAsync()
     => await _context.SaveChangesAsync();
}
