using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

using Dmicic.Template.ApplicationGeneration.Business.Repository;
using Dmicic.Template.ApplicationGeneration.Business.Domain;

namespace Dmicic.Template.ApplicationGeneration.DataAccess
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected IObjectContext Context { get; private set; }

        public BaseRepository(IObjectContext context)
        {
            this.Context = context;
        }

        public IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> condition)
        {
            return this.Context.Query<TEntity>().Where(condition).ToList();
        }

        public virtual void Update(TEntity entity)
        {
            this.Context.Update(entity);
        }

        public virtual TEntity Create()
        {
            return this.Context.Create<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            this.Context.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            this.Context.Delete<TEntity>(entity);
        }
    }
}
