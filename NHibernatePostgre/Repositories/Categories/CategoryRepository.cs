using NHibernatePostgre.Domains;

namespace NHibernatePostgre.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDatabase database) : base(database)
        {
        }

        public CategoryRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}