using ConsultaMedica.Data.Contexts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ConsultaMedica.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IDisposable where TEntity : Models.BaseModel
    {
        internal ConsultaMedicaContext context;
        internal DbSet<TEntity> dbSet;
        private bool isDisposed = false;

        static BaseRepository()
        {
            Util.EnsureStaticReference<System.Data.Entity.SqlServer.SqlProviderServices>();
        }

        protected BaseRepository(ConsultaMedicaContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> List(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public virtual TEntity GetByID(int id)
        {
            return dbSet.AsNoTracking().FirstOrDefault(e => e.ID == id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            context.Entry(entityToUpdate).State = EntityState.Detached;
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;

            if (disposing)
            {
                context.Dispose();
            }

            isDisposed = true;
        }
    }
}
