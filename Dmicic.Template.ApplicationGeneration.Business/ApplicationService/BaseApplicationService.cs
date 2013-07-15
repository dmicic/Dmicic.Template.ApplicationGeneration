using Dmicic.Template.ApplicationGeneration.Business.Domain;
using Dmicic.Template.ApplicationGeneration.Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dmicic.Template.ApplicationGeneration.Business.ApplicationService
{
    public abstract class BaseApplicationService<TEntity> : IApplicationService<TEntity> where TEntity : class
    {
        protected IRepository<TEntity> BaseRepository { get; private set; }

        public BaseApplicationService(IRepository<TEntity> repository)
        {
            this.BaseRepository = repository;
        }

        public virtual TEntity Create()
        {
            return this.BaseRepository.Create();
        }

        public virtual void Add(TEntity entity)
        {
            this.BaseRepository.Add(entity);
        }
        
        public virtual void Update(TEntity entity)
        {
            this.BaseRepository.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            this.BaseRepository.Delete(entity);
        }
    }
}
