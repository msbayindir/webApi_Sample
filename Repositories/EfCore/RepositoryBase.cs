using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EfCore
{
	public class RepositoryBase<T>:IRepositoryBase<T>
        where T:class
	{
        private readonly RepositoryContext _context;

        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }


        public void Create(T entity) => _context.Set<T>().Add(entity);


        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public IQueryable<T> FindByConditional(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
            _context.Set<T>().Where(expression).AsNoTracking() :
            _context.Set<T>().Where(expression);


        public IQueryable<T> GetValues(bool trackChanges) =>
            !trackChanges ?
            _context.Set<T>().AsNoTracking() :
            _context.Set<T>();
        

        public void Update(T entity) => _context.Set<T>().Update(entity);

    }
}

