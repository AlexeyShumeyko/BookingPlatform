using Microsoft.EntityFrameworkCore;

namespace BookingPlatform.Core.Contract
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity Create(TEntity entity);

        TEntity Delete(TEntity entity);

        void Update(TEntity entity, IRequest request);

        IQueryable<TEntity> AsQueryable();

        public DbSet<TEntity> Return();
    }
}
