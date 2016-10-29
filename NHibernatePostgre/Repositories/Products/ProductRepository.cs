using NHibernatePostgre.Domains;

namespace NHibernatePostgre.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IDatabase database) : base(database)
        {
        }

        public ProductRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}