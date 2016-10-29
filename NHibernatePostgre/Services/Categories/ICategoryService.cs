using System.Collections.Generic;
using NHibernatePostgre.Domains;

namespace NHibernatePostgre.Services
{
    public interface ICategoryService : IService
    {
        IEnumerable<Category> GetAll();
        Category GetEntryById(long id);
        long AddEntry(Category entry);
        void EditEntry(Category entry);
        void MergeEntry(Category entry);
        void RemoveEntry(Category entry);
        void RemoveEntryById(long id);
    }
}