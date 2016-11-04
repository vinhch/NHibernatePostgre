using NHibernate;

namespace NHibernatePostgre
{
    public interface IDatabaseFactory
    {
        IDatabase GetDatabase();
        IDatabase CreateNewDatabase();
        ISessionFactory GetSessionFactory();
    }
}