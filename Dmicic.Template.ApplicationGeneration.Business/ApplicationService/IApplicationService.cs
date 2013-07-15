using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dmicic.Template.ApplicationGeneration.Business.ApplicationService
{
    public interface IApplicationService<TEntity> where TEntity : class
    {
        TEntity Create();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
