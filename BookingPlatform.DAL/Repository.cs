using BookingPlatform.Core.Contract;
using Microsoft.EntityFrameworkCore;

namespace BookingPlatform.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public TEntity Create(TEntity entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public void Update(TEntity entity, IRequest request)
        {
            _dbSet.Entry(entity).CurrentValues.SetValues(request);
        }

        public TEntity Delete(TEntity entity)
        {
            return _dbSet.Remove(entity).Entity;
        }

        public DbSet<TEntity> Return()
        {
            return _dbSet;
        }
    }
}
