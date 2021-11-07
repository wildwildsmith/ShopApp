﻿using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopApp.Data.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include, bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        IQueryable<T> FindByCondition(Func<IQueryable<T>, IIncludableQueryable<T, object>> include, Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
