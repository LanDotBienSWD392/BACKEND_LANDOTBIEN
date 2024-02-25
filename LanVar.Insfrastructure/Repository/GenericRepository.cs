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

        public async Task<TEntity> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync(); // Save changes asynchronously
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }


        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        

        public async Task<IEnumerable<TEntity>> GetAllAsync() 
        {
            return await _context.Set<TEntity>().ToListAsync();
        }


        public virtual async Task<TEntity> GetById(long id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<bool> Delete(long id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity == null)
            {
                return false; // Entity not found, return false
            }

            dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true; // Entity successfully deleted
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

