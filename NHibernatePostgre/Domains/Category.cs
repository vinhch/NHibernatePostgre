using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernatePostgre.Domains
{
    public class Category : BaseEntity
    {
        public virtual string CategoryTitle { get; set; }
        public virtual ISet<Product> Products { get; set; }
    }
}
