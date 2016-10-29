using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NHibernatePostgre.Repositories;
using NHibernatePostgre.Services;

namespace NHibernatePostgre.ConsoleTests
{
    public class AppStartup
    {
        public static IContainer Container { get; private set; }

        public static void Start()
        {
            if (Container == null)
            {
                var builder = new ContainerBuilder();

                builder.RegisterType<TestDb>();

                #region Register database access
                builder.Register(c => new DatabaseFactory()).As<IDatabaseFactory>();

                builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
                builder.RegisterType<ProductRepository>().As<IProductRepository>();

                builder.RegisterType<CategoryService>().As<ICategoryService>();
                builder.RegisterType<ProductService>().As<IProductService>();
                #endregion

                Container = builder.Build();
            }
        }
    }
}
