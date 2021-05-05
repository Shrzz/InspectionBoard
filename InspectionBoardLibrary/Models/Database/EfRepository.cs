using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Models.Database
{
    public abstract class EfRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected readonly TContext context;

        public ISearcher<TEntity> Searcher { get; set; }

        public EfRepository(TContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Remove(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<ObservableCollection<TEntity>> Select()
        {
            var list = await context.Set<TEntity>().ToListAsync();
            return new ObservableCollection<TEntity>(list);
        }

        public async Task<ObservableCollection<int>> SelectIds()
        {
            var collection = await context.Set<TEntity>().OrderBy(e => e.Id).Select(e => e.Id).ToListAsync();
            return new ObservableCollection<int>(collection);
        }

        public async Task<TEntity> SelectSingle(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> SelectFirst()
        {
            return await context.Set<TEntity>().FirstOrDefaultAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
