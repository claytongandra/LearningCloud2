using System;
using System.Collections.Generic;
using NewLearningCloud.Domain.Entities;
using NewLearningCloud.Domain.Interfaces.Repositories;
using NewLearningCloud.Domain.Interfaces.Services;

namespace NewLearningCloud.Domain.Services
{
    public class AssinaturaNivelService : ServiceBase<AssinaturaNivel>, IAssinaturaNivelService
    {
        private readonly IAssinaturaNivelRepository _assinaturaNivelRepository;

        public AssinaturaNivelService(IAssinaturaNivelRepository assinaturaNivelRepository)
            : base(assinaturaNivelRepository)
        {
            _assinaturaNivelRepository = assinaturaNivelRepository;
        }

        public IEnumerable<AssinaturaNivel> GetByStatus(string status)
        {
            return _assinaturaNivelRepository.GetByStatus(status);
        }
    }
}
