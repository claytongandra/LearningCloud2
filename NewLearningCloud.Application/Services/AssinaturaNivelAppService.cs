using System;
using System.Collections.Generic;
using NewLearningCloud.Application.Interfaces;
using NewLearningCloud.Domain.Entities;
using NewLearningCloud.Domain.Interfaces.Services;

namespace NewLearningCloud.Application.Services
{
    public class AssinaturaNivelAppService : AppServiceBase<AssinaturaNivel>, IAssinaturaNivelAppService
    {
        private readonly IAssinaturaNivelService _assinaturaNivelService;

        public AssinaturaNivelAppService(IAssinaturaNivelService assinaturaNivelService)
            : base(assinaturaNivelService)
        {
            _assinaturaNivelService = assinaturaNivelService;
        }

        public IEnumerable<AssinaturaNivel> GetByStatusAssinaturaNivel(string status)
        {
            return _assinaturaNivelService.GetByStatus(status);
        }
    }
}
