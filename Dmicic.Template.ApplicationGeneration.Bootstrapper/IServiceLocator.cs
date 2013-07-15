using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmicic.Template.ApplicationGeneration.Bootstrapper
{
    public interface IServiceLocator
    {
        T GetService<T>();
        object GetService(Type type);
        IEnumerable<T> GetServices<T>();
        IEnumerable<object> GetServices(Type type);
    }
}
