using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ShopApp.Data;
using ShopApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopApp.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ShopDbContext context;

        public RepositoryBase(ShopDbContext context)
        {
            this.context = context;
        }

        public void Create(T entity) => context.Set<T>().Add(entity);

        public void Delete(T entity) => context.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? context.Set<T>().AsNoTracking() : context.Set<T>();

        public IQueryable<T> FindAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include, bool trackChanges)
        {
            IQueryable<T> query = context.Set<T>();

            if (!trackChanges)
                query.AsNoTracking();

            if (include != null)
                query = include(query);

            return query;
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? context.Set<T>().Where(expression).AsNoTracking() : context.Set<T>().Where(expression);

        public IQueryable<T> FindByCondition(Func<IQueryable<T>, IIncludableQueryable<T, object>> include, Expression<Func<T, bool>> expression, bool trackChanges)
        {
            IQueryable<T> query = context.Set<T>();

            if (!trackChanges)
                query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (expression != null)
                query = query.Where(expression);

            return query;
        }

        public void Update(T entity) => context.Set<T>().Update(entity);
    }
}
