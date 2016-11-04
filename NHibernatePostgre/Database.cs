using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using Npgsql;

namespace NHibernatePostgre
{
    public class Database : IDatabase
    {
        private readonly IDbConnection _dbConnection;
        public IDbConnection Connection => _dbConnection;

        private ISession _session;
        public ISession Session => _session;

        private ITransaction _transaction;
        public void BeginTransaction()
        {
            if (_transaction == null)
            {
                _transaction = _session.BeginTransaction();
            }
        }

        public void Commit()
        {
            try
            {
                // commit transaction if there is one active
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch
            {
                // rollback if there was an exception
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();

                Session.Clear();
                //Session.Flush();
                throw;
            }
            finally
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
        }

        public void Dispose()
        {
            if (_dbConnection != null && _dbConnection.State != ConnectionState.Closed)
            {
                _dbConnection.Close();
            }

            if (_session != null)
            {
                _session.Dispose();
            }

            if (_transaction != null)
            {
                _transaction.Dispose();
            }
        }

        public Database(ISession session)
        {
            _session = session;

            // can change this base on RDBMS, for now it using Postgre
            _dbConnection = new NpgsqlConnection(session.Connection.ConnectionString);
        }

        public static HbmMapping CreateMappings()
        {
            var mapper = new ModelMapper();

            // Mapping using list type
            //var types = Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(t => t.IsClass && t.Namespace == "NHibernatePostgre.Maps");
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.IsClass && t.Namespace == "NHibernatePostgre.Maps");
            mapper.AddMappings(types);

            // Mapping per map class
            //mapper.AddMapping(typeof(ProductMap));

            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }
    }
}
