using System.Collections;

namespace MiniORM;

/// <summary>
/// DbSet represents a table in DB. Entity class acts as column description.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class DbSet<TEntity> : ICollection<TEntity>
    where TEntity : class, new()
{
    internal ChangeTracker<TEntity> ChangeTracker { get; set; }
    internal IList<TEntity> Entities { get; set; }

    public int Count => Entities.Count;
    public bool IsReadOnly => Entities.IsReadOnly;

    internal DbSet(IEnumerable<TEntity> entities)
    {
        Entities = entities.ToList();
        ChangeTracker = new ChangeTracker<TEntity>(entities);
    }

    public void Add(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), ExceptionMessages.EntityNullException);
        }

        Entities.Add(entity);
        ChangeTracker.Add(entity);
    }

    public void Clear()
    {
        while (Entities.Any())
        {
            TEntity entityToRemove = Entities.First();
            Remove(entityToRemove);
        }
    }

    public bool Contains(TEntity entity)
        => Entities.Contains(entity);

    //this method comes from the interface, but will not be used
    public void CopyTo(TEntity[] array, int arrayIndex)
        => Entities.CopyTo(array, arrayIndex);

    public bool Remove(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), ExceptionMessages.EntityNullException);
        }

        bool isRemoved = Entities.Remove(entity);

        if (isRemoved)
        {
            ChangeTracker.Remove(entity);
        }

        return isRemoved;
    }

    public void RemoveRange(IEnumerable<TEntity> entitiesToRemove)
    {
        foreach (TEntity entity in entitiesToRemove)
        {
            Remove(entity);
        }
    }

    public IEnumerator<TEntity> GetEnumerator()
        => Entities.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

}
