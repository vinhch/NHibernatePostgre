using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernatePostgre.Domains
{
    public class BaseEntity : IBaseEntity
    {
        public virtual long Id { get; set; }
    }
}
