using Microsoft.EntityFrameworkCore;
using OnlineLibrary.DAL.Entites;
using OnlineLibrary.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineLibrary.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected OnlineLibraryContext Context { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public BaseRepository(OnlineLibraryContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return DbSet.Where(filter);
            }

            return DbSet;
        }

        public T GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public async Task InsertAndSaveAsync(T entity)
        {
            Insert(entity);

            await SaveChangesAsync();
        }

        public void Remove(Guid id)
        {
            var entity = GetById(id);

            if (entity == null)
                throw new ArgumentException();

            DbSet.Remove(entity);
        }

        public async Task RemoveAndSaveAsync(Guid id)
        {
            Remove(id);

            await SaveChangesAsync();
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentException();

            var itemFromDB = GetById(entity.Id);

            Context.Entry(itemFromDB).State = EntityState.Detached;
            Context.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateAndSaveAsync(T entity)
        {
            Update(entity);

            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
