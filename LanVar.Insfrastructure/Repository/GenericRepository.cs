using System;
using System.Linq.Expressions;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LanVar.Insfrastructure.Repository
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
        protected MyDbContext _context;
        protected DbSet<TEntity> dbSet;
        
        public GenericRepository(
            MyDbContext context
            
            
            )
		{
            _context = context;
            
            dbSet = _context.Set<TEntity>();

		}

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges(); // Save changes synchronously
        }


        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public async Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filterExpression)
        {
            var query = _context.Set<TEntity>().Where(filterExpression);
            var queryableType = query.GetType().GetProperty("ElementType");
            // use queryableType here
            return await query.ToListAsync();
        }
    }
}

