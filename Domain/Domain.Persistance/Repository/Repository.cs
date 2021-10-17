using Domain.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.EF;

namespace Domain.Persistance
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal DBContext context;
        internal DbSet<T> dbSet;

        public Repository(DBContext dbcontext)
        {
            context = dbcontext;
            dbSet = context.Set<T>();
        }

        public virtual int GetCount()
        {
            return dbSet.Count();
        }

        public virtual IEnumerable<T> Get()
        {
            return dbSet.ToList<T>();
        }

        public virtual async Task<T> Get(int id)
        {
            var entity = await dbSet.FindAsync(id);
            return entity;
        }

        public virtual async Task Insert(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public virtual async Task Delete(int id)
        {
            T entityToDelete = await dbSet.FindAsync(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

    }

}
