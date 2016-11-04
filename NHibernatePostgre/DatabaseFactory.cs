using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernatePostgre.Helper;

namespace NHibernatePostgre
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private readonly Configuration _configuration;

        // Test Singleton: Database Instance?
        //private static IDatabase _databaseInstance;
        private IDatabase _databaseInstance;

        public IDatabase CreateNewDatabase()
        {
            using (var sessionFactory = GetSessionFactory())
            {
                var session = sessionFactory.OpenSession();
                //var session = sessionFactory.OpenStatelessSession();

                session.FlushMode = FlushMode.Commit; //allow queries to return stale state
                _databaseInstance = new Database(session);
            }
            return _databaseInstance;
        }

        public IDatabase GetDatabase()
        {
            if (_databaseInstance == null)
            {
                CreateNewDatabase();
            }
            return _databaseInstance;
        }

        private ISessionFactory _sessionFactory;
        public ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory != null) return _sessionFactory;

            _configuration.SetNamingStrategy(new PostgresNamingStrategy(DefaultNamingStrategy.Instance));
            _configuration.AddMapping(Database.CreateMappings());
            SchemaMetadataUpdater.QuoteTableAndColumns(_configuration);
            _sessionFactory = _configuration.BuildSessionFactory();

            return _sessionFactory;
        }

        public DatabaseFactory()
        {
            _configuration = new Configuration().Configure();
        }

        public DatabaseFactory(Configuration configuration)
        {
            _configuration = configuration;
        }
    }
}