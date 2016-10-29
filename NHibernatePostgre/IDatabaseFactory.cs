using NHibernate;

namespace NHibernatePostgre
{
    public interface IDatabaseFactory
    {
        IDatabase GetDatabase();
        ISessionFactory GetSessionFactory();
    }
}