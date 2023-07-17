using DevTestBackend.Contract.Repository;
using DevTestBackend.Entities.Data;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DevTestBackend.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal readonly DevTestBackendContext context;
        private readonly DbSet<T> Entity;
        
        public GenericRepository(DevTestBackendContext context) 
        {
            this.context = context;
            Entity = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Entity.ToListAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await Entity.FindAsync(id).ConfigureAwait(false);

            Entity.Remove(entity);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<T> GetAsync(object id)
        {
            return await Entity.FindAsync(id).ConfigureAwait(false);
        }

        public async Task InsertAsync(T entity)
        { 
            await Entity.AddAsync(entity).ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task InsertInRangeAsync(IEnumerable<T> entity) 
        {
            await Entity.AddRangeAsync(entity).ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(T entity)
        {
            Entity.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            await context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
