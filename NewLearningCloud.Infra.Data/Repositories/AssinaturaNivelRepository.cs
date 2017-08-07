using System.Collections.Generic;
using System.Linq;
using NewLearningCloud.Domain.Entities;
using NewLearningCloud.Domain.Interfaces.Repositories;

namespace NewLearningCloud.Infra.Data.Repositories
{
    public class AssinaturaNivelRepository : RepositoryBase<AssinaturaNivel>, IAssinaturaNivelRepository
    {
        public IEnumerable<AssinaturaNivel> GetByStatus(string status)
        {
            string[] arrayStatus = status.Split(',');

            return ContextDB.Set<AssinaturaNivel>().Where(a => arrayStatus.Contains(a.AssinaturaNivel_Status)).ToList();
        }
    }
}
