using System;
using System.Linq.Expressions;

namespace Repositories.Contracts
{
	public interface IRepositoryBase<T>
	{
		IQueryable<T> GetValues(bool trackChanges);
		IQueryable<T> FindByConditional(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}

