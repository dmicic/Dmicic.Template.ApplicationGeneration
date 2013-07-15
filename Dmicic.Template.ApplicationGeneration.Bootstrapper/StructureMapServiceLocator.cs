using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmicic.Template.ApplicationGeneration.Bootstrapper
{
    public class StructureMapServiceLocator : IServiceLocator
    {
        public T GetService<T>()
        {
            try
            {
                return ObjectFactory.GetInstance<T>();
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public object GetService(Type type)
        {
            try
            {
                return ObjectFactory.GetInstance(type);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<T> GetServices<T>()
        {
            return ObjectFactory.GetAllInstances<T>();
        }

        public IEnumerable<object> GetServices(Type type)
        {
            var result = ObjectFactory.GetAllInstances(type);
            if (result.Count > 0)
                return result.AsQueryable().Cast<object>().AsEnumerable();
            return new List<object>();
        }
    }
}
