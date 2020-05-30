using Microsoft.EntityFrameworkCore;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppContext _context;
        protected DbSet<T> entities;
        string errorMessage = string.Empty;

        public BaseRepository(AppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            entities = context.Set<T>();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }
        public async Task<IList<T>> GetAllAsync(Expression<Func<Step, bool>> predicate)
        {
            return await entities.ToListAsync();
        }
        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<IList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await entities.Where(predicate).ToListAsync();
        }

        public async Task<IList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<IList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<T> query = _context.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<Guid> AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(IList<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }
            foreach (T entity in entities)
            {
                entities.Remove(entity);
            }
            await _context.SaveChangesAsync();
        }
    }
}
