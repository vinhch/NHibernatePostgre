using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace NHibernatePostgre.ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            AppStartup.Start();
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();

            using (var scope = AppStartup.Container.BeginLifetimeScope())
            {
                var testDb = scope.Resolve<TestDb>();
                testDb.Run();
            }

            Console.ReadLine();
        }
    }
}
