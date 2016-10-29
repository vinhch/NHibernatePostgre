using System.Linq;
using NHibernate.Linq;

namespace NHibernatePostgre.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IDatabase _database;
        public IDatabase Database
        {
            get { return _database; }
        }

        protected BaseRepository(IDatabase database)
        {
            _database = database;
        }

        protected BaseRepository(IDatabaseFactory databaseFactory)
            : this(databaseFactory.GetDatabase())
        {
        }

        #region NHibernate
        public IQueryable<TEntity> AsQueryable
        {
            get { return _database.Session.Query<TEntity>(); }
        }

        public virtual void Add(TEntity obj)
        {
            _database.BeginTransaction();
            _database.Session.Save(obj);
        }

        public virtual void Edit(TEntity obj)
        {
            _database.BeginTransaction();
            _database.Session.Update(obj);
        }

        public virtual void Remove(TEntity obj)
        {
            _database.BeginTransaction();
            _database.Session.Delete(obj);
        }

        public virtual void Merge(TEntity obj)
        {
            _database.BeginTransaction();
            _database.Session.Merge(obj);
        }

        public virtual void Commit()
        {
            _database.Session.Flush();
            _database.Commit();
        }
        #endregion
    }
}