using System.Collections.Generic;
using System.Linq;

namespace NHibernatePostgre.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IDatabase Database { get; }

        #region NHibernate
        IQueryable<TEntity> AsQueryable { get; }
        void Add(TEntity obj);
        void Edit(TEntity obj);
        void Remove(TEntity obj);
        void Merge(TEntity obj);
        #endregion
    }
}