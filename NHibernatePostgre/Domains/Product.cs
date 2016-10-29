using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernatePostgre.Domains
{
    public class Product : BaseEntity
    {
        public virtual string ProductTitle { get; set; }
        public virtual ISet<Category> Categories { get; set; }
    }
}
