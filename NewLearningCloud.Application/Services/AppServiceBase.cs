using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using NewLearningCloud.Application.Interfaces;
using NewLearningCloud.Domain.Interfaces.Services;
using NewLearningCloud.Domain.Interfaces.Repositories;

namespace NewLearningCloud.Application.Services
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;
        private IUnitOfWorkRepository _unitOfWork;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public TEntity GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public void BeginTransactionUoW()
        {
            _unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWorkRepository>();
            _unitOfWork.BeginTransactionUoW();
        }

        public void ComitUoW()
        {
            _unitOfWork.CommitUoW();
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
