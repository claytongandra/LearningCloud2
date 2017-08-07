using NewLearningCloud.Domain.Entities;
using System.Collections.Generic;

namespace NewLearningCloud.Application.Interfaces
{
    public interface IAssinaturaNivelAppService : IAppServiceBase<AssinaturaNivel>
    {
        IEnumerable<AssinaturaNivel> GetByStatusAssinaturaNivel(string status);
    }
}
