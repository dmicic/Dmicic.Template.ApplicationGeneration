using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using StructureMap; 

using Dmicic.Template.ApplicationGeneration.Business.Repository;
using Dmicic.Template.ApplicationGeneration.DataAccess;
using Dmicic.Template.ApplicationGeneration.Bootstrapper.Web;
using Dmicic.Template.ApplicationGeneration.Business.Domain;

namespace Dmicic.Template.ApplicationGeneration.Bootstrapper
{
    public static class Boot
    {
        public static void Initialize()
        {
            ObjectFactory.Configure((config) => 
            {
                config.For<IObjectContext>().HttpContextScoped().Use<ObjectContext>();
                config.For<IUnitOfWork>().HttpContextScoped().Use(() => (IUnitOfWork)new StructureMapServiceLocator().GetService(typeof(IObjectContext)));

                config.Scan(scanner => 
                {
                    scanner.WithDefaultConventions();
                    scanner.AssemblyContainingType(typeof(IRepository<>));
                    scanner.AssemblyContainingType(typeof(BaseRepository<>));
                    scanner.ExcludeType<IObjectContext>();
                    scanner.ExcludeType<IUnitOfWork>();
                    scanner.AddAllTypesOf<IController>();
                });
            });

            Boot.InitMvc();
        }

        public static void Cleanup()
        {
            ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
        }

        private static void InitMvc()
        {
            DependencyResolver.SetResolver(new MvcDependencyResolver());
        }
    }
}
