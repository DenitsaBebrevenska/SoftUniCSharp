using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MiniORM;

internal class ChangeTracker<T>
    where T : class, new()
{
    private readonly IList<T> allEntities;
    private readonly IList<T> added;
    private readonly IList<T> removed;

    private ChangeTracker()
    {
        added = new List<T>();
        removed = new List<T>();
    }

    public ChangeTracker(IEnumerable<T> allEntries)
        : this()
    {
        allEntries = CloneEntities(allEntries);
    }

    public IReadOnlyCollection<T> AllEntries
        => (IReadOnlyCollection<T>)allEntities;
    public IReadOnlyCollection<T> Added
        => (IReadOnlyCollection<T>)added;
    public IReadOnlyCollection<T> Removed
        => (IReadOnlyCollection<T>)removed;

    public void Add(T entity)
         => added.Add(entity);

    public void Remove(T entity)
        => removed.Add(entity);

    private IList<T> CloneEntities(IEnumerable<T> originalEntries)
    {
        IList<T> clonedEntities = new List<T>();
        PropertyInfo[] propertiesToClone = typeof(T)
            .GetProperties()
            .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
            .ToArray();

        foreach (T originalEntity in originalEntries)
        {
            T clonedEntity = Activator.CreateInstance<T>();

            foreach (var propertyInfo in propertiesToClone)
            {
                object originalValue = propertyInfo.GetValue(originalEntity);
                propertyInfo.SetValue(clonedEntity, originalValue);
            }

            clonedEntities.Add(clonedEntity);
        }

        return clonedEntities;
    }

    public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
    {
        IList<T> modifiedEntities = new List<T>();
        PropertyInfo[] primaryKeys = typeof(T)
            .GetProperties()
            .Where(pi => pi.HasAttribute<KeyAttribute>())
            .ToArray();

        foreach (T proxyEntity in AllEntries)
        {
            object[] primaryKeyValues = GetPrimaryKeyValues(primaryKeys, proxyEntity)
                .ToArray();
            T entity = dbSet.Entities
                .Single(e => GetPrimaryKeyValues(primaryKeys, e)
                    .SequenceEqual(primaryKeyValues));

            bool isModified = IsModified(proxyEntity, entity);

            if (isModified)
            {
                modifiedEntities.Add(proxyEntity);
            }
        }

        return modifiedEntities;
    }

    private bool IsModified(T proxyEntity, T originalEntity)
    {
        PropertyInfo[] monitoredProperties = typeof(T)
            .GetProperties()
            .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
            .ToArray();

        PropertyInfo[] modifiedProperties = monitoredProperties
            .Where(pi => Equals(pi.GetValue(proxyEntity), pi.GetValue(originalEntity)))
            .ToArray();

        return modifiedProperties.Any();
    }

    private IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, T proxyEntity)
    {
        return primaryKeys.Select(pk => pk.GetValue(proxyEntity));
    }
}
