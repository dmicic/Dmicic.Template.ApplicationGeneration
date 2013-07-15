using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dmicic.Template.ApplicationGeneration.Bootstrapper.Web
{
    public class MvcDependencyResolver : IDependencyResolver
    {
        private IServiceLocator Locator { get; set; }

        public MvcDependencyResolver()
        {
            this.Locator = new StructureMapServiceLocator();
        }

        public object GetService(Type serviceType)
        {
            return this.Locator.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.Locator.GetServices(serviceType);
        }
    }
}
