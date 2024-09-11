﻿namespace HouseRentingSystem.Infrastructure.Common;
public interface IRepository
{
	IQueryable<T> GetAll<T>() where T : class;

	IQueryable<T> GetAllReadOnly<T>() where T : class;

	Task AddAsync<T>(T entity) where T : class;
	Task<int> SaveChangesAsync();

	Task<T?> GetByIdAsync<T>(int id) where T : class;

	Task RemoveAsync<T>(T entity) where T : class;
}
