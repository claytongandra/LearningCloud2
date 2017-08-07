using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using NewLearningCloud.Domain.Interfaces.Repositories;
using NewLearningCloud.Infra.Data.EntityFramework;
using NewLearningCloud.Infra.Data.Context;

namespace NewLearningCloud.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected DbContext ContextDB { get; private set; }

        public RepositoryBase()
        {
            var contextManager = ServiceLocator.Current.GetInstance<ContextManager<NewLearningCloudContext>>();
            ContextDB = contextManager.GetContext;
        }

        public void Add(TEntity obj)
        {
            ContextDB.Set<TEntity>().Add(obj);
        }

        public TEntity GetById(int id)
        {
            return ContextDB.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return ContextDB.Set<TEntity>().ToList(); // verificar o AsNoTracking().ToList();
        }

        public void Update(TEntity obj)
        {
            ContextDB.Entry(obj).State = EntityState.Modified;
        }
    
        public void Remove(TEntity obj)
        {
            ContextDB.Set<TEntity>().Remove(obj);
        }
        
        public void Dispose()
        {
            ContextDB.Dispose();
        }
    }
}
