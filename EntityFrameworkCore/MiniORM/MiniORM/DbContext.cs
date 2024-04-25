using Microsoft.Data.SqlClient;
using System.Collections;
using System.Reflection;

namespace MiniORM;

/// <summary>
///  The user should derive from DbContext to add Dbsets from entries. Discovering runtime dbsets from the user.
/// </summary>
public abstract class DbContext
{
    private readonly DatabaseConnection connection;
    private readonly IDictionary<Type, PropertyInfo> dbSetProperties;

    internal DbContext(string connectionString)
    {
        connection = new DatabaseConnection(connectionString);
        dbSetProperties = DiscoverDbSets();
        using (new ConnectionManager(connection))
        {
            InitializeDbSets();
        }

        MapAllRelations();
    }

    public void SaveChanges()
    {
        object[] dbSets = dbSetProperties
            .Select(dbSetInfo => dbSetInfo.Value.GetValue(this))
            .ToArray();

        foreach (IEnumerable<object> dbSet in dbSets)
        {
            IEnumerable<object> invalidEntities = dbSet
                .Where(e => !IsObjectValid(e))
                .ToArray();

            if (invalidEntities.Any())
            {
                throw new InvalidOperationException(string.Format
                    (ExceptionMessages.InvalidEntitiesException,
                        invalidEntities.Count(), dbSet.GetType().Name));
            }
        }

        using (new ConnectionManager(connection))
        {
            using SqlTransaction transaction = connection.StartTransaction();

            foreach (IEnumerable dbSet in dbSets)
            {
                Type dbSetType = dbSet.GetType().GetGenericArguments().First();
                MethodInfo persistMethod = typeof(DbContext)
                    .GetMethod("Persist", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(dbSetType);

                try
                {
                    persistMethod.Invoke(this, new object[] { dbSet });
                }
                catch (TargetInvocationException tie)
                {
                    throw tie.InnerException;
                }
                catch (InvalidOperationException)
                {
                    transaction.Rollback();
                    throw;
                }
                catch (SqlException)
                {
                    transaction.Rollback();
                    throw;
                }

                transaction.Commit();
            }
        }
    }

    private void Persist<TEntity>(DbSet<TEntity> dbSet)
        where TEntity : class, new()
    {
        string tableName = GetTableName(typeof(TEntity));
        string[] columns = connection
            .FetchColumnNames(tableName)
            .ToArray();

        if (dbSet.ChangeTracker.Added.Any())
        {
            connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);
        }

        IEnumerable<TEntity> modifiedEntities = dbSet.ChangeTracker
            .GetModifiedEntities(dbSet)
            .ToArray();

        if (modifiedEntities.Any())
        {
            connection.UpdateEntities(modifiedEntities, tableName, columns);
        }

        if (dbSet.ChangeTracker.Removed.Any())
        {
            connection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns);
        }
    }

    private string GetTableName(Type type)
    {
        throw new NotImplementedException();
    }

    private bool IsObjectValid(object o)
    {
        throw new NotImplementedException();
    }

    private void MapAllRelations()
    {
        throw new NotImplementedException();
    }

    private void InitializeDbSets()
    {


    }

    internal static readonly Type[] AllowedSqlTypes =
    {
        typeof(string),
        typeof(int),
        typeof(uint),
        typeof(long),
        typeof(ulong),
        typeof(decimal),
        typeof(bool),
        typeof(DateTime)
    };

    private IDictionary<Type, PropertyInfo> DiscoverDbSets()
    {

    }
}
