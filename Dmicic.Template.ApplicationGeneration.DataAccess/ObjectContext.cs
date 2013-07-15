using Dmicic.Template.ApplicationGeneration.Business.Domain;
using Dmicic.Template.ApplicationGeneration.Business.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Dmicic.Template.ApplicationGeneration.DataAccess
{
    public partial class ObjectContext : DbContext, IObjectContext, IUnitOfWork
    {
        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public TEntity Create<TEntity>() where TEntity : class
        {
            var entity = base.Set<TEntity>().Create();
            this.Add<TEntity>(entity);
            return entity;
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class 
        {
            var entityObj = base.Entry(entity);
            if (entityObj.State == EntityState.Detached)
                base.Set<TEntity>().Attach(entityObj.Entity);
            entityObj.State = EntityState.Modified;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            base.Set<TEntity>().Add(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            var entityObj = base.Entry(entity);
            if (entityObj.State == EntityState.Detached)
                base.Set<TEntity>().Attach(entityObj.Entity);
            base.Set<TEntity>().Remove(entity);
        }

        public void Commit()
        {
            base.SaveChanges();
        }

        public TransactionScope StartTransaction()
        {
            return new TransactionScope();
        }
    }
}
