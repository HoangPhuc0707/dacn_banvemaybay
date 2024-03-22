using Libs.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    public abstract class RepositoryBase<T> where T: class
    {
        protected ModelFlightContext _dbContext;
        protected readonly DbSet<T> dbSet;
        protected RepositoryBase(ModelFlightContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<T>();
        }
        public virtual T Add(T entity)
        {
            return dbSet.Add(entity).Entity;
        }
        public virtual async Task<bool> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }
        public virtual T Update(T entity)
        {
            dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual T Delete(T entity)
        {
            return dbSet.Remove(entity).Entity;
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual int Count(Expression<Func<T, bool>> where)
        {
            return dbSet.Count<T>(where);
        }

        public virtual IEnumerable<T> GetList(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            int skip = 0,
            int take = 0)
        {
            IQueryable<T> query = dbSet;

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
                query = orderBy(query);
            }

            if (skip > 0)
            {
                query = query.Skip(skip);
            }

            if (take > 0)
            {
                query = query.Take(take);
            }

            return query.ToList();
        }

        public virtual T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }

        public virtual bool Any(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).Any<T>();
        }
        //public IQueryable<T> FindAll()
        //{
        //    return this._dbContext.Set<T>().AsNoTracking();
        //}
    }
}
