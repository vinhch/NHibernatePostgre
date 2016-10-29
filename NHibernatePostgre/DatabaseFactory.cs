using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernatePostgre.Helper;

namespace NHibernatePostgre
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private Configuration _configuration;

        // Singleton: Database Instance
        private static IDatabase _databaseInstance;
        public IDatabase GetDatabase()
        {
            if (_databaseInstance == null)
            {
                using (var sessionFactory = GetSessionFactory())
                {
                    var session = sessionFactory.OpenSession();
                    session.FlushMode = FlushMode.Commit; //allow queries to return stale state
                    _databaseInstance = new Database(session);
                }
            }
            return _databaseInstance;
        }

        private ISessionFactory _sessionFactory;
        public ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
            {
                _configuration.SetNamingStrategy(new PostgresNamingStrategy(DefaultNamingStrategy.Instance));

                _configuration.AddMapping(Database.CreateMappings());
                SchemaMetadataUpdater.QuoteTableAndColumns(_configuration);
                _sessionFactory = _configuration.BuildSessionFactory();
            }

            return _sessionFactory;
        }

        public DatabaseFactory()
        {
            _configuration = new Configuration().Configure();
        }

        public DatabaseFactory(Configuration nHconfiguration)
        {
            _configuration = nHconfiguration;
        }
    }
}