using System;
using System.Linq.Expressions;
using MeetingOrganizer.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace MeetingOrganizer.Domain.Repositories
{
	public interface IBaseRepository<T> where T : IBaseEntity
	{
		Task Create(T entity);
		Task Update(T entity);
		Task SoftDelete(T entity);
        Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<T> GetDefault(Expression<Func<T, bool>> expression);

    }
}

