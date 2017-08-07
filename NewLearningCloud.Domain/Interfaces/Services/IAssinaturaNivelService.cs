using System.Collections.Generic;
using NewLearningCloud.Domain.Entities;

namespace NewLearningCloud.Domain.Interfaces.Services
{
    public interface IAssinaturaNivelService : IServiceBase<AssinaturaNivel>
    {
        IEnumerable<AssinaturaNivel> GetByStatus(string status);
    }
}
