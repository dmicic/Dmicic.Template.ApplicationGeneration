using Dmicic.Template.ApplicationGeneration.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dmicic.Template.ApplicationGeneration.Business.Domain
{
    public interface IObjectContext
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class;
        TEntity Create<TEntity>() where TEntity : class;
        void Add<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity id) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
    }
}
