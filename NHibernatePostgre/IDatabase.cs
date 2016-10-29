using System;
using System.Data;
using NHibernate;

namespace NHibernatePostgre
{
    public interface IDatabase : IDisposable
    {
        IDbConnection Connection { get; }
        ISession Session { get; }
        void BeginTransaction();
        void Commit();
    }
}