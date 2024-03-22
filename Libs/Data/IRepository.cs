using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Libs.Repositories
{
    public interface IRepository <T> where T:class
    {
        T Add (T entity);    
        T Update (T entity);    
        T Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);

        int Count(Expression<Func<T, bool>> where);
        IEnumerable<T> GetList(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            int skip = 0,
            int take = 0);
        T GetById(object Id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        //IQueryable<T> FindAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        bool Any(Expression<Func<T, bool>> where);  
    }
}   