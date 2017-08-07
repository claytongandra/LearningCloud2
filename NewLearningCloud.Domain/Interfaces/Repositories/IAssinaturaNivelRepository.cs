using System.Collections.Generic;
using NewLearningCloud.Domain.Entities;


namespace NewLearningCloud.Domain.Interfaces.Repositories
{
    public interface IAssinaturaNivelRepository : IRepositoryBase<AssinaturaNivel>
    {
        IEnumerable<AssinaturaNivel> GetByStatus(string status);
    }
}
