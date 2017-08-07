using System;
using System.Data.Entity;
using Microsoft.Practices.ServiceLocation;
using NewLearningCloud.Domain.Interfaces.Repositories;
using NewLearningCloud.Infra.Data.Context;

namespace NewLearningCloud.Infra.Data.EntityFramework
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private DbContext _context;

        public void BeginTransactionUoW()
        {
            var contextManager = ServiceLocator.Current.GetInstance<ContextManager<NewLearningCloudContext>>();
            _context = contextManager.GetContext;
        }

        public void CommitUoW()
        {
            _context.SaveChanges();

        }
    }
}
