using Dmicic.Template.ApplicationGeneration.Business.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Dmicic.Template.ApplicationGeneration.Business.Repository
{
    public partial interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> condition);
        void Update(TEntity entity);
        TEntity Create();
        void Add(TEntity entity);
        void Delete(TEntity entity);
    }
}
