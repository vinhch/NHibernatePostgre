using System.Collections.Generic;
using NHibernatePostgre.Domains;

namespace NHibernatePostgre.Services
{
    public interface IProductService : IService
    {
        IEnumerable<Product> GetAll();
        Product GetEntryById(long id);
        long AddEntry(Product entry);
        void EditEntry(Product entry);
        void MergeEntry(Product entry);
        void RemoveEntry(Product entry);
        void RemoveEntryById(long id);
    }
}