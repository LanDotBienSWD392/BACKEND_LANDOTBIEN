﻿using System;
using System.Linq.Expressions;

namespace LanVar.Core.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        
        public Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetById(long id);
        Task<TEntity> GetByIdAsync(long id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        Task<bool> Delete(long id);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filterExpression);
    }
}

